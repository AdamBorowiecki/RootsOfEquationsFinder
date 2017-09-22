using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public abstract class EquationCalculator
    {
        abstract public IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients);
    }
}