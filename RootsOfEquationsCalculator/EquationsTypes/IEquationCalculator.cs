using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public interface IEquationCalculator
    {
        IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients);
        string ToString();
    }
}
