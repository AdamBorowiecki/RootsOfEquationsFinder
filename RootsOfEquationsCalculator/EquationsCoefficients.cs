namespace RootsOfEquationsCalculator
{
    public class EquationsCoefficients
    {
        public double XToPower3 { get; set; }
        public double XToPower2 { get; set; }
        public double XToPower1 { get; set; }
        public double Constant { get; set; }

        public EquationsCoefficients(double a, double b)
        {
            XToPower1 = a;
            Constant = b;
        }

        public EquationsCoefficients(double a, double b, double c)
        {
            XToPower2 = a;
            XToPower1 = b;
            Constant = c;
        }

        public EquationsCoefficients(double a, double b, double c, double d)
        {
            XToPower3 = a;
            XToPower2 = b;
            XToPower1 = c;
            Constant = d;
        }
    }
}