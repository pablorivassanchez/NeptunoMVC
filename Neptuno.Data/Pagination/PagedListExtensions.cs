using System.Collections.Generic;
using System.Linq;

namespace Neptuno.Data.Pagination
{
    /// <summary>
    /// Extensiones para obtener resultados paginas en las consultas con EF
    /// https://www.talksharp.com/entity-framework-paging
    /// </summary>
    public static class PagedListExtensions
    {
        public static List<T> GetListPage<T>(this IQueryable<T> source, IPaginationModel filter)
        {
            filter.TotalItemCount = source.Count();
            return GetListPage(source, filter.CurrentPage, filter.PageSize, filter.TotalItemCount);
        }

        public static List<T> GetListPage<T>(this IQueryable<T> source, int? page, int? pageSize, int? itemCount)
        {
            int totalItemCount = (itemCount.HasValue) ? itemCount.Value : source.Count();
            int pageCount = GetPageCount(pageSize.Value, totalItemCount);
            int currentPage = (!page.HasValue || page.Value < 1) ? 0 : page.Value - 1;
            return (totalItemCount == 0) ? source.ToList() : source.Skip(currentPage * pageSize.Value).Take(pageSize.Value).ToList();
        }

        public static List<T> GetListPage<T>(this List<T> source, IPaginationModel filter)
        {
            filter.TotalItemCount = source.Count();
            return GetListPage(source, filter.CurrentPage, filter.PageSize, filter.TotalItemCount);
        }

        public static List<T> GetListPage<T>(this List<T> source, int? page, int? pageSize, int? itemCount)
        {
            int totalItemCount = (itemCount.HasValue) ? itemCount.Value : source.Count();
            int pageCount = GetPageCount(pageSize.Value, totalItemCount);
            int currentPage = (!page.HasValue || page.Value < 1) ? 0 : page.Value - 1;
            return (totalItemCount == 0) ? source.ToList() : source.Skip(currentPage * pageSize.Value).Take(pageSize.Value).ToList();
        }

        public static PagedList<T> ToPagedList<T>(this IQueryable<T> source, int page, int pageSize)
        {
            return new PagedList<T>(source, page, pageSize);
        }

        private static int GetPageCount(int pageSize, int totalCount)
        {
            if (pageSize == 0)
                return 0;

            var remainder = totalCount % pageSize;
            return (totalCount / pageSize) + (remainder == 0 ? 0 : 1);
        }
    }
}
