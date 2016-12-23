#region Information

// AdventOfCode: Day22_GridComputing
// Created: 2016-12-23
// Modified: 2016-12-23 9:42 PM
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
            var nodeCount = 0;
            foreach (Node node in Nodes.Where(x => x.Used != 0))
            {
                nodeCount += Nodes.Count(x => !(x.PosX == node.PosX && x.PosY == node.PosY) && x.Available >= node.Used);
            }
            Console.WriteLine($"{Nodes.Count} nodes found.");
            Console.WriteLine($"{Nodes.Count(x => x.Used != 0)} nodes are used.");
            Console.WriteLine($"{nodeCount} node pairs found.");
            Console.ReadKey();
        }
    }
}