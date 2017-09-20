using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquationsCalculator.DAL
{
    public class RootsOfEquationsDBContext : DbContext
    {
        public RootsOfEquationsDBContext()
        {

        }

        public RootsOfEquationsDBContext(DbContextOptions<RootsOfEquationsDBContext> options)
            : base(options)
        {

        }

        /*public DbSet<RootsCalculationResult> rootsCalculationResults { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase());

            services.AddMvc();
        }*/

    }
}
