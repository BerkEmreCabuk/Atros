using System;
using System.Collections.Generic;
using System.Text;

namespace Atros.Common.Models
{
    public class PagedList<T>
    {
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            Items = source;
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public int PageIndex { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public int TotalPages
        {
            get
            {
                return Convert.ToInt32(Math.Ceiling((double)TotalCount / (double)PageSize));
            }
        }
        public IEnumerable<T> Items { get; set; }
    }
}
