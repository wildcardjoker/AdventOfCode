// 2020Day1

namespace _2020Day1
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    #endregion

    internal class Program
    {
        #region Constants
        private const int SumTarget = 2020;
        #endregion

        #region Fields
        private static List<int> _input = new List<int>();
        #endregion

        private static void Main(string[] args)
        {
            // Sample input
            // _input = new[] {1721, 979, 366, 299, 675, 1456}.ToList();
            _input = File.ReadAllLines("input.txt").Select(num => Convert.ToInt32(num)).ToList();
            Part1();
            Part2();
        }

        private static void Part1()
        {
            var i    = 0;
            var num1 = 0;
            var num2 = 0;
            while (num1 + num2 != SumTarget)
            {
                num1 = _input[i];
                var targetNum = SumTarget - num1;
                if (_input.Contains(targetNum))
                {
                    num2 = targetNum;
                }

                i++;
            }

            Console.WriteLine($"Found entries {num1} and {num2} in {i} tries. Day 1 Part 1 Result: {num1 * num2}");
        }

        private static void Part2()
        {
            var count = 0;
            var num1  = 0;
            var num2  = 0;
            var num3  = 0;
            var match = false;

            foreach (var inputNum in _input)
            {
                count++;
                if (match)
                {
                    break;
                }

                for (var i = 1; i < _input.Count - 2; i++)
                {
                    num1 = inputNum;
                    num2 = _input[i];
                    num3 = SumTarget - (num1 + num2);
                    if (num3 < 1)
                    {
                        continue;
                    }

                    if (!_input.Contains(num3))
                    {
                        continue;
                    }

                    match = true;
                    break;
                }
            }

            Console.WriteLine($"Found entries {num1}, {num2} and {num3} in {count} tries. Day 1 Part 2 Result: {num1 * num2 * num3}");
        }
    }
}