using BookStore.Core.Entities.Concrete.Dto;
using BookStore.Core.Results;
using BookStore.Entities.DTOs.Book;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IBookService
    {
        Task<DataResult<PaginationDto<BookGetDto>>> GetAllAsync(int categoryId, int athorId, int pageSize, int pageNumber);
        Task<DataResult<BookGetDto>> GetByIdAsync(int bookId);
        Task<Result> AddAsync(BookCreateDto bookCreateDto);
        Task<Result> DeleteAsync(int bookId);
        Task<Result> HardDelete(int bookId);
        Task<Result> UpdateAsync(BookUpdateDto bookUpdateDto);
    }
}
