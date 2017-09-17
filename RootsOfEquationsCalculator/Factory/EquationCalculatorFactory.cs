using RootsOfEquationsCalculator.EquationsTypes;
using System;

namespace RootsOfEquationsCalculator.Factory
{
    public class EquationCalculatorFactory
    {
        public IEquationCalculator GetEquation(EquationsCoefficients equationFactors)
        {
            switch (ChooseEqualsType(equationFactors))
            {
                case EquationType.Linear:
                    return new LinearEquationCalculator(
                        equationFactors.XToPower1, 
                        equationFactors.Constant);
                case EquationType.Square:
                    return new SquareEquationCalculator(
                        equationFactors.XToPower2,
                        equationFactors.XToPower1, 
                        equationFactors.Constant);
                case EquationType.Cubic:
                    return new CubicEquationCalculator(
                        equationFactors.XToPower3,
                        equationFactors.XToPower2,
                        equationFactors.XToPower1,
                        equationFactors.Constant);
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