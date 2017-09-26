using RootsOfEquationsCalculator.Models;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.RootsResultsModels
{
    public class InfinitelyManySolutions : IRootsResult
    {
        private string value = "InfinitelyManySolutions";

        public override string ToString()
        {
            return value;
        }

        public int Count()
        {
            return int.MaxValue;
        }

        public List<double> GetValues()
        {
            return new List<double>(new double[int.MaxValue]);
        }

        public override bool Equals(object obj)
        {
            if (obj is InfinitelyManySolutions)
            {
                InfinitelyManySolutions other = (InfinitelyManySolutions)obj;
                return ToString().Equals(other.ToString());
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }
    }
}