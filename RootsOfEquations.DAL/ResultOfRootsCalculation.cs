namespace RootsOfEquationsCalculator.DAL
{
    public class ResultOfRootsCalculation
    {
        public int Id { get; set; }
        public double XToPower3 { get; set; }
        public double XToPower2 { get; set; }
        public double XToPower1 { get; set; }
        public double Constant { get; set; }
        public string Result { get; set; }
    }
}