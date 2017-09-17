using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using System;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class CubicEquationCalculatorTests
    {
        [Theory]
        [InlineData(0, - 5, 8, - 6)]
        [InlineData(0, 2, 4, -6)]
        public void When_AValueIsZero_Expect_Exception_ThisEquationIsNotCubic(
             double a, double b, double c, double d)
        {
            CubicEquationCalculator cubicEquation = new CubicEquationCalculator(a, b, c, d);

            Assert.Throws<ArgumentException>(() => cubicEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(3, 1, -5, 8, -6)]
        public void When_ParameterHIsGreaterOrEqualsZero_Expect_SingleRoot(
            double rootValue, double a, double b, double c, double d)
        {
            RootsValues root = new RootsValues(rootValue);
            CubicEquationCalculator cubicEquation = new CubicEquationCalculator(a, b, c, d);

            Assert.Equal(root, cubicEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(2, 1, -6, 12, -8)]
        public void When_ParametersFAndGAreZero_Expect_TripleRoot(
            double rootValue, double a, double b, double c, double d)
        {
            RootsValues root = new RootsValues(rootValue);
            CubicEquationCalculator cubicEquation = new CubicEquationCalculator(a, b, c, d);

            Assert.Equal(root, cubicEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(3, 1, 2, 1, -6, 11, -6)]
        public void When_ParametersHIsLessThanZero_Expect_ThreeRoots(
            double root1, double root2, double root3,
            double a, double b, double c, double d)
        {
            RootsValues rootsValues = new RootsValues(root1, root2, root3);
            CubicEquationCalculator cubicEquation = new CubicEquationCalculator(a, b, c, d);

            Assert.Equal(rootsValues.Count(), cubicEquation.CalculateRoots().Count());
            Assert.Equal(rootsValues, cubicEquation.CalculateRoots());
        }
    }
}