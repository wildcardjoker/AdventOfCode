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
        #region Fields
        private static List<int> _input = new List<int>();
        #endregion

        private static void Main(string[] args)
        {
            // Sample input
            // _input = new[] {1721, 979, 366, 299, 675, 1456}.ToList();
            _input = File.ReadAllLines("input.txt").Select(num => Convert.ToInt32(num)).ToList();

            Part1();
        }

        private static void Part1()
        {
            var sumTarget = 2020;
            var i         = 0;
            var num1      = 0;
            var num2      = 0;
            while (num1 + num2 != sumTarget)
            {
                num1 = _input[i];
                var targetNum = sumTarget - num1;
                if (_input.Contains(targetNum))
                {
                    num2 = targetNum;
                }

                i++;
            }

            Console.WriteLine($"Found entries {num1} and {num2} in {i} tries. Day 1 Part 1 Result: {num1 * num2}");
        }
    }
}