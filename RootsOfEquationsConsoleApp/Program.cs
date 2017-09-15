using RootsOfEquationsCalculator.EquationsTypes;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu();

            int choose;
            if(int.TryParse(Console.ReadLine(), out choose))
            {
                ChooseEquationType(choose);
            }
            else
            {
                Console.WriteLine("Invalid input - choose number 1, 2 or 3");
            }
        }

        private static void Menu()
        {
            Console.WriteLine("=======Root calculator menu=======");
            Console.WriteLine("Linear equation: 1");
            Console.WriteLine("Square equation: 2");
            Console.WriteLine("Cubic equation: 3");
        }

        private static void ChooseEquationType(int choose)
        {
            switch(choose)
            {
                case 1:
                    LinearEquationView();
                    break;
                case 2:
                    SquareEquationView();
                    break;
                case 3:
                    CubicEquationView();
                    break;
                default:
                    Console.WriteLine("Choose number 1, 2 or 3");
                    break;
            }
        }

        private static void LinearEquationView()
        {
            Console.Write("Factor a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Const b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Your equation: {a}x + {b} = 0");

            object result = LinearEquation.CalculateRoots(a, b);
            Console.WriteLine($"Result {result}");
        }

        private static void SquareEquationView()
        {
            Console.Write("Factor a = ");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Factor b = ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.Write("Const c = ");
            double c = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine($"Your equation: {a}x2 + {b}x + {c} = 0");

            List<double> result = (List<double>)SquareEquation.CalculateRoots(a, b, c);
            Console.WriteLine($"Result {result.ToString()}");
        }

        private static void CubicEquationView()
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

            object result = CubicEquation.CalculateRoots(a, b, c, d);
            Console.WriteLine($"Result {result}");
        }
    }
}