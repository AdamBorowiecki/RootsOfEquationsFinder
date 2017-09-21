using System;
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
            //ConfigureEquations();
            ConfigureEquationsDB();
            //ConfigureEquationsForDB();
        }

        private static void ConfigureDBContext()
        {
            var dbOptions = new DbContextOptionsBuilder<RootsOfEquationsDBContext>()
                 .UseInMemoryDatabase(databaseName: "Calculate_result")
                    .Options;

            context = new RootsOfEquationsDBContext(dbOptions);
            /*IocContainer.Register(Component.For<DbContext>().
                ImplementedBy<RootsOfEquationsDBContext>().
                        LifestyleSingleton().
                            DependsOn(Dependency.
                                OnValue("options", dbOptions)));*/
        }

        private static void ConfigureServices()
        {
            IocContainer.Register(Component.For<IRootsOfEquationsService>().
                ImplementedBy<RootsOfEquationsService>().
                    DependsOn(
                          //Dependency.OnComponent<DbContext, RootsOfEquationsDBContext>()));
                          Dependency.
                                OnValue("context", context)));
        }

        private static void ConfigureEquationsForDB()
        {
            ConfigureForEquationCalculatorWithDB<LinearEquationCalculator, LinearEquationView>("1");
            ConfigureForEquationCalculatorWithDB<SquareEquationCalculator, SquareEquationView>("2");
            ConfigureForEquationCalculatorWithDB<CubicEquationCalculator, CubicEquationView>("3");
        }

        private static void ConfigureForEquationCalculatorWithDB<CalculatorType, ViewType>(string resolveKey)
            where CalculatorType : EquationCalculator
            where ViewType : EquationView
        {
            IocContainer.Register(
                Component.For<EquationCalculator>().
                    ImplementedBy<CalculatorType>().
                        LifestyleSingleton().
                            DependsOn(
                                Dependency.OnComponent<IRootsOfEquationsService, RootsOfEquationsService>(),
                                Dependency.OnComponent<EquationCalculator, CalculatorType>()));

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<ViewType>().
                        Named(resolveKey).
                            DependsOn(
                                Dependency.OnComponent<EquationCalculator, CalculatorType>()));
        }

        private static void ConfigureEquationsDB()
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

        /*private static void ConfigureEquations()
        {
            ConfigureFor<LinearEquationCalculator, LinearEquationView>("1");
            ConfigureFor<SquareEquationCalculator, SquareEquationView>("2");
            ConfigureFor<CubicEquationCalculator, CubicEquationView>("3");
        }

        private static void ConfigureFor<CalculatorType, ViewType>(string resolveKey)
            where CalculatorType : EquationCalculator
            where ViewType : EquationView
        {
            IocContainer.Register(
                Component.For<EquationCalculator>().
                    ImplementedBy<CalculatorType>().
                        LifestyleSingleton());

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<ViewType>().
                        Named(resolveKey).
                            DependsOn(
                                Dependency.OnComponent<EquationCalculator, CalculatorType>()));
        }*/
    }
}