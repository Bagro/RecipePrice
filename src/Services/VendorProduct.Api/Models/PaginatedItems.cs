using System.Collections.Generic;

namespace VendorProduct.Api.Models
{
    public class PaginatedItems<TEntity> where TEntity : class
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<TEntity> Items { get; private set; }

        public PaginatedItems(int pageIndex, int pageSize, long count, IEnumerable<TEntity> items)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Items = items;
        }
    }
}