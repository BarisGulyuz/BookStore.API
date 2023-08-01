using BookStore.Core.Entities.Abstract;

namespace BookStore.Entities.DTOs.User
{
    public class UserUpdateDto : UpdateDto
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
