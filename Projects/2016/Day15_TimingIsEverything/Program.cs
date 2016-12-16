#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 6:58 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

// Contains code written by Reddit user /u/Tobi202 - https://www.reddit.com/user/Tobi1202
// See https://www.reddit.com/r/adventofcode/comments/5ifn4v/2016_day_15_solutions/db82hw3/
// I've added excessive comments to ensure that I understand how it works,
// but I take no credit for the code itself.

namespace Day15_TimingIsEverything
{
    class Program
    {
        #region  Fields
        private static readonly string[] Input = File.ReadAllLines("testinput.txt");
        private static readonly List<Disc> Discs = new List<Disc>();
        #endregion

        static void Main(string[] args)
        {
            SetupDiscs();
            int partOneResult = GetTimePartOne();
            Console.WriteLine($"Press button at {partOneResult} to grab a capsule!");
            Console.ReadKey();
        }

        private static void SetupDiscs()
        {
            var regex = new Regex(@"\d+");
            foreach (string s in Input)
            {
                MatchCollection matches = regex.Matches(s);
                Discs.Add(new Disc(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value),
                                   Convert.ToInt32(matches[3].Value)));
            }
        }

        private static int GetTimePartOne()
        {
            // Start timer
            var time = 0;

            // Keep going until the ball has fallen through all of the discs.
            while (!Discs.Last().HasCapsule)
            {
                // Each disc rotates to the next position.
                foreach (Disc disc in Discs)
                {
                    disc.NextPostion();
                }

                // Tick
                time++;

                // Capsule falls
                var capsulePresent = false;

                // Start with first disc
                var index = 0;

                // While a capsule has not fallen through, and there are still discs to check
                while (!capsulePresent && index != Discs.Count - 1)
                {
                    //If this disc has a ball, record that fact
                    if (Discs[index].HasCapsule)
                    {
                        capsulePresent = true;
                    }

                    // Go to the next one
                    index++;
                }

                // If a capsule isn't passing through the discs already,
                // maybe one can begin it's journey.
                if (!capsulePresent)
                {
                    // Is the first disc in the correct position?
                    if (Discs[0].Position == 0)
                    {
                        // Yes it is
                        Discs[0].HasCapsule = true;
                    }
                    continue;
                }

                // Check each disc.
                for (var i = 0; i < Discs.Count - 1; i++)
                {
                    // If a disc has a capsule...
                    if (Discs[i].HasCapsule)
                    {
                        // It drops to the next disc, or bounces away
                        Discs[i].HasCapsule = false;
                        if (Discs[i + 1].Position != 0)
                        {
                            break; // Ball bounced away!
                        }

                        // Ball fell through to the next disc.
                        Discs[i + 1].HasCapsule = true;
                    }
                }
            }

            // Subtract number of discs from timer
            return time - Discs.Count;
        }
    }
}