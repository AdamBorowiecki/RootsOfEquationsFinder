using Moq;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using System.Collections.Generic;
using Xunit;

namespace RootsOfEquationsCalculator.Tests.EquationCalculatorWorkingWithDBTests
{
    public class SquareEquationCalculatorWorkingWithDBTests
    {
        [Theory]
        [InlineData(1, 0.5, -2, 3, -1)]
        [InlineData(-3, 2, 2, 2, -12)]
        public void When_DeltaIsPossitive_Expect_ThisTwoRoots(
            double root1, double root2, double a, double b, double c)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c);
            RootsValues expectedRoots =
                new RootsValues(new List<double>() { root1, root2 });

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new SquareEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-0.5, 4, 4, 1)]
        [InlineData(-1, 2, 4, 2)]
        public void When_DeltaIsZero_Expect_OneRoot(
            double root, double a, double b, double c)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c);
            RootsValues expectedRoots = new RootsValues(root);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new SquareEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(1, 2, 4)]
        [InlineData(-4, 2, -5)]
        public void When_DeltaIsLessThanZero_Expect_NoRealSolution(
            double a, double b, double c)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c);
            NoRealSolutions noRealSolutions = new NoRealSolutions();

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(noRealSolutions.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new SquareEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), noRealSolutions.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }
    }
}