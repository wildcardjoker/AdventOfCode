#region Information

// AdventOfCode: Day10_ElevesLookElvesSay
// Created: 2015-12-10
// Modified: 2015-12-12 8:53 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

#endregion

namespace Day10_ElevesLookElvesSay
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "1113222113";
            LookAndSay(input, 40);
            LookAndSay(input, 50);
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }

        private static void LookAndSay(string input, int iterations)
        {
            List<char> output = input.ToList();
            Console.Write("Crunching numbers...");
            Stopwatch stopwatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
            {
                //string s = string.Empty;
                List<char> resultList = new List<char>();
                List<char> chars = output;
                int j = 0;
                int k = 1;
                while (k < chars.Count)
                {
                    int count = 1;
                    while (chars[j] == chars[k])
                    {
                        count++;
                        j++;
                        k++;
                    }
                    resultList.AddRange($"{count}{chars[j]}");
                    j++;
                    k++;
                }
                if (k == chars.Count)
                {
                    resultList.AddRange($"1{chars[j]}");
                }
                output = resultList;
            }
            stopwatch.Stop();
            string answer = $"Length after {iterations} iterations: {output.Count} characters.";
            Debug.WriteLine(answer);
            Console.WriteLine(answer);
            Console.WriteLine(new TimeSpan(stopwatch.ElapsedTicks).ToString("g"));
        }
    }
}