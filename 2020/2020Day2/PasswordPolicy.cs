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
            Password = input.Substring(input.LastIndexOf(' '));
        }

        #endregion

        #region Properties
        public bool IsValid
        {
            get
            {
                var charCount = Password.Count(x => x.Equals(Letter));
                return charCount >= MinValue && charCount <= MaxValue;
            }
        }

        public char Letter {get; set;}

        public int MaxValue {get; set;}

        public int MinValue {get; set;}

        public string Password {get; set;}
        #endregion
    }
}