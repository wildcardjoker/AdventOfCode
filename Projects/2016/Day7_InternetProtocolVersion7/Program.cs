// AdventOfCode: Day7_InternetProtocolVersion7
// Created: 2016-12-07
// Modified: 2016-12-07 2:32 PM

#define TEST

// AdventOfCode: Day7_InternetProtocolVersion7
// Created: 2016-12-07
// Modified: 2016-12-07 2:23 PM

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

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
                                new Ipv7Address("abba[mnop]qrst"),
                                new Ipv7Address("abcd[bddb]xyyx"),
                                new Ipv7Address("aaaa[qwer]tyui"),
                                new Ipv7Address("ioxxoj[asdfgh]zxcvbn")
                            };

#endif
            foreach (Ipv7Address address in addresses)
            {
                Console.WriteLine($"Supports TLA: {address.SupportsTLA()}");
            }
            Console.ReadKey();
        }
    }

    class Ipv7Address
    {
        #region Constructors
        public Ipv7Address(string input)
        {
            // There has to be a regular expression for this, but let's do it the easy way.
            Segments = input.Replace("[", "-").Replace("]", "-").Split('-').ToList();
        }
        #endregion

        #region Properties
        public List<string> Segments { get; set; }
        #endregion

        public bool SupportsTLA()
        {
            List<string> pairs = GetPairs(Segments[0]).ToList();
            pairs.AddRange(GetPairs(Segments[2]));

            foreach (string pair in pairs)
            {
                Debug.WriteLine(pair);
            }
            return false;
        }

        private IEnumerable<string> GetPairs(string input)
        {
            var pairRegex = new Regex(@"\w{2}");
            return
                (from Match match in pairRegex.Matches(input) select match.Value).Where(x => x[0] != x[1]).ToList();
        }
    }
}