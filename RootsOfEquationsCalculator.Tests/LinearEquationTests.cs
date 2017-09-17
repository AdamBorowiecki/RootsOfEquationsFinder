using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class LinearEquationTests
    {
        [Fact]
        public void When_AIsZeroAndBIsZero_Expect_InfinitelyManySolutions()
        {
            InfinitelyManySolutions infinitelyManySolutions =
                new InfinitelyManySolutions();
            LinearEquation linearEquation = new LinearEquation(0, 0);

            Assert.Equal(infinitelyManySolutions, linearEquation.CalculateRoots());
        }

        //todo: add inlinedata here
        [Theory]
        [InlineData(0, 5)]
        [InlineData(0, 2)]
        [InlineData(0, - 5)]
        public void When_AIsZeroAndBIsNotZero_Expect_NoRealSolutions(
            double a, double b)
        {
            NoRealSolutions noRealSolutions = new NoRealSolutions();;
            LinearEquation linearEquation = new LinearEquation(a, b);
        
            Assert.Equal(noRealSolutions, linearEquation.CalculateRoots());            
        }

        //todo: add more inline data
        [Theory]
        [InlineData(-2.5, 2, 5)]
        public void When_AIsZeroAndBIsNotZero_Expect_OneSolution(
            double expect, double a, double b)
        {
            RootsValues expectedValues = new RootsValues(expect);
            LinearEquation linearEquation = new LinearEquation(a, b);
            Assert.Equal(expectedValues, linearEquation.CalculateRoots());
        }
    }
}