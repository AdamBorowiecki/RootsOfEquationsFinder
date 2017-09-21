using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class SquareEquationCalculator : EquationCalculator
    {
        public override IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {//equation format: ax2 + bx + c = 0
            double a = equationsCoefficients.XToPower2;
            double b = equationsCoefficients.XToPower1;
            double c = equationsCoefficients.Constant;

            double delta = Math.Pow(b, 2) - 4 * a * c;

            if(delta > 0)
            {
                return TwoRoots(a, b, delta);
            }
            else if(delta == 0)
            {
                return OneRoot(a, b);
            }
            else//(delta < 0)
            {
                return new NoRealSolutions();
            }
        }

        private RootsValues TwoRoots(double a, double b, double delta)
        {
            List<double> roots = new List<double>();

            double root1 = (- b - Math.Sqrt(delta)) / (2 * a);
            roots.Add(root1);

            double root2 = (- b + Math.Sqrt(delta)) / (2 * a);
            roots.Add(root2);

            return new RootsValues(roots);
        }

        private RootsValues OneRoot(double a, double b)
        {
            return new RootsValues(- b / (2 * a));
        }
    }
}