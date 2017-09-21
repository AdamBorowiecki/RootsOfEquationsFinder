using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsConsoleApp.View;
using Microsoft.EntityFrameworkCore;
using RootsOfEquations.DAL;
using RootsOfEquationsCalculator.DAL;

namespace RootsOfEquationsConsoleApp
{
    internal static class IoCConfiguration
    {
        public static WindsorContainer IocContainer { get; private set; }
        private static RootsOfEquationsDBContext context;

        static IoCConfiguration()
        {
            IocContainer = new WindsorContainer();
            ConfigureDBContext();
            ConfigureServices();
            ConfigureEquationsCalculatorWorkingWithDB();
        }

        private static void ConfigureDBContext()
        {
            var dbOptions = new DbContextOptionsBuilder<RootsOfEquationsDBContext>()
                 .UseInMemoryDatabase(databaseName: "Calculate_result")
                    .Options;

            context = new RootsOfEquationsDBContext(dbOptions);
        }

        private static void ConfigureServices()
        {
            IocContainer.Register(Component.For<IRootsOfEquationsService>().
                ImplementedBy<RootsOfEquationsService>().
                    DependsOn(
                          Dependency.OnValue("context", context)));
        }

        private static void ConfigureEquationsCalculatorWorkingWithDB()
        {
            ConfigureForDBCalcualtion<LinearEquationCalculatorDB, LinearEquationView>("1");
            ConfigureForDBCalcualtion<SquareEquationCalculatorDB, SquareEquationView>("2");
            ConfigureForDBCalcualtion<CubicEquationCalculatorDB, CubicEquationView>("3");
        }

        private static void ConfigureForDBCalcualtion<CalculatorType, ViewType>(string resolveKey)
            where CalculatorType : EquationCalculator
            where ViewType : EquationView
        {
            IocContainer.Register(
                Component.For<EquationCalculator>().
                    ImplementedBy<CalculatorType>().
                        LifestyleSingleton().
                            DependsOn(
                                Dependency.OnComponent<IRootsOfEquationsService, RootsOfEquationsService>()));

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<ViewType>().
                        Named(resolveKey).
                            DependsOn(
                                Dependency.OnComponent<EquationCalculator, CalculatorType>()));
        }
    }
}