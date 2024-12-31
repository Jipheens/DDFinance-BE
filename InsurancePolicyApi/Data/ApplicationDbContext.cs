using Microsoft.EntityFrameworkCore;
using InsurancePolicyApi.Models;


namespace InsurancePolicyApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }
    }
}