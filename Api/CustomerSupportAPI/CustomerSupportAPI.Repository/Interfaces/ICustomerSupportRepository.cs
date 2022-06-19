using CustomerSupport.Infra.CrossCutting.Dtos;
using CustomerSupportAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerSupportAPI.Repository.Interfaces
{
    public interface ICustomerSupportRepository
    {
        #region Methods
        Task<IEnumerable<CustomerSupportModel>> GetAll();
        Task<CustomerSupportModel> Get(int id);
        Task<CustomerSupportModel> Create(CustomerSupportModel model);
        Task<CustomerSupportModel> Update(CustomerSupportModel model);
        Task<bool> Delete(int id);
        #endregion
    }
}
