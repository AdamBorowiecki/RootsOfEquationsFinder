using RootsOfEquationsCalculator.EquationsTypes;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class LinearEquationTests
    {
        [Fact]
        public void CalculateRootsTests()
        {
            RootInformation infinitelyManySolutions = 
                RootInformation.InfinitelyManySolutions;
            Assert.Equal(
                infinitelyManySolutions, 
                LinearEquation.CalculateRoots(0.0, 0.0));

            RootInformation equationHasNotRoot =
                RootInformation.NoRealSolutions;
            Assert.Equal(
                equationHasNotRoot,
                LinearEquation.CalculateRoots(0.0, 5.0));

            double expectedResult = -2.5;
            Assert.Equal(
                expectedResult,
                LinearEquation.CalculateRoots(2.0, 5.0));
        }
    }
}