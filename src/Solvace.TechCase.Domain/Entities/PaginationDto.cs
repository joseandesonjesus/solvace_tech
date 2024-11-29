namespace Solvace.TechCase.Domain.Entities
{
    public class PaginationDto
    {
        public IEnumerable<object> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public PaginationDto(IEnumerable<object> items, int totalCount, int pageIndex, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
    }
}
