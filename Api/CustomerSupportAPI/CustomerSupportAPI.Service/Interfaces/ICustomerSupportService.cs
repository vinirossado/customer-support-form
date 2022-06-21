using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Domain;

namespace CustomerSupportAPI.Service.Interfaces
{
    public interface ICustomerSupportService
    {
        #region Methods
        Task<IEnumerable<CustomerSupportModel>> GetAllAsync();
        Task<CustomerSupportModel> GetAsync(int id);
        Task<CustomerSupportModel> CreateAsync(CustomerSupportCreateDTO dto);
        Task<CustomerSupportModel> UpdateAsync(CustomerSupportUpdateDTO dto);
        Task<bool> DeleteAsync(int id);
        #endregion
    }
}
