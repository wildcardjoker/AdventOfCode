namespace Day11_Corporate_Policy
{
    #region Using Directives
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using Humanizer;
    #endregion

    internal class Program
    {
        #region Fields
        private static readonly char[] InvalidChars = {'i', 'l', 'o'};

        private static readonly List<string> InvalidStraights = new List<string>
        {
            "ghj",
            "hjk",
            "jkm",
            "kmn",
            "mnp",
            "npq"
        };

        private static List<string> _straights;
        #endregion

        private static bool ContainsTwoPairs(string password)
        {
            var pairs = 0;
            for (var i = 0; i < password.Length - 1; i++)
            {
                if (password[i] != password[i + 1])
                {
                    continue;
                }

                // We found a pair; increment the counter and skip the next character
                pairs++;
                i++;
            }

            // Did we find at least two pairs?
            return pairs >= 2;
        }

        private static string IncrementPassword(string password)
        {
            // Create an array of characters from the password
            var passwordArray = password.ToCharArray();

            // Start at the end of the array and work backwards
            for (var i = passwordArray.Length - 1; i >= 0; i--)
            {
                // If the character is 'z', set it to 'a' and continue to the next character
                if (passwordArray[i] == 'z')
                {
                    passwordArray[i] = 'a';
                }
                else
                {
                    // Increment the character to the next letter of the alphabet.
                    passwordArray[i]++;

                    // Is the new character one of the invalid characters?
                    if (InvalidChars.Contains(passwordArray[i]))
                    {
                        // If so, increment the character again
                        passwordArray[i]++;
                    }

                    break;
                }
            }

            return new string(passwordArray);
        }

        private static void Main(string[] args)
        {
            // Get your puzzle input from the command line (paste into the Debug tab) or paste it into your code
            // Don't post it online!
            var password = args[0];

            // Set up an array of valid characters
            var chars = "abcdefghjkmnpqrstuvwxyz".ToArray();
            _straights = new List<string>();

            // Create an array of all possible straights
            for (var i = 0; i < chars.Length - 2; i++)
            {
                _straights.Add(new string(new[] {chars[i], chars[i + 1], chars[i + 2]}));
            }

            // Remove straights that contain invalid characters
            _straights = _straights.Except(InvalidStraights).ToList();

            var sw = Stopwatch.StartNew();

            // Increment password at least once; the input is always invalid.
            password = IncrementPassword(password);

            while (InvalidChars.Any(password.Contains) || !_straights.Any(password.Contains) || !ContainsTwoPairs(password))
            {
                password = IncrementPassword(password);

                //Console.WriteLine(password); // useful to see generated passwords, but slows the program down significantly
            }

            sw.Stop();
            Console.WriteLine(password);
            Console.WriteLine($"Elapsed time: {sw.Elapsed.Humanize()}");
        }
    }
}