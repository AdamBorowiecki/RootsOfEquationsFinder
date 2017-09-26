using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.EquationsTypes;
using System;

namespace RootsOfEquationsConsoleApp.View
{
    internal class CubicEquationView : EquationView
    {
        public CubicEquationView(EquationCalculator equationCalculator)
        {
            base.equationCalculator = equationCalculator;
        }

        internal override EquationsCoefficients ReadParameters()
        {
            Console.Write("Factor a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Factor b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Factor c = ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.Write("Const d = ");
            double d = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(
                $"Your equation: {a}x3 + {b}x2 + {c}x + {d} = 0");

            EquationsCoefficients equationsCoefficients =
                new EquationsCoefficients(a, b, c, d);

            return equationsCoefficients;
        }
    }
}