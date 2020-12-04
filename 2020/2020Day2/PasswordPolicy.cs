// 2020Day2

namespace _2020Day2
{
    #region Using Directives
    using System;
    using System.Linq;
    #endregion

    public class PasswordPolicy
    {
        #region Constructors
        public PasswordPolicy(string input)
        {
            // Extract min/max
            var minMax = input.Substring(0, input.IndexOf(' ') + 1).Split('-');
            MinValue = Convert.ToInt32(minMax[0]);
            MaxValue = Convert.ToInt32(minMax[1]);
            Letter   = input[input.IndexOf(' ') + 1];
            Password = input.Substring(input.LastIndexOf(' ')).Trim();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Gets a value indicating whether this instance is valid for Part One (Sled password policy).
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is valid for sled; otherwise, <c>false</c>.
        /// </value>
        public bool IsValidForSled
        {
            get
            {
                var charCount = Password.Count(x => x.Equals(Letter));
                return charCount >= MinValue && charCount <= MaxValue;
            }
        }

        public bool IsValidForToboggan => Password[MinValue - 1].Equals(Letter) ^ Password[MaxValue - 1].Equals(Letter);

        public char Letter {get; set;}

        public int MaxValue {get; set;}

        public int MinValue {get; set;}

        public string Password {get; set;}
        #endregion
    }
}