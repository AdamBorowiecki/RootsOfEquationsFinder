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
    public class CubicEquationCalculatorDB : CubicEquationCalculator
    {
        private IRootsOfEquationsService service;

        public CubicEquationCalculatorDB(
            IRootsOfEquationsService service)
        {
            this.service = service;
        }

        public override IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {
            if(service.IsCalcualtedBefore(equationsCoefficients))
            {
                Console.WriteLine("IsCalcualtedBefore");
                return new RootsResultFromDB(
                    service.ReadResult(equationsCoefficients));//to_do Single mathod need try... catch...
            }
            Console.WriteLine("Is calculated now");
            IRootsResult result = base.CalculateRoots(equationsCoefficients);
            service.Add(equationsCoefficients, result);

            return result;
        }
    }
}