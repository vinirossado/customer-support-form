using CustomerSupportAPI.Service.Implements;
using Microsoft.Extensions.Logging;
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
