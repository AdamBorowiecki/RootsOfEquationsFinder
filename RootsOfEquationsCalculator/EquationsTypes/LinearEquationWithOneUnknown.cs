namespace RootsOfEquationsCalculator.EquationsTypes
{
    public static class LinearEquationWithOneUnknown
    {
        public static object CalculateRoots(
            double factorAtUnknown,//a
            double constantNumberLeftOfEquation,//b
            double constantNumberRightOfEquation//c
            )//equation format: a * x + b = c
        {
            //simplify equation to format: a * x = c - b
            double constValuesSum = constantNumberRightOfEquation - constantNumberLeftOfEquation;

            if (factorAtUnknown.Equals(0.0) && constValuesSum.Equals(0.0))
            {
                return RootInformation.InfinitelyManySolutions;
            }

            if (factorAtUnknown.Equals(0.0))
            {
                return RootInformation.NoRoots;
            }

            return constValuesSum / factorAtUnknown;
        }
    }
}