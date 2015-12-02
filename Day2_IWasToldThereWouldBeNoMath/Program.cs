#region Information

// AdventOfCode: Day2_IWasToldThereWouldBeNoMath
// Created: 2015-12-02
// Modified: 2015-12-02 1:43 PM
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
            int totalArea = presentDimensionsList.Sum(s => GetPaperRequirements(s));
            Console.WriteLine($"\r\n\r\nGrand Total of wrapping paper required: {totalArea} sq ft.");
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        private static int GetPaperRequirements(string s)
        {
            string[] dimensions = s.Split('x').ToArray();
            int l = Convert.ToInt32(dimensions[0]);
            int w = Convert.ToInt32(dimensions[1]);
            int h = Convert.ToInt32(dimensions[2]);
            List<int> sides = new List<int> {l * w, w * h, l * h};
            int smallestSide = sides.Min();
            int surfaceArea = 2 * sides.Sum();
            int total = smallestSide + surfaceArea;
            Console.WriteLine(
                $"Present is {l} long, {w} wide, {h} high. Surface area: {surfaceArea} with {smallestSide} slack.");
            Console.WriteLine($"Total area of {total}.");
            return total;
        }
    }
}