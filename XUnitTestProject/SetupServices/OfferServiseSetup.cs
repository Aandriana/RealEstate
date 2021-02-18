using AutoMapper;
using Moq;
using RealEstate.BLL.Interfaces;
using RealEstate.BLL.Services;
using RealEstate.DAL.Entities;
using RealEstate.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XUnitTestProject.Services;

namespace XUnitTestProject.SetupServices
{

    public class OfferServiseSetup
    {
        protected readonly OfferServise _offerServise;
        protected readonly Mock<IAuthenticationService> _authService;
        protected readonly Mock<IUnitOfWork> _unitOfWorkMock;
        protected readonly RepositoryMock<Offer> _offerRepoMock;
        protected readonly Mock<IMapper> _mapper;

        public OfferServiseSetup()
        {
            _mapper = new Mock<IMapper>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _authService = new Mock<IAuthenticationService>();
            _offerServise = new OfferServise(_unitOfWorkMock.Object, _mapper.Object, _authService.Object);
        }
        protected IEnumerable<Offer> GetOfferTestData()
        {
            var data = new List<Offer>();
            var offer = new Offer
            {
                Comment = DefaultValues.DefaultValues.DefaultString,
                Rate = DefaultValues.DefaultValues.DefaultPrice,
                PropertyId = DefaultValues.DefaultValues.DefaultInt,
                Status = DefaultValues.DefaultValues.DefaultStatus,
                AgentProfileId = DefaultValues.DefaultValues.DefaultUserId,
                Property = null,
                Answers = null
             };
            data.Add(offer);
            return data.AsEnumerable();
        }
    }
}
