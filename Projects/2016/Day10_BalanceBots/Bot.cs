#region Information

// AdventOfCode: Day10_BalanceBots
// Created: 2016-12-10
// Modified: 2016-12-10 10:11 PM
#endregion

#region Using Directives
using System.Collections.Generic;

#endregion

namespace Day10_BalanceBots
{
    public enum Destination
    {
        Bot,
        Output
    }

    class Bot
    {
        #region Constructors
        public Bot(int id, int? value = null)
        {
            Id = id;
            Values = new List<int>(2);
            if (value != null)
            {
                Values.Add((int) value);
            }
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public List<int> Values { get; set; }
        #endregion
    }
}