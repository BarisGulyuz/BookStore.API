using BookStore.Core.Results;
using BookStore.Entities.DTOs.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IBookService
    {
        Task<DataResult<List<BookGetDto>>> GetAllAsync(int categoryId, int athorId, int pageSize, int pageNumber);
        Task<DataResult<BookGetDto>> GetByIdAsync(int bookId);
        Task<Result> AddAsync(BookCreateDto bookCreateDto);
        Task<Result> DeleteAsync(int bookId);
        Task<Result> HardDelete(int bookId);
        Task<Result> UpdateAsync(BookUpdateDto bookUpdateDto);
    }
}
