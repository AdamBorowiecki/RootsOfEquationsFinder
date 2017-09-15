namespace RootsOfEquationsCalculator.EquationsTypes
{
    public static class LinearEquation
    {
        public static object CalculateRoots(
            double a,//unknown x to first power
            double b//constant
            )//equation format: a * x + b = 0
        {    
            if (a.Equals(0.0) && b.Equals(0.0))
            {
                return RootInformation.InfinitelyManySolutions;
            }

            if (a.Equals(0.0))
            {
                return RootInformation.NoRealSolutions;
            }

            return b / a;
        }
    }
}