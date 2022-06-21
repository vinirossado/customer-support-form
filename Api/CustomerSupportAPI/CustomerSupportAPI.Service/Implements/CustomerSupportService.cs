using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupport.Infra.CrossCutting.ErrorHandling;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Interfaces;
using CustomerSupportAPI.Service.Interfaces;

namespace CustomerSupportAPI.Service.Implements
{
    public class CustomerSupportService : ICustomerSupportService
    {
        #region Properties
        private readonly ICustomerSupportRepository _customerSupportRepository;

        #endregion Properties

        #region Constructors
        public CustomerSupportService(ICustomerSupportRepository customerSupportRepository)
        {
            _customerSupportRepository = customerSupportRepository;
        }
        #endregion Constructors

        #region Methods

        public async Task<CustomerSupportModel> GetAsync(int id)
        {
            if (id == 0)
            {
                throw new AppException("It's necessary to inform a valid Id");
            }
            var ticketDb = await _customerSupportRepository.GetAsync(id);

            if (ticketDb == null)
            {
                throw new KeyNotFoundException("Id not found any ticket");
            }

            return ticketDb;
        }

        public async Task<IEnumerable<CustomerSupportModel>> GetAllAsync()
        {
            return await _customerSupportRepository.GetAllAsync();
        }

        public async Task<CustomerSupportModel> CreateAsync(CustomerSupportDTO dto)
        {
            var model = new CustomerSupportModel(dto.Id.GetValueOrDefault(),
                                                 dto.Email,
                                                 dto.Phone,
                                                 dto.Number,
                                                 (int)dto.TypeInquiry,
                                                 dto.Description,
                                                 dto.AgreementTerms);

            return await _customerSupportRepository.CreateAsync(model);
        }

        public async Task<CustomerSupportModel> UpdateAsync(CustomerSupportDTO dto)
        {
            var ticketDb = await GetAsync(dto.Id.GetValueOrDefault());
            ticketDb.UpdateEntity(dto.Id.GetValueOrDefault(), dto.Email, dto.Phone, dto.Number, (int)dto.TypeInquiry, dto.Description, dto.AgreementTerms);
            return await _customerSupportRepository.UpdateAsync(ticketDb);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var ticketDb = await GetAsync(id);

            if (ticketDb == null)
            {
                throw new KeyNotFoundException("Id not found any ticket");
            }

            return await _customerSupportRepository.DeleteAsync(ticketDb);
        }

        #endregion Methods
    }
}
