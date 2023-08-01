using BookStore.Core.Entities;

namespace BookStore.Entities
{
    public class User : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
