using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.User
{
    public class UserCreateDto : CreateDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
