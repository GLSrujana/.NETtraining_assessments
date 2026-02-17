using Microsoft.EntityFrameworkCore;

namespace InsuranceCatAPIDemo.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        public DbSet<InsuranceCategory> InsuranceCategories { get; set; }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    }
}
