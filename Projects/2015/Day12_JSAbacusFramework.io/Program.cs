#region Information
// AdventOfCode: Day12_JSAbacusFramework.io
// Created: 2015-12-12
// Modified: 2015-12-12 9:53 PM
// Last modified by: Jason Moore (Jason)
#endregion

namespace Day12_JSAbacusFramework.io
{
    #region Using Directives
    using System;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json.Linq;
    #endregion

    internal class Program
    {
        private static void GetSum(string input, string pattern)
        {
            var regex = new Regex(pattern);
            var i     = regex.Matches(input).Cast<Match>().Sum(match => Convert.ToInt32(match.Value));

            var result = $"Sum Total of all values (part 1): {i}.";
            Console.WriteLine(result);
        }

        private static void Main(string[] args)
        {
            var input = File.ReadAllText("input.txt");

            // Part 1
            GetSum(input, "-?\\d+");

            // Part 2
            var json = JArray.Parse(input);
            Console.WriteLine($"Sum Total of all values (part 2): {SumTokens(json)}.");
        }

        private static long SumTokens(JToken token)
        {
            switch (token)
            {
                case JObject jo:
                    return jo.Properties().Select(j => j.Value).OfType<JValue>().Select(k => k.Value).OfType<string>().Any(propValue => propValue.Equals("red"))
                               ? 0
                               : jo.Properties().Select(p => p.Value).Sum(SumTokens);
                case JArray ja:
                    return ja.Sum(SumTokens);
                case JValue jv:
                    return jv.Value is long value ? value : 0;
                default:
                    throw new InvalidOperationException();
            }
        }
    }
}