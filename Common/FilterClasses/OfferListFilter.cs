using System;

namespace Common.FilterClasses
{
    public class OfferListFilter : PaginationParameters
    {
        private int? _offerStatus { get; set; }
        public int? OfferStatus
        {
            get { return _offerStatus; }
            set
            {
                if (value != null) if (value > 5 || value < 0) throw new InvalidOperationException();
                _offerStatus = value;
            }
        }
    }
}
