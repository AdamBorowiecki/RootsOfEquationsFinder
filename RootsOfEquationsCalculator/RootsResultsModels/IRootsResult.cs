using System.Collections.Generic;

namespace RootsOfEquationsCalculator.Models
{
    public interface IRootsResult
    {
        string ToString();
        int Count();
        List<double> GetValues();
    }
}
