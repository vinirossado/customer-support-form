using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Interfaces;
using CustomerSupportAPI.Service.Implements;
using Moq;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportController")]
    public class CustomerSupportServiceTest
    {
        #region Properties
        private readonly CustomerSupportService _sut;
        private readonly Mock<ICustomerSupportRepository> mockRepo;
        #endregion Properties


        public CustomerSupportServiceTest()
        {
            mockRepo = new Mock<ICustomerSupportRepository>();
            _sut = new CustomerSupportService(mockRepo.Object);
        }

        [Fact]
        public void ShouldCall_ReposityCreateWithDTO()
        {
            var dto = new CustomerSupportDTO();

            _ = _sut.Create(dto);

            mockRepo.Verify(repository => repository.Create(It.IsAny<CustomerSupportModel>()), Times.Once);
        }
    }
}
