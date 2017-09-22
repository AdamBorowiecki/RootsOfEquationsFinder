//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator;
//using Microsoft.Data.Entity;
//using Microsoft.Data.Entity.Infrastructure;

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