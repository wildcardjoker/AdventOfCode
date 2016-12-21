#region Information

// AdventOfCode: Day21_ScrambledLettersAndHash
// Created: 2016-12-21
// Modified: 2016-12-21 8:45 PM
#endregion

#region Using Directives
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day21_ScrambledLettersAndHash
{
    class Program
    {
        #region  Fields
        private static readonly List<char> Input = "abcde".ToList();
        private static string[] Instructions = File.ReadAllLines("testinput.txt");
        #endregion

        static void Main(string[] args) {}

        static void SwapPosXPosY(int x, int y)
        {
            char temp = Input[x];
            Input[x] = Input[y];
            Input[y] = temp;
        }

        static void SwapLetterWithLetter(char a, char b)
        {
            int indexA = Input.IndexOf(a);
            int indexB = Input.IndexOf(b);
            char temp = Input[indexA];
            Input[indexA] = Input[indexB];
            Input[indexB] = temp;
        }

        static void RotateLeft(int steps) {}
        static void RotateRight(int steps) {}
        static void RotateOnPosition(char c) {}
        static void ReversePositionsXThroughY(int x, int y) {}
        static void MovePosXToPosY(int x, int y) {}
    }
}