using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class SquareEquation
    {
        public static object CalculateRoots(
            double a,//unknown x to the second power factor
            double b,//unknown x to first power
            double c)//const
        {//equation format: ax2 + bx + c = 0
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
                return RootInformation.NoRealSolutions;
            }
        }

        private static List<double> TwoRoots(double a, double b, double delta)
        {
            List<double> roots = new List<double>();

            double root1 = (- b - Math.Sqrt(delta)) / (2 * a);
            roots.Add(root1);

            double root2 = (- b + Math.Sqrt(delta)) / (2 * a);
            roots.Add(root2);

            return roots;
        }

        private static double OneRoot(double a, double b)
        {
            return - b / (2 * a);
        }
    }
}