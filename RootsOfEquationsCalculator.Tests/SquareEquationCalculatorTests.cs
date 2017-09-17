using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using System.Collections.Generic;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class SquareEquationCalculatorTests
    {
        [Theory]
        [InlineData(2, -2, 3, -1)]
        public void When_DeltaIsPossitive_Expect_TwoSoultion(
            int numberOfSolutions, double a, double b, double c)
        {
            SquareEquationCalculator squareEquation = new SquareEquationCalculator(a, b, c);

            Assert.Equal(
                numberOfSolutions,
                squareEquation.CalculateRoots().Count());
        }

        [Theory]
        [InlineData(1, 0.5, -2, 3, -1)]
        public void When_DeltaIsPossitive_Expect_ThisTwoRoots(
            double root1, double root2, double a, double b, double c)
        {
            RootsValues rootsValues = 
                new RootsValues(new List<double>() { root1, root2});
            SquareEquationCalculator squareEquation = new SquareEquationCalculator(a, b, c);

            Assert.Equal(rootsValues, squareEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(- 0.5, 4, 4, 1)]
        public void When_DeltaIsZero_Expect_OneRoot(
            double root, double a, double b, double c)
        {
            RootsValues rootsValues = new RootsValues(- 0.5);
            SquareEquationCalculator squareEquation = new SquareEquationCalculator(a, b, c);

            Assert.Equal(rootsValues, squareEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(1, 2, 4)]
        public void When_DeltaIsLessThanZero_Expect_NoRealSolution(
            double a, double b, double c)
        {
            NoRealSolutions noRealSolutions = new NoRealSolutions();
            SquareEquationCalculator squareEquation = new SquareEquationCalculator(a, b, c);

            Assert.Equal(noRealSolutions, squareEquation.CalculateRoots());
        }
    }
}