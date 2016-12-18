#region Information

// AdventOfCode: Day18_LikeARogue
// Created: 2016-12-18
// Modified: 2016-12-18 7:09 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace Day18_LikeARogue
{
    class Program
    {
        #region  Fields
        private const int MaxRowsPartOne = 40;
        private const int MaxRowsPartTwo = 400000;
        private static char[] _trapTileSource = new char[3];

        private static readonly char[] StartRow =
            ".^^..^...^..^^.^^^.^^^.^^^^^^.^.^^^^.^^.^^^^^^.^...^......^...^^^..^^^.....^^^^^^^^^....^^...^^^^..^"
                .ToCharArray();
        #endregion

        static void Main(string[] args)
        {
            int maxRows = MaxRowsPartTwo;
            Console.Title = "Advent Of Code: Day 18";
            CalculateSafeTiles(MaxRowsPartOne);
            CalculateSafeTiles(MaxRowsPartTwo);
            Console.ReadKey();
        }

        private static void CalculateSafeTiles(int maxRows)
        {
            char[] row = StartRow;
            var numRows = 0;
            var totalSafeTiles = 0;
            while (numRows < maxRows)
            {
                int safeTileCount = row.Count(c => c.Equals('.'));

                totalSafeTiles += safeTileCount;
                var nextRow = new List<char>();
                for (var i = 0; i < row.Length; i++)
                {
                    _trapTileSource = i == 0
                                          ? new[] {'.', row[i], row[i + 1]}
                                          : i == row.Length - 1
                                              ? new[] {row[i - 1], row[i], '.'}
                                              : new[] {row[i - 1], row[i], row[i + 1]};
                    nextRow.Add(SetTile());
                }
                row = nextRow.ToArray();
                numRows++;
            }
            Console.WriteLine($"In a room with {maxRows} rows:");
            Console.WriteLine($"{$"There are {totalSafeTiles} safe tiles".PadLeft(6)}");
            ;
        }

        private static char SetTile()
        {
            bool isTrap = LeftAndCentreTrapsRightNot() || CentreAndRightTrapsLeftNot() || LeftOnlyTrap() ||
                          RightOnlyTrap();
            return isTrap ? '^' : '.';
        }

        private static bool LeftAndCentreTrapsRightNot()
            => LeftIsTrap() && CenterIsTrap() && !RightIsTrap();

        private static bool CentreAndRightTrapsLeftNot()
            => (!LeftIsTrap()) && CenterIsTrap() && RightIsTrap();

        private static bool LeftOnlyTrap() => LeftIsTrap() && !CenterIsTrap() && !RightIsTrap();
        private static bool RightOnlyTrap() => !LeftIsTrap() && !CenterIsTrap() && RightIsTrap();

        private static bool LeftIsTrap()
            => IsTrapTile(_trapTileSource[0]);

        private static bool CenterIsTrap()
            => IsTrapTile(_trapTileSource[1]);

        private static bool RightIsTrap()
            => IsTrapTile(_trapTileSource[2]);

        private static bool IsTrapTile(char c) => c.Equals('^');
    }
}