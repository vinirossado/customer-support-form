using CustomerSupportAPI.Controllers;
using CustomerSupportAPI.Service.Implements;
using CustomerSupportAPI.Service.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CustomerSupportAPI.Tests
{
    [Trait("CustomerSupport", "CustomerSupportController")]
    public class CustomerSupportControllerTest
    {
        #region Properties
        private readonly Controllers.CustomerSupportController _sut;
        private readonly CustomerSupportService _custumerSupportService;
        private readonly ILogger<Controllers.CustomerSupportController> _custumerSupportLogger;
        #endregion Properties

        #region Constructors
        public CustomerSupportControllerTest()
        {
            //_sut = new Controllers.CustomerSupportController(_custumerSupportService, _custumerSupportLogger);

        }

        #endregion Constructors

        #region Methods
        [Fact]
        public void x()
        {

        }
        #endregion Methods

    }
}
