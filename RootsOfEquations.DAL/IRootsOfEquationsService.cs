using RootsOfEquationsCalculator.Models;

namespace RootsOfEquationsCalculator.DAL
{
    public interface IRootsOfEquationsService
    {
        bool IsCalcualtedBefore(EquationsCoefficients coefficients);

        string ReadResult(EquationsCoefficients coefficients);

        void Add(EquationsCoefficients coefficients, IRootsResult result);
    }
}