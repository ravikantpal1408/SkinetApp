namespace SkynetApp.API.Extensions
{
    public class PaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int _pageSize = 3;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
        }
    }

    public class ProductParams : PaginationParams
    {
        public string OrderBy { get; set; } = string.Empty;
        public string SearchTerm { get; set; } = string.Empty;
        public string Types { get; set; } = string.Empty;
        public string Brands { get; set; } = string.Empty;
    }
}
