#region Information

// AdventOfCode: Day9_AllInASingleNight
// Created: 2015-12-09
// Modified: 2015-12-10 9:28 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Combinatorics.Collections;

#endregion

namespace Day9_AllInASingleNight
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = File.ReadAllLines("Input.txt").ToList();
            List<string> locations = new List<string>();
            List<Journey> journeys =
                input.Select(s => s.Split(' '))
                     .Select(
                         parts =>
                         new Journey {DepartFrom = parts[0], TravelTo = parts[2], Distance = Convert.ToInt32(parts[4])})
                     .ToList();

            foreach (Journey journey in journeys)
            {
                //Console.WriteLine($"{journey.DepartFrom}, {journey.TravelTo}: {journey.Distance}");
                locations.AddRange(new[]
                                   {
                                       journey.DepartFrom,
                                       journey.TravelTo
                                   }
                    );
            }
            locations = locations.Distinct().ToList();

            Permutations<string> trips = new Permutations<string>(locations);
            List<int> totalDistances = new List<int>();
            Console.WriteLine("Crunching numbers...");
            foreach (IList<string> trip in trips)
            {
                //Console.WriteLine(string.Join(", ", trip));
                int totalDistance = 0;
                for (int i = 0; i < trip.Count - 1; i++)
                {
                    Journey nextJourney = journeys.FirstOrDefault(
                        x =>
                        (x.DepartFrom.Equals(trip[i]) && x.TravelTo.Equals(trip[i + 1]) ||
                         x.TravelTo.Equals(trip[i]) && x.DepartFrom.Equals(trip[i + 1])));
                    if (nextJourney == null)
                    {
                        Console.WriteLine($"!?ERROR?! Could not find Journey from {trip[i]} to {trip[i + 1]}!");
                        continue;
                    }
                    totalDistance += nextJourney.Distance;
                }
                totalDistances.Add(totalDistance);

                //Console.WriteLine(totalDistance);
            }
            Console.WriteLine($"Shortest distance: {totalDistances.Min()}");

            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }

    internal class Journey
    {
        #region Properties
        public string DepartFrom { get; set; }
        public int Distance { get; set; }
        public string TravelTo { get; set; }
        #endregion
    }
}