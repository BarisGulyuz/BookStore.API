using AutoMapper;
using BookStore.Bussiness.Abstract;
using BookStore.Core.DataAccess.Abstract;
using BookStore.Core.Enums;
using BookStore.Core.Helpers.PasswordHasher;
using BookStore.Core.Results;
using BookStore.Entities;
using BookStore.Entities.DTOs.User;
using System.Threading.Tasks;

namespace BookStore.Bussiness.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IMapper _mapper;

        public AuthManager(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<DataResult<User>> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetAsync(x => x.Id == id, x => x.Role);
            if (user != null)
            {
                return DataResult<User>.Success(user);
            }
            return DataResult<User>.Failure("User Does Not Exist");
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
            bool isEMailOkay = await CheckUserMail(userCreateDto.Email);

            if (isEMailOkay)
            {
                userCreateDto.RoleId = (int)RoleEnum.Member;
                userCreateDto.Password = MD5Hasher.HashPassword(userCreateDto.Password);

                var user = _mapper.Map<User>(userCreateDto);
                await _userRepository.AddAsync(user);

                return Result.Success("User Created");
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
