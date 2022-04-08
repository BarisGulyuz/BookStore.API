using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Bussiness.Extensions;
using BookStore.Core.Enums;
using BookStore.Core.Helpers.PasswordHasher;
using BookStore.Core.Results;
using BookStore.DataAccess.Repositories.Abstract;
using BookStore.Entities;
using BookStore.Entities.DTOs.User;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<UserCreateDto> _createValidator;

        public AuthManager(IUserRepository userRepository, IMapper mapper, IValidator<UserCreateDto> createValidator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _createValidator = createValidator;
        }
        public Task<DataResult<UserGetDto>> GetUserByFilterAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DataResult<User>> GetUserAsync(string email, string password)
        {
            string hashedPassword = MD5Hasher.HashPassword(password);
            var user = await _userRepository.GetAsync(x => x.Email == email && x.Password == hashedPassword, x => x.Role);
            if (user != null)
            {
                return DataResult<User>.Success(user);
            }
            return DataResult<User>.Failure("Email or password wrong");
        }

        public async Task<Result> RegisterAsync(UserCreateDto userCreateDto)
        {
            bool checkUser = await CheckUserMail(userCreateDto.Email);
            if (checkUser)
            {
                var result = _createValidator.Validate(userCreateDto);
                if (result.IsValid)
                {
                    userCreateDto.RoleId = (int)RoleEnum.Member;
                    userCreateDto.Password = MD5Hasher.HashPassword(userCreateDto.Password);
                    var user = _mapper.Map<User>(userCreateDto);
                    await _userRepository.AddAsync(user);
                    return Result.Success("User Created");

                }
                return Result.Failure("Validation Error", result.ConvertToCustomValidationErrors());
            }
            return Result.Failure("Email already exist");
        }
        private async Task<bool> CheckUserMail(string email)
        {
            var user = await _userRepository.AnyAsync(x => x.Email == email);
            return user ? false : true;
        }
    }
}
