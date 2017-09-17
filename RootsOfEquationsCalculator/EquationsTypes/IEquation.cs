using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public interface IEquation
    {
        IRootsResult CalculateRoots();
        string ToString();
    }
}
