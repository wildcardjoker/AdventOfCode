// AdventOfCode: Day6_SignalsAndNoise
// Created: 2016-12-06
// Modified: 2016-12-06 1:43 PM

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

#endregion

namespace Day6_SignalsAndNoise
{
    class Program
    {
        #region  Fields
#if TEST
        private static readonly List<string> Input = new List<string>
                                                     {
                                                         "eedadn",
                                                         "drvtee",
                                                         "eandsr",
                                                         "raavrd",
                                                         "atevrs",
                                                         "tsrnev",
                                                         "sdttsa",
                                                         "rasrtv",
                                                         "nssdts",
                                                         "ntnada",
                                                         "svetve",
                                                         "tesnvt",
                                                         "vntsnd",
                                                         "vrdear",
                                                         "dvrsen",
                                                         "enarar"
                                                     };
#else
        private static readonly List<string> Input = File.ReadAllLines("input.txt").ToList();
#endif
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine($"Part 1: {GetMessage()}");
            Console.WriteLine($"Part 2: {GetMessage(true)}");
            Console.ReadKey();
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <param name="part2">if set to <c>true</c> [part2].</param>
        /// <returns></returns>
        private static string GetMessage(bool part2 = false)
        {
            var message = new StringBuilder();
            for (var i = 0; i < Input[0].Length; i++)
            {
                var columnInput = new StringBuilder();
                foreach (string s in Input)
                {
                    columnInput.Append(s[i]);
                }
                string encryptedMessage = columnInput.ToString();

                IOrderedEnumerable<char> counts = encryptedMessage.Distinct()
                                                                  .OrderByDescending(
                                                                      x =>
                                                                          encryptedMessage.Count(
                                                                              c => c.ToString().Equals(x.ToString())));

                // Get most frequent character for part 1.
                // Get least frequent character for part 2.
                message.Append(part2 ? counts.LastOrDefault() : counts.FirstOrDefault());
            }
            return message.ToString();
        }
    }
}