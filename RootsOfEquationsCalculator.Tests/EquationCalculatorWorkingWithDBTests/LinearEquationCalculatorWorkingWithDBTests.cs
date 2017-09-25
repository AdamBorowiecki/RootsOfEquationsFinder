using Moq;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using Xunit;

namespace RootsOfEquationsCalculator.Tests.EquationCalculatorWorkingWithDBTests
{
    public class LinearEquationCalculatorWorkingWithDBTests
    {
        [Fact]
        public void When_AIsZeroAndBIsZero_Expect_InfinitelyManySolutions()
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(0, 0);
            InfinitelyManySolutions infinitelyManySolutions =
                new InfinitelyManySolutions();

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(infinitelyManySolutions.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new LinearEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(true, infinitelyManySolutions.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));
            mockService.Verify(m => m.Add(null, null), Times.Never());

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 5)]
        [InlineData(0, 2)]
        [InlineData(0, -5)]
        public void When_AIsZeroAndBIsNotZero_Expect_NoRealSolutions(
            double a, double b)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b);
            NoRealSolutions noRealSolutions = new NoRealSolutions();

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(noRealSolutions.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new LinearEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), noRealSolutions.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-2.5, 2, 5)]
        [InlineData(2, 1, -2)]
        [InlineData(-0.5, 1.0 / 3, 1.0 / 6)]
        public void When_AIsZeroAndBIsNotZero_Expect_OneSolution(
            double expect, double a, double b)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(0, 0);
            RootsValues expectedValues = new RootsValues(expect);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedValues.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new LinearEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedValues.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }
    }
}