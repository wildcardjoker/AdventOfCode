// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 1:45 PM

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using Day1_NoTimeForATaxicab.Journey;

#endregion

namespace Day1_NoTimeForATaxiCab
{
    /// <summary>
    ///     Launch the Day 1 application.
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Launch the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var inputs = new List<string> {"R2, L3", "R2, R2, R2", "R5, L5, R5, R3", File.ReadAllText("input.txt")};
            foreach (string input in inputs)
            {
                TravelOnJourney(input);
            }
            Console.ReadKey();
        }

        private static void TravelOnJourney(string input)
        {
            var journey = new Journey(input);
            journey.Travel();
            Console.WriteLine(
                $"Your taxi has arrived at {journey.Coordinates}, and is {journey.BlocksFromStart} blocks away from your departure point.");
            File.WriteAllText("taxilog.csv", journey.Log);
        }
    }
}