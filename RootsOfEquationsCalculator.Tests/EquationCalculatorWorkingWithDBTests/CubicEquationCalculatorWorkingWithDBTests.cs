using Moq;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using Xunit;

namespace RootsOfEquationsCalculator.Tests.EquationCalculatorWorkingWithDBTests
{
    public class CubicEquationCalculatorWorkingWithDBTests
    {
        [Theory]
        [InlineData(3, 1, -5, 8, -6)]
        [InlineData(0.8488294715, 3, -6, 10, -6)]
        public void When_ParameterHIsGreaterOrEqualsZero_Expect_SingleRoot(
            double rootValue, double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            RootsValues expectedRoots = new RootsValues(rootValue);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new CubicEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(2, 1, -6, 12, -8)]
        public void When_ParametersFAndGAreZero_Expect_TripleRoot(
            double rootValue, double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            RootsValues expectedRoots = new RootsValues(rootValue);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new CubicEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(3, 1, 2, 1, -6, 11, -6)]
        public void When_ParametersHIsLessThanZero_Expect_ThreeRoots(
            double root1, double root2, double root3,
            double a, double b, double c, double d)
        {
            EquationsCoefficients coefficients = new EquationsCoefficients(a, b, c, d);
            RootsValues expectedRoots = new RootsValues(root1, root2, root3);

            Mock<IRootsOfEquationsService> mockService = new Mock<IRootsOfEquationsService>();
            mockService.Setup(x => x.IsCalcualtedBefore(coefficients)).Returns(true);
            mockService.Setup(x => x.ReadResult(coefficients)).Returns(expectedRoots.ToString());
            IRootsOfEquationsService service = mockService.Object;

            EquationCalculatorWorkingWithDB calculatorWorkingWithDB =
                new EquationCalculatorWorkingWithDB(service, new CubicEquationCalculator());

            RootsResultFromDB expectedResult =
                new RootsResultFromDB(service.IsCalcualtedBefore(coefficients), expectedRoots.ToString());

            IRootsResult actualResult = calculatorWorkingWithDB.CalculateRoots(coefficients);

            mockService.Verify(m => m.IsCalcualtedBefore(coefficients));
            mockService.Verify(m => m.ReadResult(coefficients));

            Assert.Equal(expectedResult, actualResult);
        }
    }
}
