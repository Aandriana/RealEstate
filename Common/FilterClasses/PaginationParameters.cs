namespace Common.FilterClasses
{
    public class PaginationParameters
    {
        protected int _pageNumber = 1;
        protected int _pageSize = 1;


        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value > 1 ? value : 1;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > 0 ? value : 0;
        }

        public int Skip => (PageNumber - 1) * PageSize;
        public int Take => PageSize;
    }
}
