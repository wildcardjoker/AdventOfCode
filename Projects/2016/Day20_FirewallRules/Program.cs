#region Information

// AdventOfCode: Day20_FirewallRules
// Created: 2016-12-20
// Modified: 2016-12-20 9:38 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day20_FirewallRules
{
    /// <summary>
    ///     Advent of Code Day 20
    ///     Code courtesy of https://www.reddit.com/user/johanw123
    ///     https://www.reddit.com/r/adventofcode/comments/5jbeqo/2016_day_20_solutions/dbf1mcz/
    /// </summary>
    class Program
    {
        #region  Fields
        private static readonly List<string> Input = File.ReadAllLines("input.txt").ToList();
        #endregion

        static void Main(string[] args)
        {
            var allowedIps = new List<long>();
            long currentIp = 0;
            var whileCount = 0;
            var maxIp = 4294967295;

            // Generate table of IP ranges
            Dictionary<long, long> ipRange =
                Input.Select(s => s.Split('-'))
                     .ToDictionary(range => Convert.ToInt64(range[0]), range => Convert.ToInt64(range[1]));

            // Part 2 - loop through all valid addresses.
            while (currentIp <= maxIp)
            {
                // Keep track of how many times we do this.
                whileCount++;

                // Is the current IP address within a range?
                var ipAddressInRange = false;

                // Loop through each IP range, starting with the lowest.
                foreach (KeyValuePair<long, long> range in ipRange.OrderBy(x => x.Key))
                {
                    // Get lowest and highest IP addresses.
                    long low = range.Key;
                    long high = range.Value;

                    // If the current IP address is out of range (higher or lower) move on to the next one.
                    if (currentIp > high || currentIp < low) continue;

                    // Current IP address is inside the IP range.
                    // Set current IP to just outside the current range.
                    currentIp = high + 1;

                    // Current IP address is not allowed through the firewall
                    ipAddressInRange = true;
                }

                // If the current IP address is blocked, move to the next one.
                if (ipAddressInRange) continue;

                // Add the current IP address to the Allowed IP list.
                allowedIps.Add(currentIp);

                // Check the next IP address.
                currentIp++;
            }
            Console.WriteLine($"Performed While Loop {whileCount} times.");
            Console.WriteLine($"Lowest IP Address allowed through the firewall: {allowedIps.OrderBy(x => x).First()}");
            Console.WriteLine($"{allowedIps.Count} IPs are allowed through the firewall.");
            Console.ReadKey();
        }
    }
}