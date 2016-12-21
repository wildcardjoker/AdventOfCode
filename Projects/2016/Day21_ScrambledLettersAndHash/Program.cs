#region Information

// AdventOfCode: Day21_ScrambledLettersAndHash
// Created: 2016-12-21
// Modified: 2016-12-21 10:02 PM
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Day21_ScrambledLettersAndHash
{
    class Program
    {
        #region  Fields
        private static readonly List<char> Input = "abcde".ToList();
        private static readonly string[] Instructions = File.ReadAllLines("testinput.txt");
        private static readonly Regex NumberRegex = new Regex(@"\d+");
        #endregion

        static void Main(string[] args)
        {
            foreach (string instruction in Instructions)
            {
                ProcessInstruction(instruction);
            }
            Console.WriteLine($"Scrambled password: {new string(Input.ToArray())}");
            Console.ReadKey();
        }

        static void ProcessInstruction(string instruction)
        {
            MatchCollection matches = NumberRegex.Matches(instruction);

            // Can't use a switch statement on substring.
            if (instruction.StartsWith("swap position"))
            {
                SwapPosXPosY(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value));
                return;
            }
            if (instruction.StartsWith("swap letter"))
            {
                string[] words = instruction.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                SwapLetterWithLetter(words[2][0], words[5][0]);
                return;
            }
            if (instruction.StartsWith("rotate left"))
            {
                RotateLeft(Convert.ToInt32(matches[0].Value));
                return;
            }
            if (instruction.StartsWith("rotate right"))
            {
                RotateRight(Convert.ToInt32(matches[0]));
                return;
            }
            if (instruction.StartsWith("rotate based"))
            {
                RotateOnPosition(instruction.Last());
                return;
            }
            if (instruction.StartsWith("reverse"))
            {
                ReversePositionsXThroughY(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value));
                return;
            }

            // Only one instruction left - move position x to position y
            MovePosXToPosY(Convert.ToInt32(matches[0].Value), Convert.ToInt32(matches[1].Value));
        }

        #region Scramblers
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
            RotateRight(index + (index >= 4 ? 2 : 1));
        }

        static void ReversePositionsXThroughY(int x, int y)
        {
            // Reverse parameters are index,count.
            // Without the +1, Reverse() misses a character.
            Input.Reverse(x, y + 1);
        }

        static void MovePosXToPosY(int x, int y)
        {
            char temp = Input[x];
            Input.RemoveAt(x);
            Input.Insert(y, temp);
        }
        #endregion
    }
}