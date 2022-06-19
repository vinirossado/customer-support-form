using CustomerSupport.Infra.CrossCutting.Context;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Implements;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportRepositoryTest")]
    public class CustomerSupportRepositoryTest
    {

        #region Properties
        private readonly CustomerSupportRepository _sut;
        private readonly Mock<CustomerSupportDbContext> mockContext;
        private readonly Mock<DbSet<CustomerSupportModel>> dbSet;
        #endregion Properties

        #region Constructors
        public CustomerSupportRepositoryTest()
        {
            dbSet = new Mock<DbSet<CustomerSupportModel>>();
            mockContext = new Mock<CustomerSupportDbContext>();
            _sut = new CustomerSupportRepository(mockContext.Object);

        }
        #endregion Constructors

        #region Methods

       
        #endregion Methods
    }
}
