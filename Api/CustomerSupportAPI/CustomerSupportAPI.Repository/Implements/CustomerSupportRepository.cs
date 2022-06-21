using CustomerSupport.Infra.CrossCutting.Context;
using CustomerSupportAPI.Domain;
using CustomerSupportAPI.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<CustomerSupportModel> CreateAsync(CustomerSupportModel model)
        {
            await _context.CustomerSupport.AddAsync(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> DeleteAsync(CustomerSupportModel model)
        {
            _context.CustomerSupport.Remove(model);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerSupportModel> GetAsync(int id)
        {
            var customerSupportDb = await _context.CustomerSupport.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync();
            return customerSupportDb;
        }

        public async Task<IEnumerable<CustomerSupportModel>> GetAllAsync()
        {
            return await _context.CustomerSupport.AsNoTracking().ToListAsync();
        }

        public async Task<CustomerSupportModel> UpdateAsync(CustomerSupportModel model)
        {
            _context.CustomerSupport.Update(model);
            await _context.SaveChangesAsync();
            return model;

        }

        #endregion Methods

    }
}
