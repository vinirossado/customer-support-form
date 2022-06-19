using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Domain;

namespace CustomerSupportAPI.Service.Implements
{
    public interface ICustomerSupportService
    {
        #region Methods
        Task<IEnumerable<CustomerSupportModel>> GetAll();
        Task<CustomerSupportModel> Get(int id);
        Task<CustomerSupportModel> Create(CustomerSupportDTO dto);
        Task<CustomerSupportModel> Update(CustomerSupportDTO dto);
        Task<bool> Delete(int id);
        #endregion
    }
}
