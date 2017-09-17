using RootsOfEquationsCalculator.EquationsTypes;
using System;

namespace RootsOfEquationsCalculator.Factory
{
    public class EquationCalculatorFactory
    {
        public IEquationCalculator GetEquation(EquationsCoefficients coefficients)
        {
            switch (ChooseEqualsType(coefficients))
            {
                case EquationType.Linear:
                    return new LinearEquationCalculator(
                        coefficients.XToPower1, 
                        coefficients.Constant);
                case EquationType.Square:
                    return new SquareEquationCalculator(
                        coefficients.XToPower2,
                        coefficients.XToPower1, 
                        coefficients.Constant);
                case EquationType.Cubic:
                    return new CubicEquationCalculator(
                        coefficients.XToPower3,
                        coefficients.XToPower2,
                        coefficients.XToPower1,
                        coefficients.Constant);
                default:
                    throw new NotSupportedException();
            }
        }

        private EquationType ChooseEqualsType(EquationsCoefficients equationFactors)
        {
            if (equationFactors.XToPower3 == 0 &&
               equationFactors.XToPower2 == 0)
                return EquationType.Linear;

            if (equationFactors.XToPower3 == 0)
                return EquationType.Square;

            return EquationType.Cubic;
        }
    }
}