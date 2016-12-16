#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 6:14 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

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
            var time = 0;
            int startTime = time;
            var capsulePosition = 0;
            while (Discs.Any(x => x.Position != 0) && capsulePosition < Discs.Count)
            {
                foreach (Disc disc in Discs)
                {
                    disc.NextPostiion();
                    time++;
                }
                capsulePosition++;
                startTime = time;
            }
            return startTime;
        }
    }
}

}