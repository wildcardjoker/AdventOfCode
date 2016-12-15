#region Information

// AdventOfCode: Day15_TimingIsEverything
// Created: 2016-12-15
// Modified: 2016-12-16 6:30 AM
#endregion

namespace Day15_TimingIsEverything
{
    class Disc
    {
        #region  Fields
        public int ID;
        public int POS_START;
        public int POS_TOTAL;
        #endregion

        public bool isSpace(int Time, int DiskNum, int Total, int Start)
        {
            if ((Time + DiskNum + Start) % Total == 0)
                return true;

            return false;
        }
    }
}