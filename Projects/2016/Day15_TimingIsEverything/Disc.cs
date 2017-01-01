#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 8:21 PM
#endregion

namespace Day15_TimingIsEverything
{
    class Disc
    {
        #region Constructors
        public Disc(int sides, int position)
        {
            Sides = sides;
            Position = position;
        }
        #endregion

        #region Properties
        public bool HasCapsule { get; set; }
        public int Position { get; private set; }
        public int Sides { get; set; }
        #endregion

        public void NextPostion()
        {
            Position++;
            if (Position == Sides)
            {
                Position = 0;
            }
        }
    }
}