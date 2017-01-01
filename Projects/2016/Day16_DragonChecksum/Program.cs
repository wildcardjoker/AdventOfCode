#region Information

// AdventOfCode: Day16_DragonChecksum
// Created: 2016-12-16
// Modified: 2016-12-17 10:01 AM
#endregion

#region Using Directives
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

#endregion

namespace Day16_DragonChecksum
{
    class Program
    {
        #region  Fields

        // Puzzle input - Part 1
        private const int DiskLengthPart1 = 272;

        // Puzzle input - Part 2
        private const int DiskLengthPart2 = 35651584;
        private static readonly string _input = "11011110011011101";
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine(TimeResult(1, DiskLengthPart1));
            Console.WriteLine(TimeResult(2, DiskLengthPart2));
            Console.ReadKey();
        }

        private static string TimeResult(int part, int diskLength)
        {
            Stopwatch sw = Stopwatch.StartNew();
            GetChecksum(part, diskLength);
            sw.Stop();
            return $"Part {part} completed in {new TimeSpan(sw.ElapsedTicks):g}.";
        }

        private static void GetChecksum(int part, int diskLength)
        {
            string input = _input;

            // Generate random data until we have at least enough to fill the disk.
            while (input.Length < diskLength)
            {
                input =
                    $"{input}0{new string(input.Reverse().ToArray()).Replace('1', '-').Replace('0', '1').Replace('-', '0')}";
            }

            // Generate the checksum
            string checksum = GenerateChecksum(input.Substring(0, diskLength));
            Console.WriteLine($"Part {part}: Found checksum {checksum}.");
        }

        /// <summary>
        ///     Generates the checksum.
        /// </summary>
        /// <returns></returns>
        private static string GenerateChecksum(string input)
        {
            // Only use enough data to fill the disk.
            string data = input;

            // Keep calculating a checksum until we have an odd number of characters.
            while (data.Length % 2 == 0)
            {
                var checksum = new StringBuilder();

                // Check each pair of characters and generate a new checksum.
                for (var i = 0; i < data.Length - 1; i += 2)
                {
                    checksum.Append(data[i].Equals(data[i + 1]) ? '1' : '0');
                }

                // Update the data to calculate a checksum from.
                data = checksum.ToString();
            }

            // Checksum length is an odd number - return the value.
            return data;
        }
    }
}