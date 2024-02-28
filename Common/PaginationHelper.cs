namespace ProjectMarketPlace.Common
{
    public class PaginationHelper
    {
        public static PageData<T> CreatePagination<T>(IEnumerable<T> pageData, PageFilter filter, int totalRecords) where T : class
        {
            var totalPages = (double)(totalRecords / filter.PageSize);
            int roundTotalPages = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(totalPages)));
            return new PageData<T>
            {
                Data = pageData,
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                TotalPages = roundTotalPages,
                TotalRecords = totalRecords,
                First = filter.PageNumber == 1,
                Last = filter.PageNumber == roundTotalPages
            };
        }
    }
}
