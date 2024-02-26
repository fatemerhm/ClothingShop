namespace ClothingShop.Models
{
    public class PagedList<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;
        public List<T> Data { get; private set; }
        public PagedList(List<T> items, int pageNumber, int pageSize, int total)
        {
            TotalCount = total;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            Data = items;

        }
    }
}
