﻿using RootsOfEquationsCalculator;
using RootsOfEquationsCalculator.EquationsTypes;
using RootsOfEquationsCalculator.Factory;
using RootsOfEquationsCalculator.Models;
using System;

namespace RootsOfEquationsConsoleApp.View
{
    internal abstract class EquationView
    {
        public void Display()
        {
            EquationsCoefficients equationsCoefficients = ReadParameters();
            DisplayResult(equationsCoefficients);
        }
        protected abstract EquationsCoefficients ReadParameters();

        protected void DisplayResult(EquationsCoefficients equationsCoefficients)
        {
            EquationFactory equationFactory = new EquationFactory();
            IEquation equation = equationFactory.GetEquation(equationsCoefficients);
            IRootsResult result = equation.CalculateRoots();
            Console.WriteLine($"Result: {equation.CalculateRoots()}");
        }
    }
}