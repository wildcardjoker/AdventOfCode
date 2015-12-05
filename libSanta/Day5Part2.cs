#region Information

// AdventOfCode: libSanta
// Created: 2015-12-05
// Modified: 2015-12-05 10:28 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

#endregion

namespace libSanta
{
    public partial class Santa
    {
        public bool IsNiceString2(string s) => MatchTwoLetters(s) && MatchRepeatingCharacter(s);

        /// <summary>
        ///     Does string contain at least one letter that appears twice in a row?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool MatchTwoLetters(string s)
            => DuplicateFound(new Regex(@"(\w\w)"), s) || DuplicateFound(new Regex(@"(\w)\1"), s);

        private bool DuplicateFound(Regex regex, string s)
        {
            List<string> results = (from Match match in regex.Matches(s) select match.Value).ToList();
            return results.GroupBy(m => m).SelectMany(grp => grp.Skip(1)).Any();
        }

        /// <summary>
        ///     Match a string character between two matching characters.
        /// </summary>
        /// <param name="s">String to prcoess</param>
        /// <returns>True if match found.</returns>
        public bool MatchRepeatingCharacter(string s)
        {
            Regex regex = new Regex(@"(\w).\1");
            return regex.Match(s).Success;
        }
    }
}