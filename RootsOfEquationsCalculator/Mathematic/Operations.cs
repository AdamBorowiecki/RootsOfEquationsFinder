using RootsOfEquationsCalculator.Mathematic;
using System;

namespace RootsOfEquationsCalculator
{
    internal static class Operations
    {
        internal static double Round(double valueToRound)
        {
            return Math.Round(valueToRound, Constants.PRECISION);
        }

        internal static double Power(double value, double power)
        {
            if (value >= 0)
            {
                return Math.Pow(value, power);
            }
            else // value < 0
            {
                return - Math.Pow(Math.Abs(value), power);
            }
        }
    }
}