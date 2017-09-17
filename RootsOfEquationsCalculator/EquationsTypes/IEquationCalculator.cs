using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public interface IEquationCalculator
    {
        IRootsResult CalculateRoots();
        string ToString();
    }
}
