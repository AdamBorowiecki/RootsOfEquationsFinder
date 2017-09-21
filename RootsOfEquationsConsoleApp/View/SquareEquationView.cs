using System;
using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.EquationsTypes;

namespace RootsOfEquationsConsoleApp.View
{
    internal class SquareEquationView : EquationView
    {
        public SquareEquationView(EquationCalculator equationCalculator)
        {
            base.equationCalculator = equationCalculator;
        }

        internal override EquationsCoefficients ReadParameters()
        {
            Console.Write("Factor a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Factor b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Const c = ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Your equation: {a}x2 + {b}x + {c} = 0");

            EquationsCoefficients equationsCoefficients =
                new EquationsCoefficients(a, b, c);

            return equationsCoefficients;
        }
    }
}