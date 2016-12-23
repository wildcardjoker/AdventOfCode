#region Information

// AdventOfCode: Day22_GridComputing
// Created: 2016-12-23
// Modified: 2016-12-23 9:18 PM
#endregion

#region Using Directives
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day22_GridComputing
{
    class Program
    {
        #region  Fields
        private static readonly List<Node> Nodes = File.ReadAllLines("input.txt").Select(x => new Node(x)).ToList();
        #endregion

        static void Main(string[] args) {}
    }
}