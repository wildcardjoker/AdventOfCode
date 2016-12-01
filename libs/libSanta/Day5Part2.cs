#region Information

// AdventOfCode: libSanta
// Created: 2015-12-05
// Modified: 2015-12-05 11:13 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
#endregion

#region Using Directives
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
        /// <remarks>
        ///     So close, yet so far! Previous regular expression attempts would match some (not all) patterns,
        ///     but returned FALSE for some matches because I checked for more than one match.
        ///     The regular expression matches both pairs as a single match, causing the method to return fewer matches than I
        ///     should have done.
        ///     Thanks to https://www.reddit.com/user/gegtik for his regex pattern
        ///     https://www.reddit.com/r/adventofcode/comments/3viazx/day_5_solutions/cxnt4go.
        /// </remarks>
        public bool MatchTwoLetters(string s)
            => new Regex(@"(\w\w).*\1").Match(s).Success;

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