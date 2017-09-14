using RootsOfEquationsCalculator.EquationsTypes;
using System;
using System.Collections.Generic;
using Xunit;

namespace RootsOfEquationsCalculator.Tests
{
    public class CubicEquationTests
    {
        [Fact]
        public void CalculateRootsTests()
        {
            double aValueCauseEquationIsNotCubic = 0;
            double b = - 5;
            double c = 8;
            double d = - 6;
            Assert.Throws<ArgumentException>(
                () => CubicEquation.CalculateRoots(aValueCauseEquationIsNotCubic, b, c, d));

            double oneRoot = 3;
            Assert.Equal(
                oneRoot,
                CubicEquation.CalculateRoots(1, -5, 8, - 6));

            double tripleRoot = 2;
            Assert.Equal(tripleRoot, CubicEquation.CalculateRoots(1, -6, 12, -8));

            double aArgument = 1;
            double bArgument = - 6;
            double cArgument = 11;
            double dArgument = - 6;

            object roots = CubicEquation.CalculateRoots(
                    aArgument, bArgument, cArgument, dArgument);
            List<double> castedRoots = (List<double>)roots;

            int numberOfRoots = 3;
            Assert.Equal(numberOfRoots, castedRoots.Count);

            double firstRoot = 3;
            Assert.Equal(firstRoot, castedRoots[0]);
            double secondRoot = 1;
            Assert.Equal(secondRoot, castedRoots[1]);
            double thirdRoot = 2;
            Assert.Equal(thirdRoot, castedRoots[2]);

        }
    }
}