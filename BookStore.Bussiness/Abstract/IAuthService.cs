using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.User;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(UserCreateDto userCreateDto);
        Task<DataResult<User>> GetUserAsync(string email, string password);
        Task<DataResult<User>> GetUserByIdAsync(int id);
    }
}
