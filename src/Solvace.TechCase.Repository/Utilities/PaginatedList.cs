using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Solvace.TechCase.Domain.Utilities
{
    public class PaginatedList<T>
    {
        public List<T> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public PaginatedList(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            Items = items;
            TotalCount = totalCount;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public static PaginatedList<T> Create(List<T> items, int totalCount, int pageNumber, int pageSize)
        {
            return new PaginatedList<T>(items, totalCount, pageNumber, pageSize);
        }
    }

}
