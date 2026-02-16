using Microsoft.EntityFrameworkCore;

namespace InsuranceCatApiDemo.Models
{
    public class InsuranceContext : DbContext
    {
        public InsuranceContext(DbContextOptions<InsuranceContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }
    }
}