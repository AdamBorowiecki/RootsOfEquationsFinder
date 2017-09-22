using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class EquationCalculatorWorkingWithDB : EquationCalculator
    {
        private IRootsOfEquationsService service;
        private EquationCalculator equationCalculator;

        public EquationCalculatorWorkingWithDB(
            IRootsOfEquationsService service,
            EquationCalculator equationCalculator)
        {
            this.service = service;
            this.equationCalculator = equationCalculator;
        }

        public override IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {
            bool isCalcualtedBefore = service.IsCalcualtedBefore(equationsCoefficients);

            if (isCalcualtedBefore)
            {
                return new RootsResultFromDB(
                    isCalcualtedBefore,
                    service.ReadResult(equationsCoefficients));//to_do Single mathod need try... catch...
            }

            IRootsResult result = equationCalculator.CalculateRoots(equationsCoefficients);
            service.Add(equationsCoefficients, result);

            return new RootsResultFromDB(isCalcualtedBefore, result.ToString());
        }
    }
}