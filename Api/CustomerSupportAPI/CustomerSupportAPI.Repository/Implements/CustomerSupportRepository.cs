using CustomerSupport.Infra.CrossCutting.Context;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Interfaces;

namespace CustomerSupportAPI.Repository.Implements
{
    public class CustomerSupportRepository : ICustomerSupportRepository
    {
        #region Properties
        private readonly CustomerSupportDbContext _context;
        #endregion Properties

        #region Constructors

        public CustomerSupportRepository(CustomerSupportDbContext context)
        {
            _context = context;
        }

        #endregion Constructors


        #region Methods

        public async Task<CustomerSupportModel> Create(CustomerSupportModel model)
        {
            await _context.CustomerSupport.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerSupportModel> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CustomerSupportModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerSupportModel> Update(CustomerSupportModel model)
        {
            throw new NotImplementedException();
        }

        #endregion Methods

    }
}
