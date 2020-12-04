// 2020Day2

namespace _2020Day2
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
        private static List<PasswordPolicy> _input;
        #endregion

        private static void Main(string[] args)
        {
            // var inputFilename = "Sample.txt";
            var inputFilename = "Input.txt";
            _input = File.ReadAllLines(inputFilename).Select(x => new PasswordPolicy(x)).ToList();
            PartOne();
            PartTwo();
        }

        private static void PartOne()
        {
            var validPasswords = _input.Count(x => x.IsValidForSled);
            Console.WriteLine($"Part One: Found {validPasswords} valid passwords.");
        }

        private static void PartTwo()
        {
            var validPasswords = _input.Count(x => x.IsValidForToboggan);
            Console.WriteLine($"Part Two: Found {validPasswords} valid passwords.");
        }
    }
}