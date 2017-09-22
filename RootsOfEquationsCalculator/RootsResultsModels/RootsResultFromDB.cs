using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.RootsResultsModels
{
    public class RootsResultFromDB : IRootsResult
    {
        private bool isCalculatedBefore;
        private string value;

        public RootsResultFromDB(bool isCalculatedBefore, string value)
        {
            this.isCalculatedBefore = isCalculatedBefore;
            this.value = value;
        }

        public override string ToString()
        {
            string whenValueWasCalculated = "";

            if(isCalculatedBefore)
            {
                whenValueWasCalculated += "Value is calculated before ";
            }
            else
            {
                whenValueWasCalculated += "Value is calculated now ";
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

        public override bool Equals(object obj)
        {
            if (obj is RootsResultFromDB)
            {
                RootsResultFromDB other = (RootsResultFromDB)obj;
                return 
                    isCalculatedBefore == other.isCalculatedBefore &&
                    value ==  other.value;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return isCalculatedBefore.GetHashCode() + value.GetHashCode();
        }
    }
}
