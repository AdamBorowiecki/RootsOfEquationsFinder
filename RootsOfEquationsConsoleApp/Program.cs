﻿using RootsOfEquationsConsoleApp.View;
using System;

namespace RootsOfEquationsConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool continueProgram = true;

            while (continueProgram)
            {
                Menu();

                int choose;
                if (int.TryParse(Console.ReadLine(), out choose) &&
                    choose == 1 || choose == 2 || choose == 3)
                {
                    ViewFactory viewFactory = new ViewFactory();
                    EquationView equationView = viewFactory.GetView(choose);
                    equationView.Display();
                }
                else
                {
                    Console.WriteLine("Invalid input - choose number 1, 2 or 3");
                }

                Console.WriteLine("---------------------------");

                continueProgram = IfContinue();
            }
        }

        private static void Menu()
        {
            Console.WriteLine("=======Root calculator menu=======");
            Console.WriteLine("Linear equation: 1");
            Console.WriteLine("Square equation: 2");
            Console.WriteLine("Cubic equation: 3");
        }

        static bool IfContinue()
        {
            Console.WriteLine("Do you want to continue?");
            Console.WriteLine("Yes - any key");
            Console.WriteLine("No  - 0");

            string result = Console.ReadLine();
            bool ifContinue = !result.Equals("0");

            return ifContinue;
        }
    }
}