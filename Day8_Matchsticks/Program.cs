#region Information

// AdventOfCode: Day8_Matchsticks
// Created: 2015-12-08
// Modified: 2015-12-08 10:17 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

#endregion

namespace Day8_Matchsticks
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputList = File.ReadAllLines("input.txt");
            CalculateSanitisedInput(inputList);
            CalculateEncodedInput(inputList);
            Console.Write("Press any key.");
            Console.ReadKey();
        }

        /// <summary>
        ///     Day 8 Part 1 - Calculate number of literal string characters
        /// </summary>
        /// <param name="strings">Puzzle input</param>
        private static void CalculateSanitisedInput(IEnumerable<string> strings)
        {
            int totalCodeChars = 0;
            int totalStringChars = 0;

            foreach (string s in strings)
            {
                int codeChars = s.Length;
                string sanitisedString = SanitiseString(s);
                int stringChars = sanitisedString.Length;
                Console.WriteLine($"string: {s} has {codeChars} characters of code, and {stringChars} characters.");
                totalCodeChars += codeChars;
                totalStringChars += stringChars;
            }
            Console.WriteLine($"{totalCodeChars} total code characters.");
            Console.WriteLine($"{totalStringChars} total string characters.");
            string totalSanitisedChars = $"{totalCodeChars - totalStringChars} total characters.";
            Console.WriteLine(totalSanitisedChars);
            Debug.WriteLine(totalSanitisedChars);
        }

        private static void CalculateEncodedInput(IEnumerable<string> strings)
        {
            int totalCodeChars = 0;
            int totalStringChars = 0;

            foreach (string s in strings)
            {
                int codeChars = s.Length;
                string encodedString = EncodeString(s);
                int stringChars = encodedString.Length;
                Console.WriteLine(
                    $"{s} ({codeChars} code) -> {encodedString} ({stringChars} characters).");
                totalCodeChars += codeChars;
                totalStringChars += stringChars;
            }
            Console.WriteLine($"{totalCodeChars} total code characters.");
            Console.WriteLine($"{totalStringChars} total string characters.");
            string totalSanitisedChars = $"{totalStringChars - totalCodeChars} encoded characters.";
            Console.WriteLine(totalSanitisedChars);
            Debug.WriteLine(totalSanitisedChars);
        }

        /// <summary>
        ///     Decode string literals
        /// </summary>
        /// <param name="s">Puzzle input</param>
        /// <returns></returns>
        private static string SanitiseString(string s)
        {
            // Remove beginning and end quotes.
            string sanitisedString = s.Substring(1, s.Length - 2);
            sanitisedString = sanitisedString.Replace("\\\\", "\\").Replace("\\\"", "+");
            Regex regex = new Regex(@"\\x[a-f0-9][a-f0-9]");
            sanitisedString = regex.Replace(sanitisedString, "+");

            //Convert to new string.
            return sanitisedString;
        }

        /// <summary>
        ///     Re-encode each literal string character
        /// </summary>
        /// <param name="s">Puzzle input</param>
        /// <returns></returns>
        private static string EncodeString(string s)
        {
            return $"\"{(s.Replace("\\", "\\\\").Replace("\"", "\\\""))}\"";
        }
    }
}