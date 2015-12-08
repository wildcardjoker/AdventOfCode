#region Information

// AdventOfCode: Day8_Matchsticks
// Created: 2015-12-08
// Modified: 2015-12-08 9:46 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
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
            int totalCodeChars = 0;
            int totalStringChars = 0;

            foreach (string s in inputList)
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
            Console.WriteLine($"{totalCodeChars - totalStringChars} total characters.");
            Console.Write("Press any key.");
            Console.ReadKey();
        }

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
    }
}