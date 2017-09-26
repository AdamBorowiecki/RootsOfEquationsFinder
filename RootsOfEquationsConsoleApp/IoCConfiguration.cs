using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsConsoleApp.View;
using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
using RootsOfEquations.DAL;
using RootsOfEquationsCalculator.DAL;

namespace RootsOfEquationsConsoleApp
{
    internal static class IoCConfiguration
    {
        public static WindsorContainer IocContainer { get; private set; }
        private static DbContext context;

        static IoCConfiguration()
        {
            IocContainer = new WindsorContainer();
            ConfigureDBContext();
            ConfigureServices();
            ConfigureViewWithCalcualtor();
        }

        private static void ConfigureDBContext()
        {
            //For InMemory database
            var dbOptions = new DbContextOptionsBuilder<RootsOfEquationsDBContext>()
                 .UseInMemoryDatabase(databaseName: "Calculate_result")
                    .Options;

            //Uncomment to use read database
            /*string connectionString =
                @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=ResultOfRootsCalculation;Integrated Security=True";
            var dbOptions = new DbContextOptionsBuilder<RootsOfEquationsDBContext>()
                 .UseSqlServer(connectionString)
                 .Options;*/

            context = new RootsOfEquationsDBContext(dbOptions);
        }

        private static void ConfigureServices()
        {
            IocContainer.Register(Component.For<IRootsOfEquationsService>().
                ImplementedBy<RootsOfEquationsService>().
                    DependsOn(
                          Dependency.OnValue("context", context)));
        }

        private static void ConfigureViewWithCalcualtor()
        {
            var service = IocContainer.Resolve<IRootsOfEquationsService>();

            IocContainer.Register(
                Component.For<EquationView>().
                    Instance(new LinearEquationView(
                        new EquationCalculatorWorkingWithDB(service, new LinearEquationCalculator()))).Named("1"),
                Component.For<EquationView>().
                    Instance(new SquareEquationView(
                        new EquationCalculatorWorkingWithDB(service, new SquareEquationCalculator()))).Named("2"),
                Component.For<EquationView>().
                    Instance(new CubicEquationView(
                        new EquationCalculatorWorkingWithDB(service, new CubicEquationCalculator()))).Named("3"));
        }
    }
}