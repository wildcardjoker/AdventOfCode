#region Information

// AdventOfCode: Day14_OneTimePad
// Created: 2016-12-14
// Modified: 2016-12-15 8:32 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private static readonly Regex TripletRegex = new Regex(@"(\w)\1{2}");
        private static readonly List<string> HashList = new List<string>();
        private static readonly List<string> KeyList = new List<string>();
        private static readonly MD5 Md5Hash = MD5.Create();
        #endregion

        static string Part1()
        {
            var keyCount = 0;
            Stopwatch sw = Stopwatch.StartNew();
            while (keyCount != 64)
            {
                _index++;

                string hash = CalculateMd5Hash($"{Salt}{_index}");
                Match match = KeyRegex.Match(hash);
                if (!match.Success) continue;

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
                    Console.WriteLine(GenerateFoundKeyMessage(1, keyCount, nextHash, i));

                    // Don't bother calculating any remaining hashes - we've already found what we needed.
                    break;
                }
            }
            sw.Stop();
            return GenerateResultMessage(1, _index, sw);
        }

        private static string GenerateResultMessage(int part, int index, Stopwatch sw)
            => $"Part {part}: 64th key found at index {index} in {new TimeSpan(sw.ElapsedTicks):g}.";

        private static string GenerateFoundKeyMessage(int part, int count, string hash, int index)
            => $"Part {part}: Found key {count.ToString().PadRight(3)}: {hash} (index {index})";

        private static string Part2()
        {
            Stopwatch sw = Stopwatch.StartNew();
            while (KeyList.Count < 64)
            {
                _index++;
                string hash;
                if (HashList.Count == _index)
                {
                    string hashSource = GenerateHashInput(_index);
                    hash = AddHash(GenerateMd5Part2(hashSource));
                }
                else
                {
                    hash = HashList[_index];
                }
                Match triplet = TripletRegex.Match(hash);
                if (!triplet.Success) continue;
                var quintet = new string(triplet.Value[0], 5);
                for (var i = 1; i <= 1000; i++)
                {
                    int index = _index + i;
                    string nextHash = HashList.Count == index
                                          ? AddHash(GenerateMd5Part2(GenerateHashInput(index)))
                                          : HashList[index];
                    if (!nextHash.Contains(quintet)) continue;
                    KeyList.Add(hash);
                    Console.WriteLine(GenerateFoundKeyMessage(2, KeyList.Count, hash, _index));
                    break;
                }
            }
            sw.Stop();
            Md5Hash.Dispose();
            return GenerateResultMessage(2, _index, sw);
        }

        private static string GenerateHashInput(int index) => $"{Salt}{index}";

        private static string AddHash(string input)
        {
            string hash = GetMd5Hash(input);
            HashList.Add(hash);
            return hash;
        }

        private static string GenerateMd5Part2(string input)
        {
            for (var i = 0; i < 2016; i++)
            {
                input = GetMd5Hash(input);
            }
            return input;
        }

        private static string GetMd5Hash(string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            foreach (byte t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static void Main(string[] args)
        {
            string part1Result = Part1();

            // Reset the index for Part 2
            _index = -1;

            string part2Result = Part2();
            Console.WriteLine(part1Result);
            Console.WriteLine(part2Result);
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