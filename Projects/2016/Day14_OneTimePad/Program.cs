#region Information

// AdventOfCode: Day14_OneTimePad
// Created: 2016-12-14
// Modified: 2016-12-14 10:43 PM
#endregion

#region Using Directives
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

#endregion

namespace Day14_OneTimePad
{
    class Program
    {
        #region  Fields
        private const string Salt = "cuanljph";
        private static readonly Regex KeyRegex = new Regex(@"(.)\1{2}");
        private static int _index = -1;
        #endregion

        static void Main(string[] args)
        {
            var keyCount = 0;
            while (keyCount != 64)
            {
                _index++;

                string hash = CalculateMd5Hash($"{Salt}{_index}");
                Match match = KeyRegex.Match(hash);
                if (match.Success)
                {
                    // Hash contains a sequence of three characters.
                    // Check that the same character appears in a sequence of 5
                    var keyMatch = new string(match.Value[0], 5);
                    for (var i = 1; i <= 1000; i++)
                    {
                        int matchIndex = _index + i;
                        string nextHash = CalculateMd5Hash($"{Salt}{matchIndex}");

                        // If the hash does not contain the match sequence, continue the for-loop
                        if (!nextHash.Contains(keyMatch)) continue;

                        // We found a matching sequence - this is a valid one-time key
                        keyCount++;

                        // Don't bother calculating any remaining hashes - we've already found what we needed.
                        break;
                    }
                }
            }

            Console.WriteLine($"64th key found at index {_index}");
            Console.ReadKey();
        }

        /// <summary>
        ///     Calculates the MD5 hash of a string.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>String representation of the MD% hash in hexadecimal.</returns>
        private static string CalculateMd5Hash(string input)

        {
            //Create a byte array from source data.
            byte[] source = Encoding.ASCII.GetBytes(input);
            byte[] hash = new MD5CryptoServiceProvider().ComputeHash(source);

            // step 2, convert byte array to hex string
            var sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString().ToLower();
        }
    }
}