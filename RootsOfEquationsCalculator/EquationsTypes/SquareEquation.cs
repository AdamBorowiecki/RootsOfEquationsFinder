﻿using RootsOfEquationsCalculator.Models;
using System;
using System.Collections.Generic;

namespace RootsOfEquationsCalculator.EquationsTypes
{
    public class SquareEquation : IEquation
    {
        private double a;//unknown x to the second power factor
        private double b;//unknown x to the first power factor
        private double c;//const

        public SquareEquation(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public IRootsResult CalculateRoots()
        {//equation format: ax2 + bx + c = 0
            double delta = Math.Pow(b, 2) - 4 * a * c;

            if(delta > 0)
            {
                return TwoRoots(a, b, delta);
            }
            else if(delta == 0)
            {
                return OneRoot(a, b);
            }
            else//(delta < 0)
            {
                return new NoRealSolutions();
            }
        }

        private RootsValues TwoRoots(double a, double b, double delta)
        {
            List<double> roots = new List<double>();

            double root1 = (- b - Math.Sqrt(delta)) / (2 * a);
            roots.Add(root1);

            double root2 = (- b + Math.Sqrt(delta)) / (2 * a);
            roots.Add(root2);

            return new RootsValues(roots);
        }

        private RootsValues OneRoot(double a, double b)
        {
            return new RootsValues(- b / (2 * a));
        }
    }
}