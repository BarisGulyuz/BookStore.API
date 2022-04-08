using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.Helpers.CloudinaryHelper;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.DTOs.Book;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class BookManager : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<BookCreateDto> _createValidator;
        private readonly IValidator<BookUpdateDto> _updateValidator;
        private readonly ICloudinary _cloudinaryService;

        public BookManager(IBookRepository bookRepository, IMapper mapper, IValidator<BookCreateDto> createValidator, IValidator<BookUpdateDto> updateValidator, ICloudinary cloudinaryService)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
            _cloudinaryService = cloudinaryService;
        }

        public async Task<Result> AddAsync(BookCreateDto bookCreateDto)
        {
            var result = _createValidator.Validate(bookCreateDto);
            if (result.IsValid)
            {
                string imageUrl = _cloudinaryService.AddPhotoAndGetUrl(bookCreateDto.Image);
                var book = _mapper.Map<Book>(bookCreateDto);
                book.ImageUrl = imageUrl;
                book.Status = true;
                await _bookRepository.AddAsync(book);
                return Result.Success();
            }
            return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
        }

        public async Task<Result> DeleteAsync(int bookId)
        {
            var book = await _bookRepository.GetAsync(x => x.Id == bookId);
            if (book == null) return Result.Failure("There is no data for this query");
            await _bookRepository.DeleteAsync(book);
            return Result.Success();
        }

        public async Task<DataResult<List<BookGetDto>>> GetAllAsync(int categoryId, int authorId, int pageSize, int pageNumber)
        {
            List<Book> books = new List<Book>();
            switch (authorId == 0, categoryId == 0)
            {
                case (true, true):
                    books = await _bookRepository.GetAllAsync(filter: null, x => x.Author, x => x.Category);
                    break;
                case (false, false):
                    books = await _bookRepository.GetAllAsync(filter: x => x.CategoryId == categoryId && x.AuthorId == authorId, x => x.Author, x => x.Category);
                    break;
                default:
                    books = await _bookRepository.GetAllAsync(filter: x => x.CategoryId == categoryId || x.AuthorId == authorId, x => x.Author, x => x.Category);
                    break;
            }
            if (books.Count > 0)
            {
                books = books.Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToList();
                var bookReturn = _mapper.Map<List<BookGetDto>>(books);
                return DataResult<List<BookGetDto>>.Success(bookReturn);
            }
            return DataResult<List<BookGetDto>>.Failure("There is no data for this query");
        }

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
            if (book == null) return Result.Failure("There is no data for this query");
            await _bookRepository.HardDelete(book);
            return Result.Success();
        }

        public async Task<Result> UpdateAsync(BookUpdateDto bookUpdateDto)
        {
            var oldBook = await _bookRepository.GetAsync(x => x.Id == bookUpdateDto.Id);
            if (oldBook != null)
            {
                var result = _updateValidator.Validate(bookUpdateDto);
                if (result.IsValid)
                {
                    string imageUrl = _cloudinaryService.AddPhotoAndGetUrl(bookUpdateDto.Image);
                    var book = _mapper.Map<BookUpdateDto, Book>(bookUpdateDto, oldBook);
                    book.ImageUrl = imageUrl;
                    await _bookRepository.Update(book);
                    return Result.Success();
                }
                return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
            }
            return Result.Failure("There is no data for this query");
        }
    }
}
