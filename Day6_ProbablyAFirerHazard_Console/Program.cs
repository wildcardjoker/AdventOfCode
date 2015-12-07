#region Information

// AdventOfCode: Day6_ProbablyAFirerHazard_Console
// Created: 2015-12-07
// Modified: 2015-12-07 8:53 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using libChristmasLight;
using libChristmasLightsGrid.ViewModel;

#endregion

namespace Day6_ProbablyAFirerHazard_Console
{
    class Program
    {
        #region  Fields
        private static ChristmasLightsGrid _grid;
        #endregion

        static void Main(string[] args)
        {
            int cols = 1000;
            int rows = cols;
            List<string> instructionList = File.ReadAllLines("input.txt").ToList();

            //new List<string>
            //{
            //    "toggle 0,0 through 999,999"
            //};
            _grid = new ChristmasLightsGrid
                    {
                        Columns = cols,
                        Rows = rows,
                        Lights = new List<ChristmasLight>()
                    };

            Part1(instructionList);
            Part2(instructionList);
            Console.Write("Press any key.");
            Console.ReadKey();
        }

        private static void Part1(List<string> instructions)
        {
            _grid.GenerateGridCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Count} lights on grid.");

            _grid.Instructions = instructions;
            _grid.FollowInstructionsCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Count(l => l.Lit)} lights on.");
        }

        private static void Part2(List<string> instructions)
        {
            _grid.GenerateGridCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Count} lights on grid.");

            _grid.Instructions = instructions;
            _grid.AdjustBrightnessInstructionsCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Sum(l => l.Brightness)} total brightness.");
        }
    }
}