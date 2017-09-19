using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.EquationsTypes;
using System;

namespace RootsOfEquationsConsoleApp.View
{
    internal class LinearEquationView : EquationView
    {
        public LinearEquationView(IEquationCalculator equationCalculator)
        {
            base.equationCalculator = equationCalculator;
        }

        internal override EquationsCoefficients ReadParameters()
        {
            Console.Write("Factor a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Const b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Your equation: {a}x + {b} = 0");

            EquationsCoefficients equationsCoefficients =
               new EquationsCoefficients(a, b);

            return equationsCoefficients;
        }
    }
}