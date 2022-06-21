using AutoMapper;
using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Domain;
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]
        public async Task<ActionResult<IEnumerable<CustomerSupportViewModel>>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all tickets");

                var result = await _customerSupportService.GetAllAsync();
                var entityMapped = _mapper.Map<IEnumerable<CustomerSupportViewModel>>(result);

                return Ok(entityMapped);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Has a problem to get all tickets");
                throw new Exception(ex.Message);
            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]

        public async Task<ActionResult<CustomerSupportViewModel>> Get([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("Get ticket {id}", id);

                var result = await _customerSupportService.GetAsync(id);

                var entityMapped = _mapper.Map<CustomerSupportViewModel>(result);

                return Ok(entityMapped);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Has a problem to get a ticket", id);
                throw new Exception(ex.Message);
            }

        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerSupportViewModel>> Create([FromBody] CustomerSupportDTO model)
        {
            if (ModelState.IsValid)
            {
                _logger.LogError("Has a problem to create a new customer support model is not valid", model);
                throw new AppException("Has a problem to create a new ticket, model is not valid");
            }
            try
            {
                var result = await _customerSupportService.CreateAsync(model);

                _logger.LogInformation("Ticket was created", result);

                var mappedCustomerSupport = _mapper.Map<CustomerSupportViewModel>(result);

                return Created("Create", mappedCustomerSupport);
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
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]

        public async Task<ActionResult<CustomerSupportViewModel>> Put([FromBody] CustomerSupportDTO dto)
        {
            try
            {
                _logger.LogInformation("Updating ticket", dto);

                var result = await _customerSupportService.UpdateAsync(dto);
                var entityMapped = _mapper.Map<CustomerSupportViewModel>(result);

                return Ok(entityMapped);

            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Has a problem to update ticket");
                throw new Exception(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status501NotImplemented)]

        public async Task<ActionResult<bool>> Delete([FromRoute] int id)
        {
            try
            {
                _logger.LogInformation("Starting delete Method", id);
                return await _customerSupportService.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, "Has a problem to delete ticket");
                throw new Exception(ex.Message);
            }

        }

        #endregion Methods

    }
}
