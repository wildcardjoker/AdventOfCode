#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 6:38 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using libChristmasLight;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        /// <summary>
        ///     Create a grid Columns wide x Rows high
        /// </summary>
        private void CreateGrid()
        {
            for (int i = 0; i < Columns; i++)
            {
                for (int j = 0; j < Rows; j++)
                {
                    Lights.Add(new ChristmasLight(i, j));
                }
            }
        }
    }
}