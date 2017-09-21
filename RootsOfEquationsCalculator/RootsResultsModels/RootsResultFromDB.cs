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
        private string value;

        public RootsResultFromDB(string value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return value;
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
