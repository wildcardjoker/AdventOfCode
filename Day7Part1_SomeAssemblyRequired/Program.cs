#region Information

// AdventOfCode: Day7Part1_SomeAssemblyRequired
// Created: 2015-12-07
// Modified: 2015-12-07 9:29 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#endregion

namespace Day7Part1_SomeAssemblyRequired
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Func<ushort>> dict = new Dictionary<string, Func<ushort>>();
            Dictionary<string, ushort> values = new Dictionary<string, ushort>();
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] split = line.Split(' ');
                    string target = split[split.Length - 1];

                    switch (split.Length)
                    {
                        case 3:
                            ushort val;
                            if (ushort.TryParse(split[0], out val))
                            {
                                dict.Add(target, () => val);
                                values.Add(target, val);
                            }
                            else
                            {
                                dict.Add(target, () =>
                                                 {
                                                     if (values.ContainsKey(target))
                                                     {
                                                         return values[target];
                                                     }
                                                     ushort res = dict[split[0]].Invoke();
                                                     values.Add(target, res);
                                                     return res;
                                                 });
                            }
                            break;
                        case 4:
                            dict.Add(target, () => (ushort) (~dict[split[1]].Invoke()));
                            break;
                        case 5:
                            switch (split[1])
                            {
                                case "AND":
                                    dict.Add(target, () =>
                                                     {
                                                         if (values.ContainsKey(target))
                                                         {
                                                             return values[target];
                                                         }
                                                         ushort res =
                                                             (ushort)
                                                             ((ushort.TryParse(split[0], out val)
                                                                   ? val
                                                                   : dict[split[0]].Invoke()) & dict[split[2]].Invoke());
                                                         values.Add(target, res);
                                                         return res;
                                                     });
                                    break;
                                case "OR":
                                    dict.Add(target, () =>
                                                     {
                                                         if (values.ContainsKey(target))
                                                         {
                                                             return values[target];
                                                         }
                                                         ushort res =
                                                             (ushort)
                                                             ((ushort.TryParse(split[0], out val)
                                                                   ? val
                                                                   : dict[split[0]].Invoke()) | dict[split[2]].Invoke());
                                                         values.Add(target, res);
                                                         return res;
                                                     });
                                    break;
                                case "LSHIFT":
                                    dict.Add(target, () =>
                                                     {
                                                         if (values.ContainsKey(target))
                                                         {
                                                             return values[target];
                                                         }
                                                         ushort res =
                                                             (ushort) (dict[split[0]].Invoke() << int.Parse(split[2]));
                                                         values.Add(target, res);
                                                         return res;
                                                     });
                                    break;
                                case "RSHIFT":
                                    dict.Add(target, () =>
                                                     {
                                                         if (values.ContainsKey(target))
                                                         {
                                                             return values[target];
                                                         }
                                                         ushort res =
                                                             (ushort) (dict[split[0]].Invoke() >> int.Parse(split[2]));
                                                         values.Add(target, res);
                                                         return res;
                                                     });
                                    break;
                            }
                            break;
                    }
                }
            }

            foreach (KeyValuePair<string, Func<ushort>> pair in dict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value.Invoke()}");
            }
            Console.WriteLine(dict["a"].Invoke());
            Console.ReadLine();
        }
    }
}