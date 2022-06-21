using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Domain;

namespace CustomerSupportAPI.Service.Interfaces
{
    public interface ICustomerSupportService
    {
        #region Methods
        Task<IEnumerable<CustomerSupportModel>> GetAllAsync();
        Task<CustomerSupportModel> GetAsync(int id);
        Task<CustomerSupportModel> CreateAsync(CustomerSupportDTO dto);
        Task<CustomerSupportModel> UpdateAsync(CustomerSupportDTO dto);
        Task<bool> DeleteAsync(int id);
        #endregion
    }
}
