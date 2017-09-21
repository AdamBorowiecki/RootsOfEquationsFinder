using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquationsCalculator.DAL
{
    public interface IRootsOfEquationsService
    {
        bool IsCalcualtedBefore(EquationsCoefficients coefficients);
        string ReadResult(EquationsCoefficients coefficients);
        void Add(EquationsCoefficients coefficients, IRootsResult result);
    }
}