using Castle.MicroKernel.Registration;
using Castle.Windsor;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsConsoleApp.View;

namespace RootsOfEquationsConsoleApp
{
    internal static class IoCConfiguration
    {
        public static WindsorContainer IocContainer { get; private set; }

        static IoCConfiguration()
        {         
            Configure();
        }

        private static void Configure()
        {
            IocContainer = new WindsorContainer();
            ConfigureFor<LinearEquationCalculator, LinearEquationView>("1");
            ConfigureFor<SquareEquationCalculator, SquareEquationView>("2");
            ConfigureFor<CubicEquationCalculator, CubicEquationView>("3");
        }

        private static void ConfigureFor<CalculatorType, ViewType>(string resolveKey)
            where CalculatorType : IEquationCalculator
            where ViewType : EquationView
        {
            IocContainer.Register(
                Component.For<IEquationCalculator>().
                    ImplementedBy<CalculatorType>().
                        LifestyleSingleton());

            IocContainer.Register(
                Component.For<EquationView>().
                    ImplementedBy<ViewType>().
                        Named(resolveKey).
                            DependsOn(
                                Dependency.OnComponent<IEquationCalculator, CalculatorType>()));
        }
    }
}