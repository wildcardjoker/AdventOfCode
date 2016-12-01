#region Information

// AdventOfCode: Day1_NotQuiteLisp
// Created: 2015-12-02
// Modified: 2015-12-02 1:15 PM
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
                                        ")",
                                        "()())",
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
            int pos = 1;
            int currentFloor = 0;
            bool enteredBasement = false;

            foreach (char t in input)
            {
                if (t.Equals('('))
                {
                    currentFloor++;
                }
                else
                {
                    currentFloor--;
                }
                if (currentFloor == -1)
                {
                    enteredBasement = true;
                    break;
                }
                pos++;
            }
            int floor = floorsUp - floorsDown;
            Console.WriteLine(enteredBasement
                                  ? $"Santa enters the basement at position {pos}."
                                  : "Santa never reached the basement.");
            Console.WriteLine(
                $"Santa travels up {floorsUp} floors and down {floorsDown} floors. Santa exits on floor {floor}");
        }
    }
}