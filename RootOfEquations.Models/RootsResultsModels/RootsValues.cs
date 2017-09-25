using System.Collections.Generic;
using System.Linq;

namespace RootsOfEquationsCalculator.Models
{
    public class RootsValues : IRootsResult
    {
        private List<double> roots;

        public RootsValues(double root)
        {
            roots = new List<double>() { root };
        }

        public RootsValues(double root1, double root2)
        {
            roots = new List<double>() { root1, root2};
        }

        public RootsValues(double root1, double root2, double root3)
        {
            roots = new List<double>() { root1, root2, root3 };
        }

        public RootsValues(List<double> roots)
        {
            this.roots = roots;
        }

        public override string ToString()
        {
            string result = "";

            foreach(double root in roots)
            {
                result += " x = " + root;
            }

            return result;
        }

        public int Count()
        {
            return roots.Count;
        }

        public List<double> GetValues()
        {
            return roots;
        }

        public override bool Equals(object obj)
        {
            if(obj is RootsValues)
            {
                RootsValues other = (RootsValues)obj;
                return Enumerable.SequenceEqual(
                    roots.OrderBy(t => t), other.roots.OrderBy(t => t));
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return roots.GetHashCode();
        }
    }
}