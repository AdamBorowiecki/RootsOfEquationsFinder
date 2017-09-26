using Moq;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using Xunit;

namespace RootsOfEquationsCalculator.Tests.EquationCalculatorWorkingWithDBTests
{
    public class EquationCalculatorWorkingWithDBTests
    {
        [Theory]
        [InlineData(-2.5, 2, 5)]
        [InlineData(2, 1, -2)]
        [InlineData(-0.5, 1.0 / 3, 1.0 / 6)]
        public void When_AboveParameters_Expect_ResultNotCalculatedBefore(
            double expect, double a, double b)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b);
            RootsValues expectedRoots = new RootsValues(expect);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(false);
            mockService.Setup(x => x.Add(coefficients, expectedRoots));
            IRootsOfEquationsService service = mockService.Object;

            Mock<EquationCalculator> mockCalculator = new Mock<EquationCalculator>();
            mockCalculator.Setup(x => x.CalculateRoots(coefficients)).Returns(expectedRoots);
            EquationCalculator calculator = mockCalculator.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, calculator);

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(false, expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.Add(coefficients, expectedRoots));
            mockService.Verify(m => m.ReadResult(null), Times.Never);

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-2.5, 2, 5)]
        [InlineData(2, 1, -2)]
        [InlineData(-0.5, 1.0 / 3, 1.0 / 6)]
        public void When_AboveParameters_Expect_ResultCalculatedBefore(
            double expect, double a, double b)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b);
            RootsValues expectedRoots = new RootsValues(expect);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            Mock<EquationCalculator> mockCalculator = new Mock<EquationCalculator>();
            mockCalculator.Setup(x => x.CalculateRoots(coefficients)).Returns(expectedRoots);
            EquationCalculator calculator = mockCalculator.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, calculator);

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(true, expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));
            mockService.Verify(m => m.Add(null, null), Times.Never);

            Assert.Equal(expectedResult, actualResult);
        }
    }
}