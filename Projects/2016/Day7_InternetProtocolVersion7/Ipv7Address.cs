#region Information

// AdventOfCode: Day7_InternetProtocolVersion7
// Created: 2016-12-07
// Modified: 2016-12-07 10:50 PM
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day7_InternetProtocolVersion7
{
    class Ipv7Address
    {
        #region Constructors
        public Ipv7Address(string input)
        {
            Segments = new List<string>();
            HyperNetSegments = new List<string>();
            Input = input;

            // There has to be an easier way to split a string on [ or ] but I couldn't figure out the regular expression.
            // Let's do it the easy way.
            List<string> segments = Input.Replace("[", "-").Replace("]", "-").Split('-').ToList();
            for (var i = 0; i < segments.Count; i++)
            {
                if (i % 2 == 0)
                {
                    Segments.Add(segments[i]);
                }
                else
                {
                    HyperNetSegments.Add(segments[i]);
                }
            }
        }
        #endregion

        #region Properties
        public List<string> HyperNetSegments { get; set; }

        public int HyperNetSegmentsWithAbba => HyperNetSegments.Count(ContainsAbba);
        public string Input { get; set; }
        public List<string> Segments { get; set; }
        public int SegmentsWithAbba => Segments.Count(ContainsAbba);
        #endregion

        /// <summary>
        ///     Indicates whether the input string represents an IPv7 address that supports TLA according to Part 1.
        /// </summary>
        /// <returns></returns>
        public bool SupportsTla()
        {
            // Can be condensed into an expression body, but this is easier to read.
            bool containsAbbaSegmentsInHyperNetSegment = HyperNetSegments.Any(ContainsAbba);
            bool containsAbbaSegments = Segments.Any(ContainsAbba);
            return containsAbbaSegments && !containsAbbaSegmentsInHyperNetSegment;
        }

        /// <summary>
        /// Determines whether the specified input contains a string in the pattern "abba".
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns>
        ///   <c>true</c> if the specified input contains "abba" pattern; otherwise, <c>false</c>.
        /// </returns>
        public bool ContainsAbba(string input)
        {
            // Check for abba pattern.
            char[] segment = input.ToCharArray();
            for (var i = 0; i < segment.Length - 3; i++)
            {
                // Given 4 characters abcd, check that a==d and b==c
                if (segment[i].Equals(segment[i + 3]) && segment[i + 1].Equals(segment[i + 2]))
                {
                    // abba pattern has been detected
                    // Return false if a==b
                    return !segment[i].Equals(segment[i + 1]);
                }
            }

            // Failed to find abba pattern
            return false;
        }
    }
}