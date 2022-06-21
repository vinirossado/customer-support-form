using CustomerSupport.Infra.CrossCutting.Context;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportRepositoryTest")]
    public class CustomerSupportRepositoryTest
    {

        #region Properties
        private readonly CustomerSupportRepository _sut;
        private readonly Mock<CustomerSupportDbContext> _mockContext;
        private readonly Mock<DbSet<CustomerSupportModel>> _dbSet;
        private readonly Mock<IConfiguration> _configuration;
        private readonly Mock<DbContextOptions<CustomerSupportDbContext>> _options;
        #endregion Properties

        #region Constructors
        public CustomerSupportRepositoryTest()
        {
            _configuration = new Mock<IConfiguration>();
            _options = new Mock<DbContextOptions<CustomerSupportDbContext>>();
            _dbSet = new Mock<DbSet<CustomerSupportModel>>();
            _mockContext = new Mock<CustomerSupportDbContext>(_configuration.Object, _options.Object);
            _sut = new CustomerSupportRepository(_mockContext.Object);

        }
        #endregion Constructors

        #region Methods

        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            ////Arrange  
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
