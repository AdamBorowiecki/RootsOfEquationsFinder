using RootsOfEquationsCalculator.EquationsTypes;
using System;

namespace RootsOfEquationsCalculator.Factory
{
    public class EquationFactory
    {
        public IEquation GetEquation(EquationsCoefficients equationFactors)
        {
            switch (ChooseEqualsType(equationFactors))
            {
                case EquationType.Linear:
                    return new LinearEquation(
                        equationFactors.XToPower1, equationFactors.Constant);
                case EquationType.Square:
                    return new SquareEquation(
                        equationFactors.XToPower2,
                        equationFactors.XToPower1, 
                        equationFactors.Constant);
                case EquationType.Cubic:
                    return new CubicEquation(
                        equationFactors.XToPower3,
                        equationFactors.XToPower2,
                        equationFactors.XToPower1,
                        equationFactors.Constant);
                default:
                    throw new NotSupportedException();
            }
        }

        //todo: condition should be more specific?
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