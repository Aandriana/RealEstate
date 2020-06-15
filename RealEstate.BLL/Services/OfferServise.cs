using Common.Enums;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System.Threading.Tasks;

namespace RealEstate.BLL.Services
{
    public class OfferServise
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public OfferServise(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
