namespace ProjectMarketPlace.Common
{
    public class PageData <T> where T: class
    {
        public IEnumerable<T>? Data {  get; set; }
        public int? PageNumber { get; set; }
        public int PageSize { get; set; }
        public int? TotalPages { get; set; }
        public int? TotalRecords { get; set; }
        public bool? First { get; set; }
        public bool? Last { get; set; }
    }
}
