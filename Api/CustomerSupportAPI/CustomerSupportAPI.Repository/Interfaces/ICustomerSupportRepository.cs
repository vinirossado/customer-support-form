using CustomerSupportAPI.Domain;

namespace CustomerSupportAPI.Repository.Interfaces
{
    public interface ICustomerSupportRepository
    {
        #region Methods
        Task<IEnumerable<CustomerSupportModel>> GetAllAsync();
        Task<CustomerSupportModel> GetAsync(int id);
        Task<CustomerSupportModel> CreateAsync(CustomerSupportModel model);
        Task<CustomerSupportModel> UpdateAsync(CustomerSupportModel model);
        Task<bool> DeleteAsync(CustomerSupportModel model);
        #endregion
    }
}
