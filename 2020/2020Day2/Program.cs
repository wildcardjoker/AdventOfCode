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
            var inputFilename = "Input.txt"; // "Sample.txt";
            _input = File.ReadAllLines(inputFilename).Select(x => new PasswordPolicy(x)).ToList();
            PartOne();
        }

        private static void PartOne()
        {
            var validPasswords = _input.Count(x => x.IsValid);
            Console.WriteLine($"Part One: Found {validPasswords} valid passwords.");
        }
    }
}