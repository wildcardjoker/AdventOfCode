#region Information

// AdventOfCode: Day3_PerfectlySphericalHousesInAVacuum
// Created: 2015-12-04
// Modified: 2015-12-04 1:48 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LibHouse;

#endregion

namespace Day3_PerfectlySphericalHousesInAVacuum
{
    internal class Program
    {
        #region  Fields
        private static readonly List<House> Houses = new List<House>();
        #endregion

        private static void Main(string[] args)
        {
            char[] directions = File.ReadAllText("input.txt").ToCharArray();
            int index = 0;
            Houses.Add(new House(0, 0));
            DeliverPresent(Houses[0]);
            foreach (House nextHouse in directions.Select(c => Houses[Move(Houses[index], c)]))
            {
                DeliverPresent(nextHouse);
                index = Houses.IndexOf(nextHouse);
            }

            Console.WriteLine();
            Console.WriteLine($"{Houses.Count(h => h.Presents >= 1)} house(s) visited.");
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        /// <summary>
        ///     Deliver a present to the House.
        /// </summary>
        /// <param name="house"></param>
        private static void DeliverPresent(House house)
        {
            house.Presents++;
            int numPresents = house.Presents;
            Console.WriteLine(
                $"House at address {house.X}/{house.Y} has {numPresents} present{(numPresents == 1 ? "" : "s")}.");
        }

        /// <summary>
        ///     Move Santa to next position based on character.
        /// </summary>
        /// <param name="house">The House that Santa has just delivered a present to</param>
        /// <param name="direction">The direction Santa needs to go</param>
        /// <returns>Index of next house.</returns>
        private static int Move(House house, char direction)
        {
            int x = house.X;
            int y = house.Y;
            string point;

            switch (direction)
            {
                case '^':
                    y++;
                    point = "North";
                    break;
                case 'v':
                    y--;
                    point = "South";
                    break;
                case '>':
                    x++;
                    point = "East";
                    break;
                case '<':
                default:
                    x--;
                    point = "West";
                    break;
            }

            Console.Write($"Santa needs to move {point} to {x}/{y}");
            int index = Houses.FindIndex(h => h.X == x && h.Y == y);
            if (index == -1)
            {
                House newHouse = new House(x, y);
                Houses.Add(newHouse);
                index = Houses.IndexOf(newHouse);
                Console.WriteLine(" (New house)");
            }
            else
            {
                Console.WriteLine();
            }
            return index;
        }
    }
}