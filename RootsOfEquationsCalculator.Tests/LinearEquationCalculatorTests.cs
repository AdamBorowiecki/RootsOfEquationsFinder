using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class LinearEquationCalculatorTests
    {
        [Fact]
        public void When_AIsZeroAndBIsZero_Expect_InfinitelyManySolutions()
        {
            InfinitelyManySolutions infinitelyManySolutions =
                new InfinitelyManySolutions();
            LinearEquationCalculator linearEquation = new LinearEquationCalculator(0, 0);

            Assert.Equal(infinitelyManySolutions, linearEquation.CalculateRoots());
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(0, 2)]
        [InlineData(0, - 5)]
        public void When_AIsZeroAndBIsNotZero_Expect_NoRealSolutions(
            double a, double b)
        {
            NoRealSolutions noRealSolutions = new NoRealSolutions();;
            LinearEquationCalculator linearEquation = new LinearEquationCalculator(a, b);
        
            Assert.Equal(noRealSolutions, linearEquation.CalculateRoots());            
        }

        [Theory]
        [InlineData(-2.5, 2, 5)]
        [InlineData(2, 1, -2)]
        [InlineData(-0.5, 1.0/3, 1.0/6)]
        public void When_AIsZeroAndBIsNotZero_Expect_OneSolution(
            double expect, double a, double b)
        {
            RootsValues expectedValues = new RootsValues(expect);
            LinearEquationCalculator linearEquation = new LinearEquationCalculator(a, b);
            Assert.Equal(expectedValues, linearEquation.CalculateRoots());
        }
    }
}