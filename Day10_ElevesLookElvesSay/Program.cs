#region Information

// AdventOfCode: Day10_ElevesLookElvesSay
// Created: 2015-12-10
// Modified: 2015-12-10 10:20 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
#endregion

#region Using Directives
using System;
using System.Diagnostics;

#endregion

namespace Day10_ElevesLookElvesSay
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = "1113222113";
            string output = input;

            Console.Write("Crunching numbers...");

            for (int i = 0; i < 40; i++)
            {
                string s = string.Empty;
                char[] chars = output.ToCharArray();
                int j = 0;
                int k = 1;
                while (k < chars.Length)
                {
                    int count = 1;
                    while (chars[j] == chars[k])
                    {
                        count++;
                        j++;
                        k++;
                    }
                    s += $"{count}{chars[j]}";
                    j++;
                    k++;
                }
                if (k == chars.Length)
                {
                    s += $"1{chars[j]}";
                }
                output = s;
            }
            string answer = $"Length: {output} ({output.Length} characters).";
            Debug.WriteLine(answer);
            Console.WriteLine(answer);
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
    }
}