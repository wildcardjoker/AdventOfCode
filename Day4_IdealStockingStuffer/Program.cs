#region Information

// AdventOfCode: Day4_IdealStockingStuffer
// Created: 2015-12-04
// Modified: 2015-12-04 11:10 PM
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
            bool mined = false;
            while (!mined)
            {
                if (coin.Value % 1000 == 0)
                {
                    Console.WriteLine($"Processed {coin.Value} values...");
                }
                if (coin.Md5Hash.StartsWith("00000"))
                {
                    mined = true;
                    break;
                }
                coin.Value++;
            }
            Console.WriteLine($"Coin mined with value {coin.Value}. Hash: {coin.Md5Hash}");
            Console.Write("Press any key...");
            Console.ReadKey();
        }
    }
}