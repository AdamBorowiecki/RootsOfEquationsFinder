using Microsoft.EntityFrameworkCore;
using RootsOfEquationsCalculator.DAL;

namespace RootsOfEquations.DAL
{
    public class RootsOfEquationsDBContext : DbContext
    {
        public RootsOfEquationsDBContext(DbContextOptions<RootsOfEquationsDBContext> options)
            : base(options)
        {

        }

        public DbSet<ResultOfRootsCalculation> ResultOfRootsCalculations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFProviders.InMemory;Trusted_Connection=True;");
            }
        }
    }
}