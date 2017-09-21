using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquationsCalculator.RootsResultsModels
{
    public class RootsResultFromDB : IRootsResult
    {
        private bool isCalculatedbefore;
        private string value;

        public RootsResultFromDB(bool isCalculatedbefore, string value)
        {
            this.isCalculatedbefore = isCalculatedbefore;
            this.value = value;
        }

        public override string ToString()
        {
            string whenValueWasCalculated = "";

            if(isCalculatedbefore)
            {
                whenValueWasCalculated += "Value is calculated before";
            }
            else
            {
                whenValueWasCalculated += "Value is calculated now";
            }

            return whenValueWasCalculated + value;
        }

        public int Count()
        {
            throw new NotImplementedException();
        }

        public List<double> GetValues()
        {
            throw new NotImplementedException();
        }
    }
}
