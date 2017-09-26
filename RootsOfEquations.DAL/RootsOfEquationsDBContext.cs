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
    }
}