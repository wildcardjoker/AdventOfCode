// AdventOfCode: Day5_HowAboutANiceGameOfChess
// Created: 2016-12-05
// Modified: 2016-12-05 4:13 PM

#region Using Directives
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

#endregion

namespace Day5_HowAboutANiceGameOfChess
{
    /// <summary>
    ///     Day 5 2016
    /// </summary>
    class Program
    {
        #region  Fields

        // Test input
        //private const string Input = "abc";
        //private static int _index = 3231929;
        // Puzzle input
        private const string Input = "cxdnnyjw";
        private static int _index;
        #endregion

        static void Main(string[] args)
        {
            RunPart1();
            Console.WriteLine();
            RunPart2();
            Console.ReadKey();
        }

        private static void RunPart2()
        {
            _index = 0;
            char[] password = "--------".ToCharArray();
            while (password.Any(x => x.Equals('-')))
            {
                string hash = GetPasswordHash();
                int index = GetHashIndex(hash[5]);

                while (index < 0 || index >= password.Length)
                {
                    hash = GetPasswordHash();
                    index = GetHashIndex(hash[5]);

                    //Debug.WriteLine($"{hash} - {index}");
                }
                if (password[index].Equals('-'))
                {
                    password[(int) char.GetNumericValue(hash[5])] = hash[6];
                }
            }
            Console.WriteLine($"Part 2: {new string(password.ToArray())}");
        }

        private static int GetHashIndex(char c) => (int) char.GetNumericValue(c);

        private static void RunPart1()
        {
            var password = new StringBuilder();

            while (password.Length < 8)
            {
                password.Append(GetPasswordChar());
            }
            Console.WriteLine($"Part 1: {password}");
        }

        /// <summary>
        ///     Gets the password character.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Calculate the MD5 hash until it begins with 00000</remarks>
        private static char GetPasswordChar()
        {
            return GetPasswordHash()[5];
        }

        private static string GetPasswordHash()
        {
            string hash = string.Empty;
            while (!hash.StartsWith("00000"))
            {
                hash = CalculateMd5Hash($"{Input}{_index}");
                _index++;
            }
            return hash;
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
            return sb.ToString();
        }
    }
}