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
        public void ShouldCall_ReposityCreateAsyncWithDTO()
        {
            var dto = new CustomerSupportCreateDTO();

            _ = _sut.CreateAsync(dto);

            _mockRepo.Verify(repository => repository.CreateAsync(It.IsAny<CustomerSupportModel>()), Times.Once);
        }

        [Fact]
        public void ShouldCall_ReposityUpdateAsyncWithDTO()
        {
            var customerSupport = new CustomerSupportModel();
            var customerSupportDto = new CustomerSupportUpdateDTO() { Id = 51 };
            var ticketDb = new CustomerSupportModel();

            _mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => ticketDb);

            _ = _sut.UpdateAsync(customerSupportDto);

            _mockRepo.Verify(repository => repository.UpdateAsync(ticketDb), Times.Once);
        }

        [Fact]
        public async void ShouldCall_ReposityUpdateAsyncWithNullObject()
        {
            var customerSupportDto = new CustomerSupportUpdateDTO() { Id = 51 };

            _mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            _ = _sut.UpdateAsync(customerSupportDto);

            _mockRepo.Verify(repository => repository.UpdateAsync(It.IsAny<CustomerSupportModel>()), Times.Never);
        }

        [Fact]
        public void ShouldCall_ReposityDeleteAsyncWithDTO()
        {
            var customerSupport = new CustomerSupportModel();
            var customerSupportDto = new CustomerSupportUpdateDTO() { Id = 51 };
            var ticketDb = new CustomerSupportModel();

            _mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => ticketDb);

            _ = _sut.DeleteAsync(customerSupportDto.Id);

            _mockRepo.Verify(repository => repository.DeleteAsync(ticketDb), Times.Once);
        }

        [Fact]
        public async void ShouldCall_ReposityDeleteAsyncWithNullObject()
        {
            var customerSupportDto = new CustomerSupportUpdateDTO() { Id = 51 };

            _mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            _ = _sut.DeleteAsync(customerSupportDto.Id);

            _mockRepo.Verify(repository => repository.DeleteAsync(It.IsAny<CustomerSupportModel>()), Times.Never);
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
            _mockRepo.Setup(x => x.GetAsync(It.IsAny<int>())).ReturnsAsync(() => null);
            var exception = Assert.ThrowsAsync<KeyNotFoundException>(async () => await _sut.GetAsync(999));
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
