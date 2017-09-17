using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RootsOfEquationsCalculator;

namespace RootsOfEquationsConsoleApp.View
{
    class CubicEquationView : EquationView
    {
        protected override EquationsCoefficients ReadParameters()
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
