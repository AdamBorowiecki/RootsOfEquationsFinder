using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsConsoleApp.View;

namespace RootsOfEquationsConsoleApp
{
    internal static class IoCConfiguration
    {
        public static WindsorContainer IocContainer { get; }

        static IoCConfiguration()
        {
            IocContainer = new WindsorContainer();
            Configure();
        }

        private static void Configure()
        {
            ConfigurationForLinearEquation();
            ConfigurationForSquareEquation();
            ConfigurationForCubicEquation();
        }

        private static void ConfigurationForLinearEquation()
        {
            IocContainer.Register(
                Component.For<IEquationCalculator>().
                    ImplementedBy<LinearEquationCalculator>().
                        LifestyleSingleton());

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<LinearEquationView>().Named("1").
                        DependsOn(
                            Dependency.OnComponent<IEquationCalculator, LinearEquationCalculator>()));
        }

        private static void ConfigurationForSquareEquation()
        {
            IocContainer.Register(
                Component.For<IEquationCalculator>().
                    ImplementedBy<SquareEquationCalculator>().
                        LifestyleSingleton());

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<SquareEquationView>().Named("2").
                        DependsOn(
                            Dependency.OnComponent<IEquationCalculator, SquareEquationCalculator>()));
        }

        private static void ConfigurationForCubicEquation()
        {
            IocContainer.Register(
                Component.For<IEquationCalculator>().
                    ImplementedBy<CubicEquationCalculator>().
                        LifestyleSingleton());

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<CubicEquationView>().Named("3").
                        DependsOn(
                            Dependency.OnComponent<IEquationCalculator, CubicEquationCalculator>()));
        }
    }
}