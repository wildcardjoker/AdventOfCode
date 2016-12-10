#region Information

// AdventOfCode: Day9_ExplosivesInCyberspace
// Created: 2016-12-10
// Modified: 2016-12-10 3:59 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Day9_ExplosivesInCyberspace
{
    class Program
    {
        #region  Fields
        private static readonly List<string> TestInputs = new List<string>
                                                          {
                                                              "ADVENT",
                                                              "A(1x5)BC",
                                                              "(3x3)XYZ",
                                                              "A(2x2)BCD(2x2)EFG",
                                                              "(6x1)(1x3)A",
                                                              "X(8x2)(3x3)ABCY"
                                                          };

        private static readonly string Input = File.ReadAllText("input.txt");
        private static readonly Regex DigitRegex = new Regex(@"\d+");
        #endregion

        public static void Main(string[] args)
        {
            string result;

            // Process test inputs.
            foreach (string s in TestInputs)
            {
                result = ExpandCompressedInput(s);

                //Console.WriteLine($"{result}: {result.Length}");
                Console.WriteLine(result.Length);
            }
            result = ExpandCompressedInput(Input);
            Console.WriteLine(result.Length);
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        private static string ExpandCompressedInput(string s)
        {
            var sb = new StringBuilder();

            // Remove white space
            string chars = s.Replace(" ", string.Empty).Replace(Environment.NewLine, string.Empty);
            var index = 0;
            while (index < chars.Length)
            {
                if (chars[index].Equals('('))
                {
                    index++;
                    int markerEndIndex = s.IndexOf(")", index, StringComparison.CurrentCultureIgnoreCase);
                    string markerInput = s.Substring(index, markerEndIndex - index);
                    index = markerEndIndex + 1;
                    MatchCollection markers = DigitRegex.Matches(markerInput);
                    int numChars = Convert.ToInt32(markers[0].Value);
                    int repeat = Convert.ToInt32(markers[1].Value);
                    string part = s.Substring(index, numChars);
                    for (var i = 0; i < repeat; i++)
                    {
                        sb.Append(part);
                    }
                    index += numChars;
                }
                else
                {
                    sb.Append(chars[index]);
                    index++;
                }
            }
            return sb.ToString();
        }
    }
}