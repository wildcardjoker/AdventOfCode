#region Information

// AdventOfCode: Day6_ProbablyAFirerHazard_Console
// Created: 2015-12-07
// Modified: 2015-12-07 8:24 PM
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

            //List<string> instructions = new List<string>
            //                            {
            //                                "turn on 0,0 through 999,999",
            //                                "toggle 0,0 through 999,0",
            //                                "turn off 499,499 through 500,500"
            //                            };
            _grid = new ChristmasLightsGrid
                    {
                        Columns = cols,
                        Rows = rows,
                        Lights = new List<ChristmasLight>()
                    };
            _grid.GenerateGridCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Count} lights on grid.");

            _grid.Instructions = File.ReadAllLines("input.txt").ToList();
            _grid.FollowInstructionsCommand.Execute(null);
            Console.WriteLine($"{_grid.Lights.Count(l => l.Lit)} lights on.");
            Console.Write("Press any key.");
            Console.ReadKey();
        }

        private static void CreateGrid(int cols, int rows)
        {
            for (int x = 0; x < cols; x++)
            {
                for (int y = 0; y < rows; y++)
                {
                    _grid.Lights.Add(new ChristmasLight(x, y));
                }
            }
        }
    }
}