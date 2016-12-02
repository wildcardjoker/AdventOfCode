// AdventOfCode: Day1_NoTimeForATaxicab
// Created: 2016-12-02
// Modified: 2016-12-02 2:41 PM

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
            var inputs = new List<string> {"R8, R4, R4, R8"};
                         //{
                         //    "R2,R2,R2,R2",
                         //    "R2, L3",
                         //    "R2, R2, R2",
                         //    "R5, L5, R5, R3",
                         //    File.ReadAllText("input.txt")
                         //};
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
                $"Your taxi has arrived at {journey.Coordinates}, and is {journey.BlocksFromStart()} blocks away from your departure point.");
            File.WriteAllText("taxilog.csv", journey.Log);

            if (journey.FirstRevisitedPoint != null)
            {
                var p = journey.FirstRevisitedPoint;
                Console.WriteLine($"First revisited point: {p.X}, {p.Y} ({journey.BlocksFromStart(p)})");
            }

            //List<Point> points = journey.Points.GroupBy(x => x).SelectMany(grp => grp.Skip(1)).Distinct().ToList();
            //foreach (var point in points)
            //{
            //    Console.WriteLine(point);
            //}

            //Console.WriteLine($"First re-visited point: {journey.Coordinates} ({journey.BlocksFromStart} blocks away)");
        }
    }
}