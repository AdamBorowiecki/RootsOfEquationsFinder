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
    public class EquationCalculatorWithDB //: EquationCalculator
    {
        private IRootsOfEquationsService service;
        private EquationCalculator equationCalculator;

        public EquationCalculatorWithDB(
            IRootsOfEquationsService service,
            EquationCalculator equationCalculator)
        {
            this.service = service;
            this.equationCalculator = equationCalculator;
        }

        /*public override IRootsResult CalculateRoots(EquationsCoefficients equationsCoefficients)
        {
            if(service.IsCalcualtedBefore(equationsCoefficients))
            {
                Console.WriteLine("IsCalcualtedBefore");
                return new RootsResultFromDB(
                    service.ReadResult(equationsCoefficients));//to_do Single mathod need try... catch...
            }
            Console.WriteLine("Is calculated now");
            IRootsResult result = equationCalculator.CalculateRoots(equationsCoefficients);
            service.Add(equationsCoefficients, result);

            return result;
        }*/
    }
}