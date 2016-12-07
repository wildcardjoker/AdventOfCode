#region Information

// AdventOfCode: Day7_InternetProtocolVersion7
// Created: 2016-12-07
// Modified: 2016-12-08 6:17 AM
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
                                // example input
                                //new Ipv7Address("abba[mnop]qrst"),
                                //new Ipv7Address("abcd[bddb]xyyx"),
                                //new Ipv7Address("aaaa[qwer]tyui"),
                                //new Ipv7Address("ioxxoj[asdfgh]zxcvbn")
                            };

#else
            List<Ipv7Address> addresses =
                File.ReadAllLines("input.txt").Select(x => new Ipv7Address(x)).ToList();
#endif

            // Get input with "abba" pattern.
            Console.WriteLine($"Found {addresses.Count(x => x.SegmentsWithAbba > 0)} segments.");

            // Get input with "abba" pattern inside [].
            Console.WriteLine($"Found {addresses.Count(x => x.HyperNetSegmentsWithAbba > 0)} hypernet segments");

            // Get input with "abba" pattern both inside and outside [].
            Console.WriteLine(
                $"Found {addresses.Count(x => x.HyperNetSegmentsWithAbba > 0 && x.SegmentsWithAbba > 0)} addresses with both TLS and Hypernet segments.");

            // Get Part 1 answer - how many inputs with "abba" pattern *outside* [], but *not inside* []?
            Console.WriteLine
                ($"\n\nFound {addresses.Count(x => x.SupportsTls())} IPv7 addresses (part 1).");
            Console.ReadKey();
        }
    }
}