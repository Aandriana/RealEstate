using System;

namespace RealEstateIdentity.ViewModels
{
    public class OfferResponseViewModel
    {
        private int _response;
        public int Response 
        {
            get { return _response; }
            set 
            {
                if (value > 5 || value < 0) throw new InvalidOperationException();
                else _response = value;
            }
        }
    }
}
