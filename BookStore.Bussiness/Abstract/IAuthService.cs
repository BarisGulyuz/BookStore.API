using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Abstract
{
    public interface IAuthService
    {
        Task<Result> RegisterAsync(UserCreateDto userCreateDto);
        Task<DataResult<User>> GetUserAsync(string email, string password);
        Task<DataResult<UserGetDto>> GetUserByFilterAsync(int id);
    }
}
