using CustomerSupportAPI.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomerSupport.Infra.CrossCutting.Context
{
    public partial class CustomerSupportDbContext : DbContext
    {
        #region Properties
        protected readonly IConfiguration _configuration;
        #endregion Properties

        #region Constructors
        public CustomerSupportDbContext(IConfiguration configuration, DbContextOptions<CustomerSupportDbContext> options) : base(options)
        {
            _configuration = configuration;
        }
        #endregion Constructors

        #region Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename = CustumerSupport.db");
        }
        public virtual DbSet<CustomerSupportModel> CustomerSupport { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerSupportModel>().ToTable("CustomerSupport");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion Methods

    }
}
