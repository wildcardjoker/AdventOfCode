#region Information

// AdventOfCode: Day21_ScrambledLettersAndHash
// Created: 2016-12-21
// Modified: 2016-12-21 9:09 PM
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

        static void RotateLeft(int steps)
        {
            for (var i = 0; i < steps; i++)
            {
                char temp = Input[0];
                Input.RemoveAt(0);
                Input.Add(temp);
            }
        }

        static void RotateRight(int steps)
        {
            int index = Input.Count - 1;
            for (var i = 0; i < steps; i++)
            {
                char temp = Input[index];
                Input.RemoveAt(index);
                Input.Insert(0, temp);
            }
        }

        static void RotateOnPosition(char c)
        {
            int index = Input.IndexOf(c);

            // Rotate index+1, +1 again if index>= 4
            RotateRight(index + index >= 4 ? 2 : 1);
        }

        static void ReversePositionsXThroughY(int x, int y)
        {
            Input.Reverse(x, y);
        }

        static void MovePosXToPosY(int x, int y)
        {
            char temp = Input[x];
            Input.RemoveAt(x);
            Input.Insert(y, temp);
        }
    }
}