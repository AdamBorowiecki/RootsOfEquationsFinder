using Microsoft.EntityFrameworkCore;
using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.DAL;
using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquations.DAL
{
    public class RootsOfEquationsService : IRootsOfEquationsService
    {
        private RootsOfEquationsDBContext context;

        public RootsOfEquationsService(RootsOfEquationsDBContext context)
        {
            this.context = context;
        }

        public void Add(EquationsCoefficients coefficients, IRootsResult result)
        {
            var newResult = new ResultOfRootsCalculation {
                XToPower3 = coefficients.XToPower3,
                XToPower2 = coefficients.XToPower2,
                XToPower1 = coefficients.XToPower1,
                Constant = coefficients.Constant,
                Result = result.ToString() };

            context.ResultOfRootsCalculations.Add(newResult);
            context.SaveChanges();
        }

        public bool IsCalcualtedBefore(EquationsCoefficients equationsCoefficients)
        {
            return context.
                ResultOfRootsCalculations.
                Where(r => 
                    (r.XToPower3 ==  equationsCoefficients.XToPower3 &&
                    r.XToPower2 == equationsCoefficients.XToPower2 &&
                    r.XToPower1 == equationsCoefficients.XToPower1 &&
                    r.Constant == equationsCoefficients.Constant)).
                Count() != 0;
        }
        public string ReadResult(EquationsCoefficients coefficients)
        {
            return context.ResultOfRootsCalculations
                .Single(r => r.XToPower3 == coefficients.XToPower3 &&
                             r.XToPower2 == coefficients.XToPower2 &&
                             r.XToPower1 == coefficients.XToPower1 &&
                             r.Constant == coefficients.Constant).Result;
            /*return context.ResultOfRootsCalculations
                .Select(r => r.Coefficients.Equals(coefficients));*/
        }
    }
}
