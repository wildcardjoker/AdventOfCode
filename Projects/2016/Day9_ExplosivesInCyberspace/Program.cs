#region Information

// AdventOfCode: Day9_ExplosivesInCyberspace
// Created: 2016-12-10
// Modified: 2016-12-10 6:37 PM
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

        private static readonly string Input =
            File.ReadAllText("input.txt").Replace(" ", string.Empty).Replace(Environment.NewLine, string.Empty);

        private static readonly Regex DigitRegex = new Regex(@"\d+");
        #endregion

        public static void Main(string[] args)
        {
            string result;

            // Process test inputs.
            //foreach (string s in TestInputs)
            //{
            //    result = ExpandCompressedInput(s);

            //    //Console.WriteLine($"{result}: {result.Length}");
            //    Console.WriteLine(result.Length);
            //}
            result = ExpandCompressedInput(Input);
            Console.WriteLine($"Part 1: {result.Length}");
            Console.WriteLine($"Part 2: {Decompress(Input, true)}");
            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        /// <summary>
        ///     Decompresses the specified input.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <param name="recurse">if set to <c>true</c> processing Part 2 (expand all repeat markers).</param>
        /// <returns></returns>
        /// <remarks>
        ///     Credit to https://www.reddit.com/user/LoupieG
        ///     (https://www.reddit.com/r/adventofcode/comments/5hbygy/2016_day_9_solutions/db02buv/)
        ///     I added comments to ensure I understood what was happening
        /// </remarks>
        private static long Decompress(string input, bool recurse)
        {
            // Create a variable to hold the length of the file.
            long fileLength = 0;

            // Loop through the file
            for (var index = 0; index < input.Length; index++)
            {
                // Did we hit a repeat marker?
                if (input[index].Equals('('))
                {
                    // Get the number of characters to repeat, and the number of times to repeat them.
                    string[] repeatMarkers =
                        input.Substring(index + 1, (input.IndexOf(')', index) - 1) - index).Split('x');

                    // Get number of characters to be repeated
                    int numberOfCharacters = Convert.ToInt32(repeatMarkers[0]);

                    // Get number of times to repeat the character set
                    int times = Convert.ToInt32(repeatMarkers[1]);

                    // Get the position in the string *after* the repeat marker and repeated characters.
                    int nextPosition = input.IndexOf(')', index) + numberOfCharacters;

                    // Does the repeat input contain another repeat marker?
                    // And are we expanding a v2 file?
                    if (input.Substring(input.IndexOf(')', index) + 1, numberOfCharacters).Contains("(") && recurse)
                    {
                        // Yes: Decompress the subset of characters, and add the resulting length.
                        // this is repeated as many times as necessary to account for multiple repeat markers in the set 
                        fileLength += times *
                                      Decompress(input.Substring(input.IndexOf(')', index) + 1, numberOfCharacters),
                                                 true);
                    }
                    else
                    {
                        // No: Multiple the number of characters by the number of times to be repeated, then increase the index.
                        fileLength += numberOfCharacters * times;
                    }

                    // Set the index to the last character used in the repeat marker and continue
                    index = nextPosition;
                }
                else
                {
                    // No need to repeat this character
                    fileLength++;
                }
            }

            // All characters have been counted
            return fileLength;
        }

        private static string ExpandCompressedInput(string s)
        {
            var sb = new StringBuilder();

            var index = 0;
            while (index < Input.Length)
            {
                if (Input[index].Equals('('))
                {
                    index++;
                    int markerEndIndex = Input.IndexOf(")", index, StringComparison.CurrentCultureIgnoreCase);
                    string markerInput = Input.Substring(index, markerEndIndex - index);
                    index = markerEndIndex + 1;
                    MatchCollection markers = DigitRegex.Matches(markerInput);
                    int numChars = Convert.ToInt32(markers[0].Value);
                    int repeat = Convert.ToInt32(markers[1].Value);
                    string part = Input.Substring(index, numChars);
                    for (var i = 0; i < repeat; i++)
                    {
                        sb.Append(part);
                    }
                    index += numChars;
                }
                else
                {
                    sb.Append(s[index]);
                    index++;
                }
            }
            return sb.ToString();
        }
    }
}