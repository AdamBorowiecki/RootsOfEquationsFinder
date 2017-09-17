using RootsOfEquationsCalculator.Models;
using RootsOfEquationsCalculator.RootsResultsModels;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class LinearEquation : IEquation
    {
        public double a;//unknown x to first power factor
        public double b;//constant

        public LinearEquation(
            double a,//unknown x to first power factor
            double b)//constant
        {//equation format: a * x + b = 0
            this.a = a;
            this.b = b;
        }

        public IRootsResult CalculateRoots()
        {    
            if (a.Equals(0.0) && b.Equals(0.0))
            {
                return new InfinitelyManySolutions();
            }

            if (a.Equals(0.0))
            {
                return new NoRealSolutions();
            }

            return new RootsValues(- b / a);
        }

        public override string ToString()
        {
            return $"Your equation: {a}x + {b} = 0";
        }
    }
}