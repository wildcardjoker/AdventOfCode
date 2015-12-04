#region Information

// AdventOfCode: Day4_IdealStockingStuffer
// Created: 2015-12-04
// Modified: 2015-12-04 11:27 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using libAdventCoin;

#endregion

namespace Day4_IdealStockingStuffer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AdventCoin coin = new AdventCoin("ckczppom", 0);

            // Part 1
            string part1 = GetLowestNumber(coin, "00000");

            // Part 2
            coin.Value = 0;
            string part2 = GetLowestNumber(coin, "000000");

            Console.WriteLine(part1);
            Console.WriteLine(part2);
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static string GetLowestNumber(AdventCoin coin, string s)
        {
            bool mined = false;
            while (!mined)
            {
                if (coin.Value % 100000 == 0)
                {
                    Console.WriteLine($"Processed {coin.Value} values...");
                }
                if (coin.Match(s))
                {
                    mined = true;
                    break;
                }
                coin.Value++;
            }
            return $"Coin starting with {s} mined with value {coin.Value}. Hash: {coin.Md5Hash}";
        }
    }
}