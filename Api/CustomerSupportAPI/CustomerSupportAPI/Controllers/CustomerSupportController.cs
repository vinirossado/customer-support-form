using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Service.Implements;
using CustomerSupportAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CustomerSupportAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSupportController : ControllerBase
    {
        #region Properties
        private readonly ILogger _logger;
        private readonly ICustomerSupportService _customerSupportService;

        #endregion Properties

        #region Constructors
        public CustomerSupportController(ICustomerSupportService customerSupportService, ILogger<CustomerSupportController> logger)
        {
            _customerSupportService = customerSupportService;
            _logger = logger;
        }
        #endregion Constructors

        #region Methods


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public string Get([FromRoute] int id)
        {
            return "value";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerSupportViewModel>> Post([FromBody] CustomerSupportDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Has a problem to create a new customer support model is not valid", model);
                return BadRequest();
            }
            try
            {
                var result = await _customerSupportService.Create(model);
                return CreatedAtAction("Post", result);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Has a problem to create a new customer support");
                throw new Exception(ex.Message);
            }

        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerSupportViewModel>> Put([FromBody] CustomerSupportDTO model)
        {
            return Ok(new CustomerSupportViewModel());
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            return true;
        }

        #endregion Methods

    }
}
