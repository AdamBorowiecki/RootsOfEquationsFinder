using RootsOfEquationsCalculator.EquationsTypes;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class LinearEquationWithOneUnknownTests
    {
        [Fact]
        public void CalculateRootsTests()
        {
            RootInformation infinitelyManySolutions = 
                RootInformation.InfinitelyManySolutions;
            Assert.Equal(
                infinitelyManySolutions, 
                LinearEquationWithOneUnknown.CalculateRoots(0.0, 0.0, 0.0));
     
            Assert.Equal(
                infinitelyManySolutions,
                LinearEquationWithOneUnknown.CalculateRoots(0.0, 5.0, 5.0));

            RootInformation equationHasNotRoot =
                RootInformation.NoRoots;
            Assert.Equal(
                equationHasNotRoot,
                LinearEquationWithOneUnknown.CalculateRoots(0.0, 5.0, 2.0));

            double expectedResult = -2.5;
            Assert.Equal(
                expectedResult,
                LinearEquationWithOneUnknown.CalculateRoots(2.0, 5.0, 0.0));

        }
    }
}
