using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsConsoleApp.View;
using Microsoft.EntityFrameworkCore;
using RootsOfEquations.DAL;
using RootsOfEquationsCalculator.DAL;
using System;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

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
            ConfigureViewWithCalcualtor();
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

        private static void ConfigureViewWithCalcualtor()
        {
            var service = IocContainer.Resolve<IRootsOfEquationsService>();

            IocContainer.Register(
                Component.For<EquationView>().
                    Instance(new LinearEquationView(
                        new EquationCalculatorWithDB(service, new LinearEquationCalculator()))).Named("1"),
                Component.For<EquationView>().
                    Instance(new SquareEquationView(
                        new EquationCalculatorWithDB(service, new SquareEquationCalculator()))).Named("2"),
                Component.For<EquationView>().
                    Instance(new CubicEquationView(
                        new EquationCalculatorWithDB(service, new CubicEquationCalculator()))).Named("3"));
        }
    }
}