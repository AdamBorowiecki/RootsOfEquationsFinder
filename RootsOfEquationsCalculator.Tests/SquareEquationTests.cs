using RootsOfEquationsCalculator.EquationsTypes;
using System.Collections.Generic;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class SquareEquationTests
    {
        [Fact]
        public void CalculateRootsTests()
        {
            int twoNumberOfRoots = 2;
            List<double> twoRootsResult =
                (List<double>)SquareEquation.CalculateRoots(-2, 3, -1);
            Assert.Equal(twoNumberOfRoots, twoRootsResult.Count);

            double firstRoot = 1;
            double secondRoot = 0.5;
            Assert.Equal(firstRoot, twoRootsResult[0]);
            Assert.Equal(secondRoot, twoRootsResult[1]);

            double singleRoot = - 0.5;
            Assert.Equal(singleRoot, SquareEquation.CalculateRoots(4, 4, 1));

            RootInformation noRealSolutions = RootInformation.NoRealSolutions;
            Assert.Equal(noRealSolutions, SquareEquation.CalculateRoots(1, 2, 4));
        }
    }
}