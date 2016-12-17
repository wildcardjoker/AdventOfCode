#region Information

// AdventOfCode: Day16_DragonChecksum
// Created: 2016-12-16
// Modified: 2016-12-17 9:38 AM
#endregion

#region Using Directives
using System;
using System.Linq;
using System.Text;

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
        private static string _randomData = "11011110011011101";
        #endregion

        static void Main(string[] args)
        {
            // Generate random data until we have at least enough to fill the disk.
            while (_randomData.Length < DiskLength)
            {
                _randomData =
                    $"{_randomData}0{new string(_randomData.Reverse().ToArray()).Replace('1', '-').Replace('0', '1').Replace('-', '0')}";
            }

            // Generate the checksum
            string checksum = GenerateChecksum();
            bool matchpuzzleAnswer = checksum.Equals("00011010100010010");
            Console.WriteLine(
                $"Found checksum {checksum}, and it {(matchpuzzleAnswer ? "matches" : "DOES NOT match")}.");
            Console.ReadKey();
        }

        private static void GetChecksum(int part, string input) {}

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