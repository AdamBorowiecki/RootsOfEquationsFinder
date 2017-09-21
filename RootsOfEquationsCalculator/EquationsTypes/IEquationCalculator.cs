using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public abstract class IEquationCalculator
    {
        abstract public IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients);
    }
}
