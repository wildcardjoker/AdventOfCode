#region Information

// AdventOfCode: Day7_InternetProtocolVersion7
// Created: 2016-12-07
// Modified: 2016-12-08 9:18 PM
#endregion

//#define TEST

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day7_InternetProtocolVersion7
{
    class Program
    {
        static void Main(string[] args)
        {
#if TEST
            var addresses = new List<Ipv7Address>
                            {
                                // example input - part 1
                                //new Ipv7Address("abba[mnop]qrst"),
                                //new Ipv7Address("abcd[bddb]xyyx"),
                                //new Ipv7Address("aaaa[qwer]tyui"),
                                //new Ipv7Address("ioxxoj[asdfgh]zxcvbn"),

                                // example input - part 2
                                //new Ipv7Address("aba[bab]xyz"),
                                //new Ipv7Address("xyx[xyx]xyx"),
                                //new Ipv7Address("aaa[kek]eke"),
                                //new Ipv7Address("zazbz[bzb]cdb")
                            };

#else
            List<Ipv7Address> addresses =
                File.ReadAllLines("input.txt").Select(x => new Ipv7Address(x)).ToList();
#endif

            // Get Part 1 answer - how many inputs with "abba" pattern *outside* [], but *not inside* []?
            Console.WriteLine
                ($"Found {addresses.Count(x => x.SupportsTls())} IPv7 addresses supporting TLS (part 1).");

            // Get Part 2 answer - how many inputs with "aba" pattern *outside* [], but "bab" pattern *inside* []?
            Console.WriteLine($"Found {addresses.Count(x => x.SupportsSsl())} IPv7 addresses supporting SSL (part 2).");
            Console.ReadKey();
        }
    }
}