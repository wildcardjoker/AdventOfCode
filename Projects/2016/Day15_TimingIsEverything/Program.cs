#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 6:33 AM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;

#endregion

// Solution created by Reddit user _Le1_ https://www.reddit.com/user/_Le1_
// See https://www.reddit.com/r/adventofcode/comments/5ifn4v/2016_day_15_solutions/db7w80l/
// I take no credit for this code, as I failed to find the solution for this puzzle.

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
            start();

            //Console.WriteLine($"Press button at {partOneResult} to grab a capsule!");
            Console.ReadKey();
        }

        static void start(bool part2 = false)
        {
            string[] input = File.ReadAllLines(@"input.txt");
            var DiscsList = new List<Disc>();

            foreach (string line in input)
            {
                string[] str = line.Split();

                var dsk = new Disc();
                dsk.POS_TOTAL = Convert.ToInt32(str[3]);
                dsk.POS_START = Convert.ToInt32(str[11].Substring(0, 1));
                dsk.ID = Convert.ToInt32(str[1].Substring(1, 1));
                DiscsList.Add(dsk);
            }

            if (part2)
            {
                var dsk = new Disc();
                dsk.POS_TOTAL = 11;
                dsk.POS_START = 0;
                dsk.ID = DiscsList.Count + 1;
                DiscsList.Add(dsk);
            }

            var time = 0;
            var working = true;
            while (working)
            {
                foreach (Disc Disc in DiscsList)
                {
                    int time1 = time;
                    if (Disc.isSpace(time1, Disc.ID, Disc.POS_TOTAL, Disc.POS_START))
                    {
                        time1++;
                        if (Disc.ID == DiscsList.Count)
                        {
                            working = false;
                            Console.WriteLine("Done on time: {0}", time);
                        }
                    }
                    else
                    {
                        Console.WriteLine("[Start Time: {0}]  Capsule bounced to Disc #{1}", time, Disc.ID);
                        break;
                    }
                }

                time++;
            }
        }
    }
}