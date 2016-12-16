#region Information

// AdventOfCode: Day16_DragonChecksum
// Created: 2016-12-16
// Modified: 2016-12-16 10:35 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Day16_DragonChecksum
{
    class Program
    {
        #region  Fields

        // Puzzle input - Part 1
        //private const int DiskLength = 272;
        // Puzzle input - Part 2
        private const int DiskLength = 35651584;
        private static readonly Regex PairRegex = new Regex(".{2}");
        private static string _randomData = "11011110011011101";
        #endregion

        static void Main(string[] args)
        {
            // Generate random data until we have at least enough to fill the disk.
            while (_randomData.Length < DiskLength)
            {
                GenerateData();
            }

            // Generate the checksum
            string checksum = GenerateChecksum();
            string message = $"Checksum: {checksum}";
            Console.WriteLine(message);
            Debug.WriteLine(message); // Easier to copy/paste answer.
            Console.ReadKey();
        }

        /// <summary>
        ///     Generates the checksum.
        /// </summary>
        /// <returns></returns>
        private static string GenerateChecksum()
        {
            // Only use enough data to fill the disk.
            string data = _randomData.Substring(0, DiskLength);

            // Keep calculating a checksum until we have an odd number of characters.
            while (data.Length % 2 == 0)
            {
                var checksum = new StringBuilder();

                // Use regular expression to split the checksum into sets of two characters.
                MatchCollection matches = PairRegex.Matches(data);

                // Generate a new checksum value based on each pair.
                foreach (Match match in matches)
                {
                    checksum.Append(GenerateChecksumValue(match.Value));
                }

                // Update the data to calculate a checksum from.
                data = checksum.ToString();
            }

            // Checksum length is an odd number - return the value.
            return data;
        }

        /// <summary>
        ///     Generates the checksum value.
        /// </summary>
        /// <param name="pair">A pair of characters.</param>
        /// <returns>1 if both characters are the same (00 or 11), 0 if the characters are different (01,10)</returns>
        private static string GenerateChecksumValue(string pair) => pair[0].Equals(pair[1]) ? "1" : "0";

        private static void GenerateData()
        {
            // Copy input and reverse it.
            IEnumerable<char> reverseInput = _randomData.Reverse();

            // Generate a StringBuilder for Random Data Generation.
            // Use original input + "0", then append the inverse of reverseInput.
            var sb = new StringBuilder(_randomData);
            sb.Append("0");

            // Loop through ReverseInput, and replace 0 with 1 and vice versa
            foreach (char c in reverseInput)
            {
                sb.Append(c.Equals('0') ? '1' : '0');
            }

            // Update random data.
            _randomData = sb.ToString();
        }
    }
}