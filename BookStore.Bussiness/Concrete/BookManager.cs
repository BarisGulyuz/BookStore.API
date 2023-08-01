using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Entities.Concrete.Dto;
using BookStore.Core.Helpers.CloudinaryHelper;
using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.Book;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IMapper _mapper;
        private readonly IFileService _cloudinaryService;

        public BookManager(IRepository<Book> bookRepository, IMapper mapper, IFileService cloudinaryService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Result> AddAsync(BookCreateDto bookCreateDto)
        {
            string imageUrl = await _cloudinaryService.UploadFile(bookCreateDto.Image);

            Book book = _mapper.Map<Book>(bookCreateDto);
            book.ImageUrl = imageUrl;
            book.Status = true;

            await _bookRepository.AddAsync(book, autoSave: true);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == bookId);
            if (book == null)
            {
                return Result.Failure("There is no data for this query");
            }

            await _bookRepository.DeleteAsync(book, autoSave: true);
            return Result.Success();
        }

        public async Task<DataResult<PaginationDto<BookGetDto>>> GetAllAsync(int categoryId, int authorId, int pageSize, int pageNumber)
        {
            IQueryable<Book> bookQuery = _bookRepository.GetQueryable(withAsNoTracking: true)
                                                        .Include(x => x.Category)
                                                        .Include(x => x.Author);

            bookQuery = bookQuery.WhereIf(x => x.AuthorId == authorId, condition: authorId > 0);
            bookQuery = bookQuery.WhereIf(x => x.CategoryId == categoryId, condition: categoryId > 0);

            PaginationDto<BookGetDto> books = await _mapper.ProjectTo<BookGetDto>(bookQuery) //select 
                                                            .OrderByDescending(b => b.Id)
                                                            .ToPaginateAsync(pageSize, pageNumber);

            if (books.Value.Count > 0)
            {
                return DataResult<PaginationDto<BookGetDto>>.Success(books);
            }

            return DataResult<PaginationDto<BookGetDto>>.Failure("There is no data for this query");
        }

        #region IQueryable Select 

        //_bookRepository.GetQueryable(withAsNoTracking: true).Select(SelectConvertFunc)

        //private BookGetDto SelectConvertFunc(Book book)
        //{
        //    return new BookGetDto();
        //}

        #endregion

        public async Task<DataResult<BookGetDto>> GetByIdAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == bookId, x => x.Author, x => x.Category);
            if (book != null)
            {
                var bookReturn = _mapper.Map<BookGetDto>(book);
                return DataResult<BookGetDto>.Success(bookReturn);
            }

            return DataResult<BookGetDto>.Failure("There is no data for this query");
        }

        public async Task<Result> HardDelete(int bookId)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == bookId);
            if (book == null)
            {
                return Result.Failure("There is no data for this query");
            }

            await _bookRepository.HardDelete(book, autoSave: true);
            return Result.Success();
        }

        public async Task<Result> UpdateAsync(BookUpdateDto bookUpdateDto)
        {
            var oldBook = await _bookRepository.GetAsync(x => x.Id == bookUpdateDto.Id);
            if (oldBook != null)
            {
                Book book = _mapper.Map<BookUpdateDto, Book>(bookUpdateDto, oldBook);
                if (bookUpdateDto.NewImage != null)
                {
                    string imageUrl = await _cloudinaryService.UploadFile(bookUpdateDto.NewImage);
                    book.ImageUrl = imageUrl;
                }

                await _bookRepository.UpdateAsync(book, autoSave: true);
                return Result.Success();
            }
            return Result.Failure("There is no data for this query");
        }
    }
}
