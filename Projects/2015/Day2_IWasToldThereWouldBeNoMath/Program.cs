#region Information

// AdventOfCode: Day2_IWasToldThereWouldBeNoMath
// Created: 2015-12-02
// Modified: 2015-12-03 1:43 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day2_IWasToldThereWouldBeNoMath
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<string> presentDimensionsList = File.ReadAllText("input.txt")
                                                     .Split(Environment.NewLine.ToCharArray(),
                                                            StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Present> presents = GetPresents(presentDimensionsList);
            int totalArea = presents.Sum(s => GetPaperRequirements(s));
            int totalRibbon = presents.Sum(p => GetRibbonRequirements(p));
            Console.WriteLine($"\r\n\r\nGrand Total of wrapping paper required: {totalArea} sq ft.");
            Console.WriteLine($"Total ribbon required: {totalRibbon} ft.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        /// <summary>
        ///     Each present requires the smallest perimeter of one face, plus the cubic volume of the present.
        /// </summary>
        /// <param name="present"></param>
        /// <returns></returns>
        private static int GetRibbonRequirements(Present present)
        {
            int ribbonLength = present.SmallestPerimeter();
            int bowLength = present.Volume;
            int totalRibbon = ribbonLength + bowLength;
            Console.WriteLine(
                $"Present {present.Length}L x {present.Width}W x {present.Height}H requires {ribbonLength} ft ribbon + {bowLength} bow, total {totalRibbon}.");
            return totalRibbon;
        }

        /// <summary>
        ///     Generate a list of Presents given a string in the format lxwxh
        /// </summary>
        /// <param name="presentDimensionsList"></param>
        /// <returns></returns>
        private static List<Present> GetPresents(IEnumerable<string> presentDimensionsList)
        {
            return
                presentDimensionsList.Select(s => s.Split('x').ToArray()).Select(dimensions => new Present
                                                                                               {
                                                                                                   Length =
                                                                                                       Convert.ToInt32(
                                                                                                           dimensions[0]),
                                                                                                   Width =
                                                                                                       Convert.ToInt32(
                                                                                                           dimensions[1]),
                                                                                                   Height =
                                                                                                       Convert.ToInt32(
                                                                                                           dimensions[2])
                                                                                               }).ToList();
        }

        /// <summary>
        ///     Get paper required for present.
        /// </summary>
        /// <param name="p">Present to wrap</param>
        /// <returns></returns>
        private static int GetPaperRequirements(Present p)
        {
            List<int> areas = GetSideAreas(p);
            int smallestArea = areas.Min();
            int surfaceArea = 2 * areas.Sum();
            int total = smallestArea + surfaceArea;
            Console.WriteLine(
                $"Surface area: {surfaceArea} with {smallestArea} slack. Total area of {total}.");
            return total;
        }

        /// <summary>
        ///     Get area of sides.
        /// </summary>
        /// <param name="p">Present to measure.</param>
        /// <returns></returns>
        private static List<int> GetSideAreas(Present p)
        {
            Console.Write($"Present is {p.Length} long, {p.Width} wide, {p.Height} high. ");
            return new List<int> {p.Length * p.Width, p.Width * p.Height, p.Length * p.Height};
        }
    }
}