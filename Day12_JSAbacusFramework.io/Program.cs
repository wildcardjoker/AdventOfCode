#region Information

// AdventOfCode: Day12_JSAbacusFramework.io
// Created: 2015-12-12
// Modified: 2015-12-12 9:13 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Day12_JSAbacusFramework.io
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            Regex regex = new Regex("-?\\d+");
            int i = regex.Matches(input).Cast<Match>().Sum(match => Convert.ToInt32(match.Value));

            string result = $"Sum Total of all values: {i}.";
            Console.WriteLine(result);
            Debug.WriteLine(result);
            Console.Write("Press any key.");
            Console.ReadKey();
        }
    }
}