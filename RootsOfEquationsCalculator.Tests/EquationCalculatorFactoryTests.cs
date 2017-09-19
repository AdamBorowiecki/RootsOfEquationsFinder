using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Factory;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class EquationCalculatorFactoryTests
    {
        /*[Theory]
        [InlineData(0, 0, 0, 0)]
        [InlineData(0, 0, 2, 1)]
        [InlineData(0, 0, 0, 1)]
        [InlineData(0, 0, 3, 0)]
        public void When_ParametersHasValuesAbove_Expect_LinearEquationCalculator(
            double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            EquationCalculatorFactory factory = new EquationCalculatorFactory();
            Assert.IsType<LinearEquationCalculator>(factory.GetEquation(coefficients));
        }

        [Theory]
        [InlineData(0, 2, 0, 0)]
        [InlineData(0, 3, 2, 1)]
        [InlineData(0, 4, 0, 1)]
        [InlineData(0, 5, 3, 0)]
        public void When_ParametersHasValuesAbove_Expect_SquareEquationCalculator(
            double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            EquationCalculatorFactory factory = new EquationCalculatorFactory();
            Assert.IsType<SquareEquationCalculator>(factory.GetEquation(coefficients));
        }

        [Theory]
        [InlineData(2, 2, 3, 1)]
        [InlineData(4, 0, 2, 1)]
        [InlineData(1, 0, 0, 1)]
        [InlineData(3, 0, 0, 0)]
        public void When_ParametersHasValuesAbove_Expect_CubicEquationCalculator(
            double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            EquationCalculatorFactory factory = new EquationCalculatorFactory();
            Assert.IsType<CubicEquationCalculator>(factory.GetEquation(coefficients));
        }*/
    }
}