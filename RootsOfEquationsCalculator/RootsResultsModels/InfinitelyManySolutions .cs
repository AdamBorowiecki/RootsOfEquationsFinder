using System;
using System.Collections.Generic;
using RootsOfEquationsCalculator.Models;

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
            throw new NotImplementedException();
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