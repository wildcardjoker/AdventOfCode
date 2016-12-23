#region Information

// AdventOfCode: Day22_GridComputing
// Created: 2016-12-23
// Modified: 2016-12-23 10:03 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day22_GridComputing
{
    class Program
    {
        #region  Fields
        private static readonly List<Node> Nodes =
            File.ReadAllLines("input.txt").Where(x => x.StartsWith("/dev")).Select(x => new Node(x)).ToList();
        #endregion

        static void Main(string[] args)
        {
            int nodeCount =
                Nodes.Where(x => x.Used != 0)
                     .Sum(
                         node =>
                             Nodes.Count(
                                 x => !(x.PosX == node.PosX && x.PosY == node.PosY) && x.Available >= node.Used));
            Console.WriteLine($"{Nodes.Count} nodes found.");
            Console.WriteLine($"{Nodes.Count(x => x.Used != 0)} nodes are used.");
            Console.WriteLine($"{nodeCount} node pairs found.");
            Console.Write("Part 2 solved using http://codepen.io/anon/pen/mOYdKJ");
            Console.WriteLine(
                "Part 2 code created by /u/AndrewGreenH at https://www.reddit.com/r/adventofcode/comments/5jor9q/2016_day_22_solutions/dbi1999/");
            Console.ReadKey();
        }
    }
}