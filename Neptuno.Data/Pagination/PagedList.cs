using System.Collections.Generic;
using System.Linq;

namespace Neptuno.Data.Pagination
{
    /// <summary>
    /// https://www.talksharp.com/entity-framework-paging
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>, IPaginationModel
    {
        public int? CurrentPage { get; set; }
        public int? PageSize { get; set; }
        public int? TotalItemCount { get; set; }
        public int PageCount { get; private set; }

        public PagedList(IEnumerable<T> source, int page, int pageSize)
        {
            TotalItemCount = source.Count();
            PageCount = GetPageCount(pageSize, TotalItemCount.Value);
            CurrentPage = page < 1 ? 0 : page - 1;
            PageSize = pageSize;
            AddRange(source.Skip(CurrentPage.Value * PageSize.Value).Take(PageSize.Value).ToList());
        }

        private int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }
}
