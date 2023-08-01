using System.Collections.Generic;

namespace BookStore.Core.Entities.Concrete.Dto
{

    public class PaginationDto<T>
    {
        public PaginationDto()
        {
            Value = new List<T>();
        }
        public int Size { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public List<T> Value { get; set; }

        public bool HasNextPage => PageNumber < TotalPage;
        public bool IsFırstPage => PageNumber == 1;
    }
}
