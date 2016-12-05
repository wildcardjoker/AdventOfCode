// AdventOfCode: Day5_HowAboutANiceGameOfChess
// Created: 2016-12-05
// Modified: 2016-12-05 2:20 PM

#region Using Directives
using System;
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
        private const string Input = "cxdnnyjw";
        private static int _index;
        #endregion

        static void Main(string[] args)
        {
            var password = new StringBuilder();

            while (password.Length < 8)
            {
                password.Append(GetPasswordChar());
            }
            Console.WriteLine(password.ToString());
            Console.ReadKey();
        }

        /// <summary>
        ///     Gets the password character.
        /// </summary>
        /// <returns></returns>
        /// <remarks>Calculate the MD5 hash until it begins with 00000</remarks>
        private static char GetPasswordChar()
        {
            string hash = string.Empty;
            while (!hash.StartsWith("00000"))
            {
                hash = CalculateMd5Hash($"{Input}{_index}");
                _index++;
            }
            return hash[5];
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