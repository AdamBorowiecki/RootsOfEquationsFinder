using RootsOfEquationsCalculator.Models;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator
{
    public class NoRealSolutions : IRootsResult
    {
        private string value = "NoRealSolutions";

        public override string ToString()
        {
            return value;
        }

        public int Count()
        {
            return 0;
        }

        public List<double> GetValues()
        {
            return new List<double>();
        }

        public override bool Equals(object obj)
        {
            if (obj is NoRealSolutions)
            {
                NoRealSolutions other = (NoRealSolutions)obj;
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