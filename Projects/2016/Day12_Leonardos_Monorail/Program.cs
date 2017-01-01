// AdventOfCode: Day12_Leonardos_Monorail
// Created: 2016-12-13
// Modified: 2016-12-13 8:01 AM

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

#endregion

namespace Day12_Leonardos_Monorail
{
    class Program
    {
        #region  Fields
#if TEST
        private static readonly List<string> Instructions = File.ReadAllLines("testinput.txt").ToList();
#else
        private static readonly List<string> Instructions = File.ReadAllLines("input.txt").ToList();
#endif

        private static readonly Dictionary<string, int> Registers = new Dictionary<string, int>
                                                                    {
                                                                        {"a", 0},
                                                                        {"b", 0},
                                                                        {"c", 0},
                                                                        {"d", 0}
                                                                    };
        #endregion

        static void Main(string[] args)
        {
            var index = 0;
            var part2 = true;
            if (part2)
            {
                Registers["c"] = 1;
            }
            Stopwatch sw = Stopwatch.StartNew();
            while (index < Instructions.Count)
            {
                string[] parts = Instructions[index].ToLower()
                                                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var nextStep = true;
                switch (parts[0])
                {
                    case "cpy":

                        // Copy value
                        // Is value hardcoded or the contents of a register?
                        int value;
                        if (!int.TryParse(parts[1], out value))
                        {
                            // Use contents of register.
                            value = Registers[parts[1]];
                        }
                        Registers[parts[2]] = value;

                        break;
                    case "inc":

                        // Increase value of register by 1
                        Registers[parts[1]]++;
                        break;
                    case "dec":

                        // Decrease value of register by 1
                        Registers[parts[1]]--;
                        break;
                    case "jnz":

                        // Jump if not zero
                        // If register does not exist, use literal value
                        int registerValue = Registers.ContainsKey(parts[1])
                                                ? Registers[parts[1]]
                                                : Convert.ToInt32(parts[1]);
                        if (registerValue != 0)
                        {
                            index += Convert.ToInt32(parts[2]);
                            nextStep = false;
                        }

                        break;
                }
                if (nextStep)
                {
                    index++;
                }
            }
            sw.Stop();
            DisplayRegisters();
            Console.WriteLine($"Finished. Total time: {new TimeSpan(sw.ElapsedTicks):g}");
            Console.ReadKey();
        }

        private static void DisplayRegisters()
        {
            Console.Clear();
            Console.WriteLine("Register values:");
            foreach (KeyValuePair<string, int> register in Registers)
            {
                Console.WriteLine($"{register.Key.PadRight(5)}{register.Value.ToString().PadLeft(5)}");
            }
        }
    }
}