#region Information

// AdventOfCode: Day10_BalanceBots
// Created: 2016-12-10
// Modified: 2016-12-11 9:46 AM
#endregion

//#define TEST

#region Using Directives
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace Day10_BalanceBots
{
    class Program
    {
        #region  Fields
        private static readonly Regex RuleRegex = new Regex(@"\S+\s+\d+");
        private static readonly Regex BotRegex = new Regex(@"(\d+)");
        private static List<string> _botSetupList;
        private const int LowChipToFind = 17;
        private const int HighChipToFind = 61;

        private static int _botId;
#if TEST
        private static readonly string[] Input = File.ReadAllLines("testinput.txt");
#else
        private static readonly string[] Input = File.ReadAllLines("input.txt");
#endif
        public static List<Bot> Bots = new List<Bot>();
        public static Dictionary<int, int> OutputsDictionary = new Dictionary<int, int>();
        public static Queue<string> Rules = new Queue<string>();
        #endregion

        static void Main(string[] args)
        {
            SetupBots();
            SetupRules();
            ProcessRules();
            foreach (Bot bot in Bots.OrderBy(x => x.Id))
            {
                Debug.WriteLine(bot.Id);
            }
            Console.WriteLine($"Bot {_botId} held both {LowChipToFind} and {HighChipToFind}");
            Console.WriteLine("Output bins:");
            Console.WriteLine($"{"Bin:".PadRight(15)}{"Value".PadRight(5)}");
            foreach (KeyValuePair<int, int> pair in OutputsDictionary.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{pair.Key.ToString().PadRight(15)}{pair.Value.ToString().PadLeft(5)}");
            }
            Console.WriteLine(
                $"\n\nOutput 0 * Output 1 * output 2 = {OutputsDictionary[0] * OutputsDictionary[1] * OutputsDictionary[2]}");
            Console.ReadKey();
        }

        private static void ProcessRules()
        {
            while (Rules.Any())
            {
                string rule = Rules.Dequeue();
                MatchCollection targets = RuleRegex.Matches(rule);
                if (!ProcessRule(targets))
                {
                    Rules.Enqueue(rule);
                }
            }
        }

        private static bool ProcessRule(MatchCollection collection)
        {
            int botId = Convert.ToInt32(collection[0].Value.Substring(3).Trim());
            if (!CreateBotIfNotExists(botId))
            {
                return false;
            }
            string lowRule = collection[1].Value;
            string lowDestination = lowRule.Substring(0, lowRule.IndexOf(" "));
            int lowDestinationId = Convert.ToInt32(lowRule.Substring(lowDestination.Length + 1));
            string highRule = collection[2].Value;
            string highDestination = highRule.Substring(0, highRule.IndexOf(" "));
            int highDestinationId = Convert.ToInt32(highRule.Substring(highDestination.Length + 1));

            var moveResult = false;
            Bot sourceBot = GetBot(botId);

            // Check that source bot has two chips.
            if (sourceBot.Values.Count != 2)
            {
                return false;
            }

            // Check if bot is holding the two chips we need.
            if (sourceBot.Values.Min() == LowChipToFind && sourceBot.Values.Max() == HighChipToFind)
            {
                _botId = sourceBot.Id;
                Console.WriteLine($"****** Bot {_botId} has both chips.");
            }
            Console.WriteLine($"Bot {botId} passes low to {lowRule}, and high to {highRule}");

            switch (lowDestination)
            {
                case "bot":
                    moveResult = PassToBot(botId, lowDestinationId);
                    break;
                case "output":
                    moveResult = PassToOutput(sourceBot, lowDestinationId);
                    break;
            }
            switch (highDestination)
            {
                case "bot":
                    moveResult = moveResult && PassToBot(botId, highDestinationId);
                    break;
                case "output":
                    moveResult = moveResult && PassToOutput(sourceBot, highDestinationId);
                    break;
            }

            return moveResult;

            // Return true if Bot exists and can pass values
        }

        private static bool PassToOutput(Bot sourceBot, int outputId)
        {
            if (!OutputsDictionary.ContainsKey(outputId))
            {
                OutputsDictionary.Add(outputId, -1);
            }
            OutputsDictionary[outputId] = sourceBot.Values.Min();
            sourceBot.Values.Remove(sourceBot.Values.Min());
            return true;
        }

        private static void CreateOutputIfNotExist(int outputId) {}

        private static Bot GetBot(int id)
        {
            Bot bot = Bots.FirstOrDefault(x => x.Id == id);
            if (bot != null) return bot;
            bot = new Bot(id);
            Bots.Add(bot);
            return bot;
        }

        private static bool PassToBot(int sourceId, int destinationId)
        {
            Bot source = GetBot(sourceId);
            Bot destination = GetBot(destinationId);

            destination.Values.Add(source.Values.Min());
            source.Values.Remove(source.Values.Min());
            return true;
        }

        private static bool CreateBotIfNotExists(int botId)
        {
            if (Bots.Any(x => x.Id == botId)) return true;
            Bots.Add(new Bot(botId));
            return false;
        }

        private static void SetupRules()
        {
            IEnumerable<string> ruleList = Input.Except(_botSetupList);
            foreach (string s in ruleList)
            {
                Rules.Enqueue(s);
            }
        }

        private static void SetupBots()
        {
            _botSetupList = Input.Where(x => x.StartsWith("Value", StringComparison.CurrentCultureIgnoreCase)).ToList();
            foreach (string s in _botSetupList)
            {
                MatchCollection values = BotRegex.Matches(s);
                int value = Convert.ToInt32(values[0].Value);
                int botId = Convert.ToInt32(values[1].Value);
                Bot bot = Bots.FirstOrDefault(x => x.Id == botId);
                if (bot == null)
                {
                    Bots.Add(new Bot(botId, value));
                }
                else
                {
                    bot.Values.Add(value);
                }
            }
        }
    }
}