namespace BookStore.Core.Entities.Abstract
{
    public class UpdateDto : IDto
    {
        public int Id { get; set; }
        public bool Status { get; set; }
    }
}
