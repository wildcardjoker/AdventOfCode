﻿#region Information

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
            int santaIndex = 0;
            int roboSantaIndex = 0;
            int i = 0;
            Houses.Add(new House(0, 0));
            DeliverPresent(Houses[0]);
            foreach (char c in directions)
            {
                if (i%2==0)
                {
                    House nextHouse = Houses[Move(Houses[santaIndex], c, i)];
                    DeliverPresent(nextHouse);
                    santaIndex = Houses.IndexOf(nextHouse);
                }
                else
                {
                    House nextHouse = Houses[Move(Houses[roboSantaIndex], c,i)];
                    DeliverPresent(nextHouse);
                    roboSantaIndex = Houses.IndexOf(nextHouse);
                }
                i++;
            }
            //foreach (House nextHouse in directions.Select(c => SantaHouses[Move(SantaHouses[index], c)]))
            //{
            //    DeliverPresent(nextHouse);
            //    index = SantaHouses.IndexOf(nextHouse);
            //}

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
                $" {numPresents} present{(numPresents == 1 ? "" : "s")} delivered to house.");
        }

        /// <summary>
        ///     Move Santa to next position based on character.
        /// </summary>
        /// <param name="house">The House that Santa has just delivered a present to</param>
        /// <param name="direction">The direction Santa needs to go</param>
        /// <param name="santaNumber">Indictaes if Santa or RoboSanta is delivering presents</param>
        /// <returns>Index of next house.</returns>
        private static int Move(House house, char direction, int santaNumber)
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

            Console.Write($"{(santaNumber%2==0?"Santa":"RoboSanta")} moves {point} to {x}/{y}");
            int index = Houses.FindIndex(h => h.X == x && h.Y == y);
            if (index == -1)
            {
                House newHouse = new House(x, y);
                Houses.Add(newHouse);
                index = Houses.IndexOf(newHouse);
                Console.Write(" (New house)");
            }
            Console.Write(".");
            return index;
        }
    }
}