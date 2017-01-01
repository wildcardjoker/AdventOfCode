#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 8:49 PM
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
        private static readonly string[] Input = File.ReadAllLines("input.txt");
        private static List<Disc> _discs;
        #endregion

        static void Main(string[] args)
        {
            SetupDiscs();
            int partOneResult = GetTime();
            SetupDiscs(true);
            int partTwoResult = GetTime();
            Console.WriteLine($"Part 1: Press button at {partOneResult} to grab a capsule!");
            Console.WriteLine($"Part 2: Press button at {partTwoResult} to grab a capsule!");
            Console.ReadKey();
        }

        private static void SetupDiscs(bool part2 = false)
        {
            _discs = new List<Disc>();
            var regex = new Regex(@"\d+");
            foreach (string s in Input)
            {
                MatchCollection matches = regex.Matches(s);
                _discs.Add(new Disc(Convert.ToInt32(matches[1].Value), Convert.ToInt32(matches[3].Value)));
            }
            if (part2)
            {
                _discs.Add(new Disc(11, 0));
            }
        }

        private static int GetTime()
        {
            // Start timer
            var time = 0;

            // Keep going until the ball has fallen through all of the discs.
            while (!_discs.Last().HasCapsule)
            {
                // Each disc rotates to the next position.
                foreach (Disc disc in _discs)
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
                while (capsulePresent == false && index != _discs.Count - 1)
                {
                    //If this disc has a ball, record that fact
                    if (_discs[index].HasCapsule)
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
                    // If the first disc is at position 0, a capsule has fallen into it.
                    _discs[0].HasCapsule = _discs[0].Position == 0;
                    continue;
                }

                // Check each disc.
                for (var i = 0; i < _discs.Count - 1; i++)
                {
                    // If the disc doesn't have a capsule,
                    // try the next one.
                    if (!_discs[i].HasCapsule) continue;

                    // Disc has a capsule.
                    // It drops to the next disc, or bounces away
                    _discs[i].HasCapsule = false;
                    if (_discs[i + 1].Position != 0)
                    {
                        break; // Ball bounced away!
                    }

                    // Ball fell through to the next disc.
                    _discs[i + 1].HasCapsule = true;
                    break;
                }
            }

            // Subtract number of discs from timer
            return time - _discs.Count;
        }
    }
}