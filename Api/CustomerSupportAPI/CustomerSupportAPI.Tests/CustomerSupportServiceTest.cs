using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Interfaces;
using CustomerSupportAPI.Service.Implements;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportController")]
    public class CustomerSupportServiceTest
    {
        #region Properties
        private readonly CustomerSupportService _sut;
        private readonly Mock<ICustomerSupportRepository> _mockRepo;
        #endregion Properties

        public CustomerSupportServiceTest()
        {
            _mockRepo = new Mock<ICustomerSupportRepository>();
            _sut = new CustomerSupportService(_mockRepo.Object);
        }

        [Fact]
        public void ShouldCall_ReposityCreateWithDTO()
        {
            var dto = new CustomerSupportDTO();

            _ = _sut.CreateAsync(dto);

            _mockRepo.Verify(repository => repository.CreateAsync(It.IsAny<CustomerSupportModel>()), Times.Once);
        }

        [Fact]
        public async void ShouldCall_Get_InvalidId_Return_AppException()
        {
            var exception = Assert.ThrowsAsync<AppException>(async () => await _sut.GetAsync(0));
            Assert.Equal("It's necessary to inform a valid Id", exception.Result.Message);
        }

        [Fact]
        public async void ShouldCall_GetTicketById_Return_KeyNotFoundException()
        {
            int? id = 33322;
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () => await _sut.GetAsync(id.GetValueOrDefault()));
            Assert.Equal("Id not found any ticket", exception.Result.Message);
        }

        [Fact]
        public async void ShouldCall_GetTicketById_With_IdNull_Return_AppException()
        {
            int? id = null;
            var exception = Assert.ThrowsAsync<AppException>(async () => await _sut.GetAsync(id.GetValueOrDefault()));
        }
    }
}
