#region Information

// AdventOfCode: Day4_SecurityThroughObscurity
// Created: 2016-12-04
// Modified: 2016-12-04 2:30 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day4_SecurityThroughObscurity
{
    /// <summary>
    ///     Calculate checksum based on character occurrence.
    /// </summary>
    class Program
    {
        #region  Fields
        private static List<string> _input;
        private static readonly List<Room> Rooms = new List<Room>();
        #endregion

        /// <summary>
        ///     Gets the test input.
        /// </summary>
        /// <returns></returns>
        private static List<string> GetTestInput() => new List<string>
                                                      {
                                                          "aaaaa-bbb-z-y-x-123[abxyz]",
                                                          "a-b-c-d-e-f-g-h-987[abcde]",
                                                          "not-a-real-room-404[oarel]",
                                                          "totally-real-room-200[decoy]"
                                                      };

        static void Main(string[] args)
        {
            // Test
            //_input = GetTestInput();
            _input = File.ReadAllLines("input.txt").ToList();

            foreach (string s in _input)
            {
                var room = new Room(s);
                Console.WriteLine(room);
                Rooms.Add(room);
            }
            int roomSectorIdTotal = Rooms.Where(x => x.IsReal).Sum(x => x.SectorId);
            Console.WriteLine($"Sum of all real Room Sector IDs: {roomSectorIdTotal}");
            Console.ReadKey();
        }
    }
}