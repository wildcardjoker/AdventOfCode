#region Information

// AdventOfCode: Day5_DoesntHeHaveInternElvesForThis
// Created: 2015-12-05
// Modified: 2015-12-05 10:28 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using libSanta;

#endregion

namespace Day5_DoesntHeHaveInternElvesForThis
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Part 1
            Santa santa = new Santa();
            List<string> list = File.ReadAllLines("input.txt").ToList();
            int niceStrings = list.Count(x => santa.IsNiceString(x));
            Console.WriteLine(
                $"Part One: {list.Count} strings processed. {list.Count - niceStrings} strings marked as naughty. {niceStrings} strings are nice");

            // Part 2
            niceStrings = list.Count(x => santa.IsNiceString2(x));
            Console.WriteLine(
                $"Part Two: {list.Count} strings processed. {list.Count - niceStrings} strings marked as naughty. {niceStrings} strings are nice");
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}