using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Models;
using System;

namespace RootsOfEquationsConsoleApp.View
{
    internal abstract class EquationView
    {
        protected EquationCalculator equationCalculator;

        internal abstract EquationsCoefficients ReadParameters();

        internal void DisplayResult(EquationsCoefficients equationsCoefficients)
        {
            IRootsResult result = equationCalculator.CalculateRoots(equationsCoefficients);
            Console.WriteLine($"Result: {result}");
        }
    }
}