#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-15 9:28 PM
#endregion

namespace Day15_TimingIsEverything
{
    class Disc
    {
        #region Constructors
        public Disc(int id, int sides, int position)
        {
            Id = id;
            Sides = sides;
            Position = position;
        }
        #endregion

        #region Properties
        public int Id { get; set; }
        public int Position { get; private set; }
        public int Sides { get; set; }
        #endregion

        public void NextPostiion()
        {
            Position++;
            if (Position == Sides)
            {
                Position = 0;
            }
        }
    }
}