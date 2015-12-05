#region Information

// AdventOfCode: libSanta
// Created: 2015-12-05
// Modified: 2015-12-05 9:21 PM
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
        public bool IsNiceString2(string s)
        {
            return MatchTwoLetters(s) && MatchRepeatingCharacter(s);
        }

        /// <summary>
        ///     Does string contain at least one letter that appears twice in a row?
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool MatchTwoLetters(string s)
        {
            Regex regex = new Regex(@"(\w\w)");
            var matches = regex.Matches(s);
            List<string> results = (from Match match in matches select match.Value).ToList();
            var duplicates = results.GroupBy(m => m).SelectMany(grp => grp.Skip(1));
            return duplicates.Any();
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