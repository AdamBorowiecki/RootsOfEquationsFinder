using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class LinearEquationCalculator : EquationCalculator
    {
        public override IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {
            double a = equationsCoefficients.XToPower1;
            double b = equationsCoefficients.Constant;

            if (a.Equals(0.0) && b.Equals(0.0))
            {
                return new InfinitelyManySolutions();
            }

            if (a.Equals(0.0))
            {
                return new NoRealSolutions();
            }

            return new RootsValues(-b / a);
        }
    }
}