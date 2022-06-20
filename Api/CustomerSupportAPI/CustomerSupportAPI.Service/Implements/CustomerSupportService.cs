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

        public async Task<CustomerSupportModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerSupportModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerSupportModel> Create(CustomerSupportDTO dto)
        {
            var model = new CustomerSupportModel(dto.Id.GetValueOrDefault(), dto.Email, dto.Phone, dto.Number, (int)dto.TypeInquiry, dto.Description, dto.AgreementTerms);
            throw new Exception();
            //return await _customerSupportRepository.Create(model);
        }

        public Task<CustomerSupportModel> Update(CustomerSupportDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion Methods
    }
}
