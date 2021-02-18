using AutoMapper;
using Moq;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.Services;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Linq;
using XUnitTestProject.Services;

namespace XUnitTestProject.SetupServices
{
    public class PropertyServiceSetup
    {
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly RepositoryMock<Property> _propertyRepoMock;
        protected readonly Mock<IMapper> _mapper;
        protected readonly Mock<IAuthenticationService> _authService;
        protected readonly Mock<IFileService> _fileService;
        protected readonly PropertyService _propertyService;

        public PropertyServiceSetup()
        {
            _propertyRepoMock = new RepositoryMock<Property>(GetPropertyTestData().ToList());
            _mapper = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _authService = new Mock<IAuthenticationService>();
            _fileService = new Mock<IFileService>();
            _propertyService = new PropertyService(_unitOfWorkMock.Object, _fileService.Object, _authService.Object, _mapper.Object);
        }
        protected IEnumerable<Property> GetPropertyTestData()
        {
            var data = new List<Property>();
            var property = new Property
            {
                Size = DefaultValues.DefaultValues.DefaultSize,
                Category = DefaultValues.DefaultValues.DefaultCategory,
                FloorsNumber = DefaultValues.DefaultValues.DefaultFloorsNumber,
                Floors = DefaultValues.DefaultValues.DefaultFloors,
                Price = DefaultValues.DefaultValues.DefaultPrice,
                City = DefaultValues.DefaultValues.DefaultCity,
                Address = DefaultValues.DefaultValues.DefaultAddress,
                BuildYear = DefaultValues.DefaultValues.DefaultBuildYear,
                Status = DefaultValues.DefaultValues.DefaultStatus,
                UserId = DefaultValues.DefaultValues.DefaultUserId,
                Offers = null,
                Photos = null,
                Questions = null
            };

             data.Add(property);
            return data.AsEnumerable();
        }

    }
}
