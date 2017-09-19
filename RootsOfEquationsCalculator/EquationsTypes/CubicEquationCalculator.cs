using RootsOfEquationsCalculator.Mathematic;
using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class CubicEquationCalculator : IEquationCalculator
    {
        public IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {//equation format: ax3 + bx2 + cx + d ,  a ≠ 0
            double a = equationsCoefficients.XToPower3;
            double b = equationsCoefficients.XToPower2;
            double c = equationsCoefficients.XToPower1;
            double d = equationsCoefficients.Constant;

            if (Math.Abs(a) < double.Epsilon)
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
                return SingleRoot(a, b, g, h);
            }
            else if(Math.Abs(f) < double.Epsilon && Math.Abs(g) < double.Epsilon)
            {
                return TripleRoot(a, d);
            }
            else
            {
                return ThreeRoots(a, b, g, h);
            }
        }

        private RootsValues SingleRoot(double a, double b, double g, double h)
        {
            double root =
                (Operations.Power(-g / 2 + Math.Sqrt(h), Constants.ONE_THIRD_POWER)) +
                (Operations.Power(-g / 2 - Math.Sqrt(h), Constants.ONE_THIRD_POWER)) -
                (b / (3 * a));

            return new RootsValues(Operations.Round(root));
        }

        private RootsValues TripleRoot(double a, double d)
        {
            double root = - Operations.Power(d / a, Constants.ONE_THIRD_POWER);

            return new RootsValues(Operations.Round(root));
        }

        private RootsValues ThreeRoots(double a, double b, double g, double h)
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

            return new RootsValues(roots);
        }
    }
}