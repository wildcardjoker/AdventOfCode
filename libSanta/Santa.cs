#region Information

// AdventOfCode: libSanta
// Created: 2015-12-05
// Modified: 2015-12-05 2:30 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Linq;

#endregion

namespace libSanta
{
    public class Santa
    {
        #region  Fields
        private static readonly char[] Vowels = "aeiou".ToCharArray();
        private static readonly string[] BadStrings = {"ab", "cd", "pq", "xy"};
        #endregion

        public bool IsNiceString(string s)
        {
            return ContainsDoubleLetter(s) && ContainsVowels(s, 3) && !ContainsBadStrings(s);
        }

        /// <summary>
        ///     Does string contain specified number of vowels?
        /// </summary>
        /// <param name="s">string to process</param>
        /// <param name="num"></param>
        /// <returns></returns>
        private static bool ContainsVowels(string s, int num)
        {
            return s.Count(c => Vowels.Contains(c)) >= num;
        }

        /// <summary>
        ///     Does string contain at least one letter that appears twice in a row?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static bool ContainsDoubleLetter(string s)
        {
            int j = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                j++;
                if (s[i].Equals(s[j]))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        ///     Does string contain any strings on the Naughty List?
        /// </summary>
        /// <param name="s">string to process</param>
        /// <returns></returns>
        private static bool ContainsBadStrings(string s)
        {
            return BadStrings.Any(s.Contains);
        }
    }
}