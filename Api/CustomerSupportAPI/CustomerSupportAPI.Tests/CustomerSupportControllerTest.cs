using AutoMapper;
using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Controllers;
using CustomerSupportAPI.Service.Interfaces;
using CustomerSupportAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportController")]
    public class CustomerSupportControllerTest
    {
        #region Properties
        private readonly CustomerSupportController _sut;
        private readonly Mock<ICustomerSupportService> _custumerSupportService;
        private readonly Mock<ILogger<CustomerSupportController>> _custumerSupportLogger;
        private readonly Mock<IMapper> _mapper;
        #endregion Properties

        #region Constructors
        public CustomerSupportControllerTest()
        {
            _mapper = new Mock<IMapper>();
            _custumerSupportLogger = new Mock<ILogger<CustomerSupportController>>();
            _custumerSupportService = new Mock<ICustomerSupportService>();
            _sut = new CustomerSupportController(_custumerSupportService.Object, _custumerSupportLogger.Object, _mapper.Object);
        }

        #endregion Constructors

        #region Methods
        [Fact]
        public async void ShouldCall_Create_ValidData_Return_ActionResult_CustomerSupportViewModel()
        {

            var customerSupport = new CustomerSupportDTO();

            var data = await _sut.Create(customerSupport);

            Assert.IsType<ActionResult<CustomerSupportViewModel>>(data);
        }

        [Fact]
        public async void ShouldCall_Get_InvalidId_Return_AppException()
        {
            _custumerSupportService.Setup(x => x.GetAsync(It.IsAny<int>())).Throws<AppException>();

            var exception = Assert.ThrowsAsync<AppException>(async () => await _sut.Get(0));

        }


        [Fact]
        public async void Task_GetPostById_MatchResult()
        {
            //Arrange  
            //var controller = new PostController(repository);
            //int? postId = 1;

            ////Act  
            //var data = await controller.GetPost(postId);

            ////Assert  
            //Assert.IsType<OkObjectResult>(data);

            //var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            //var post = okResult.Value.Should().BeAssignableTo<PostViewModel>().Subject;

            //Assert.Equal("Test Title 1", post.Title);
            //Assert.Equal("Test Description 1", post.Description);
        }

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            //var controller = new PostController(repository);
            //var post = new Post() { Title = "Test Title 3", Description = "Test Description 3", CategoryId = 2, CreatedDate = DateTime.Now };

            ////Act  
            //var data = await controller.AddPost(post);

            ////Assert  
            //Assert.IsType<OkObjectResult>(data);
        }
        #endregion Methods

    }
}
