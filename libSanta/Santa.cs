#region Information

// AdventOfCode: libSanta
// Created: 2015-12-05
// Modified: 2015-12-05 1:54 PM
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
        private readonly string[] _badStrings = {"ab", "cd", "pq", "xy"};
        private readonly char[] _vowels = "aeiuo".ToCharArray();
        #endregion

        public bool IsNiceString(string s)
        {
            bool doubleLetter = false;
            int j = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                j++;
                if (s[i].Equals(s[j]))
                {
                    doubleLetter = true;
                    break;
                }
            }
            return doubleLetter && s.Count(c => _vowels.Contains(c)) >= 3 &&
                   _badStrings.Any(x => _badStrings.Contains(x));
        }
    }
}