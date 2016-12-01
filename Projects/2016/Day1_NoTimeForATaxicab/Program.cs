#region Information

// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-01
// Modified: 2016-12-01 11:03 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using Day1_NoTimeForATaxicab.Journey;

#endregion

namespace Day1_NoTimeForATaxiCab
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<string> inputs = new List<string> {"R2, L3", "R2, R2, R2", "R5, L5, R5, R3"};
            foreach (string input in inputs)
            {
                TravelonJourney(input);
            }
            Console.ReadKey();
        }

        private static void TravelonJourney(string input)
        {
            var journey = new Journey(input);
            journey.Travel();
            Console.WriteLine(
                $"Your taxi has arrived at {journey.Coordinates}, and is {journey.BlocksFromStart} blocks away from your departure point.");
        }
    }
}