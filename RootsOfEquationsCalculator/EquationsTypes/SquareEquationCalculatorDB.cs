using RootsOfEquations.DAL;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class SquareEquationCalculatorDB : SquareEquationCalculator
    {
        private IRootsOfEquationsService service;

        public SquareEquationCalculatorDB(
            IRootsOfEquationsService service)
        {
            this.service = service;
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

            IRootsResult result = base.CalculateRoots(equationsCoefficients);
            service.Add(equationsCoefficients, result);

            return new RootsResultFromDB(isCalcualtedBefore, result.ToString());
        }
    }
}