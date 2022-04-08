using BookStore.Core.Results;
using BookStore.Entities.DTOs.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IAuthorService
    {
        Task<DataResult<List<AuthorGetDto>>> GetAllAsync();
        Task<DataResult<AuthorGetDto>> GetByIdAsync(int authorId);
        Task<Result> AddAsync(AuthorCreateDto authorCreateDto);
        Task<Result> DeleteAsync(int authorId);
        Task<Result> UpdateAsync(AuthorUpdateDto authorUpdateDto);
    }
}
