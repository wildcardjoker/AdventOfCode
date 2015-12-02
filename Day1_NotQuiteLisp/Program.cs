#region Information

// AdventOfCode: Day1_NotQuiteLisp
// Created: 2015-12-02
// Modified: 2015-12-02 1:02 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day1_NotQuiteLisp
{
    internal class Program
    {
        /// <summary>
        ///     Read Input.txt and calculate the number of floors up and down Santa has to travel.
        ///     Input.txt contains either:
        ///     ( = Go UP one floor
        ///     ) = Go DOWN one floor
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            string inputFile = "input.txt";
            List<string> journeys = new List<string>
                                    {
                                        "(())",
                                        "()()",
                                        "(((",
                                        "(()(()(",
                                        "))(((((",
                                        "())",
                                        "))(",
                                        ")))",
                                        ")())())",
                                        File.ReadAllText(inputFile)
                                    };
            foreach (string journey in journeys)
            {
                Console.WriteLine("Calculate journey for '{0}'",
                                  journey.Length > 20 ? $"{journey.Substring(0, 20)}..." : journey);
                CalculateFloors(journey.ToCharArray());
            }
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static void CalculateFloors(char[] input)
        {
            // Get number of floors to travel.
            int floorsUp = input.Count(x => x.Equals('('));
            int floorsDown = input.Count(x => x.Equals(')'));
            int floor = floorsUp - floorsDown;

            Console.WriteLine("Santa travels up {0} floors and down {1} floors. Santa exits on floor {2}", floorsUp,
                              floorsDown, floor);
        }
    }
}