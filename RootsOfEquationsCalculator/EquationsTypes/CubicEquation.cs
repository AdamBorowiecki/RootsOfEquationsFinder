using RootsOfEquationsCalculator.Mathematic;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public static class CubicEquation
    {
        public static object CalculateRoots(
            double a,//unknown x to the third power factor
            double b,//unknown x to the second power factor
            double c,//unknown X to the first power factor
            double d//constant
            )//equation format: ax3 + bx2 + cx + d ,  a ≠ 0
        {
            if(Math.Abs(a) < double.Epsilon)
            {
                throw new ArgumentException(
                    $"{nameof(a)} has value = {a} - it is not cubic equation");
            }

            double f = (c / a) - (Math.Pow(b, 2) / (3 * Math.Pow(a, 2)));
            double g = 
                (2 * Math.Pow(b, 3)) / (27 * Math.Pow(a, 3)) -
                (b * c) / (3 * Math.Pow(a, 2)) +
                d / a;
            double h =
                (Math.Pow(g, 2) / 4) +
                (Math.Pow(f, 3) / 27);

            if(h >= double.Epsilon)
            {
                return Operations.Round(OnlyOneRoot(a, b, g, h));
            }
            else if(Math.Abs(f) < double.Epsilon && Math.Abs(g) < double.Epsilon)
            {
                return Operations.Round(TripleRoot(a, d));
            }
            else
            {
                return ThreeRoots(a, b, g, h);
            }
        }

        private static double OnlyOneRoot(double a, double b, double g, double h)
        {
            return
                (Math.Pow(-g / 2 + Math.Sqrt(h), Constants.ONE_THIRD_POWER)) +
                (Math.Pow(-g / 2 - Math.Sqrt(h), Constants.ONE_THIRD_POWER)) -
                (b / (3 * a));
        }

        private static double TripleRoot(double a, double d)
        {
            return  -Operations.Power(d / a, Constants.ONE_THIRD_POWER);
        }

        private static List<double> ThreeRoots(double a, double b, double g, double h)
        {
            double i = Math.Sqrt((Math.Pow(g, 2) / 4) - h);
            double j = Operations.Power(i, Constants.ONE_THIRD_POWER);
            double k = Math.Acos(- (g / (2 * i)));
            double m = Math.Cos(k / 3);
            double n = Math.Sqrt(3) * Math.Sin(k / 3);
            double p = -b / 3 * a;

            List<double> roots = new List<double>();

            double root1 = 2 * j * m + p; 
            roots.Add(Operations.Round(root1));

            double root2 = -j * (m + n) + p;
            roots.Add(Operations.Round(root2));

            double root3 = -j * (m - n) + p;
            roots.Add(Operations.Round(root3));

            return roots;
        }
    }
}