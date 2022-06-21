using AutoMapper;
using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Service.Interfaces;
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
        private readonly IMapper _mapper;
        private readonly ICustomerSupportService _customerSupportService;

        #endregion Properties

        #region Constructors
        public CustomerSupportController(ICustomerSupportService customerSupportService, ILogger<CustomerSupportController> logger, IMapper mapper)
        {
            _customerSupportService = customerSupportService;
            _logger = logger;
            _mapper = mapper;
        }
        #endregion Constructors

        #region Methods


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<CustomerSupportViewModel>>> GetAll()
        {
            _logger.LogInformation("Getting all tickets");

            var result = await _customerSupportService.GetAllAsync();
            var entityMapped = _mapper.Map<IEnumerable<CustomerSupportViewModel>>(result);

            return Ok(entityMapped);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerSupportViewModel>> Get([FromRoute] int id)
        {

            _logger.LogInformation("Get ticket {id}", id);

            var result = await _customerSupportService.GetAsync(id);

            var entityMapped = _mapper.Map<CustomerSupportViewModel>(result);

            return Ok(entityMapped);

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerSupportViewModel>> Create([FromBody] CustomerSupportCreateDTO model)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError("Has a problem to create a new customer support model is not valid", model);
                throw new AppException("Has a problem to create a new ticket, model is not valid");
            }

            var result = await _customerSupportService.CreateAsync(model);

            _logger.LogInformation("Ticket was created", result);

            var mappedCustomerSupport = _mapper.Map<CustomerSupportViewModel>(result);

            return Created("Create", mappedCustomerSupport);

        }

        [HttpPut]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerSupportViewModel>> Put([FromBody] CustomerSupportUpdateDTO dto)
        {
            _logger.LogInformation("Updating ticket", dto);

            var result = await _customerSupportService.UpdateAsync(dto);
            var entityMapped = _mapper.Map<CustomerSupportViewModel>(result);

            return Ok(entityMapped);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            _logger.LogInformation("Starting delete method", id);
            return await _customerSupportService.DeleteAsync(id);
        }

        #endregion Methods

    }
}
