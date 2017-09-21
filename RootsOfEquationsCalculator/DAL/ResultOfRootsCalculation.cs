using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootsOfEquationsCalculator.DAL
{
    public class ResultOfRootsCalculation
    {
        public int Id { get; set; }
        //public EquationsCoefficients Coefficients { get; set; }
        public double XToPower3 { get; set; }
        public double XToPower2 { get; set; }
        public double XToPower1 { get; set; }
        public double Constant { get; set; }
        public string Result { get; set; }
    }
}