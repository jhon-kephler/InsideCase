using InsideCase.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsideCase.Core.Schema
{
    public class PaginatedResult<T> : Result<IEnumerable<T>>
    {
        public PaginatedResult() { }

        public PaginatedResult(IEnumerable<T> data, int page, int pageSize)
        {
            var totalCount = data.Count();
            var paginatedData = data.Skip((page - 1) * pageSize).Take(pageSize);

            PageNumber = page;
            PageSize = pageSize;
            TotalCount = totalCount;
            SetSuccess(paginatedData);
        }

        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasNextPage => PageNumber < TotalPages;

        public static PaginatedResult<T> Create(IEnumerable<T> data, int pageNumber, int pageSize)
        {
            var result = new PaginatedResult<T>
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = data.Count()
            };
            result.SetSuccess(data);
            return result;
        }
    }
}
