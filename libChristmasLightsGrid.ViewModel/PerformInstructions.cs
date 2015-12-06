#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 10:31 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Collections.Generic;
using System.Linq;
using libChristmasLight;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        private void TurnOnRange()
        {
            IEnumerable<ChristmasLight> range =
                Lights.Where(
                    light =>
                    light.PosX <= RangeToModify.EndX && light.PosX >= RangeToModify.StartX &&
                    light.PosY >= RangeToModify.StartY && light.PosY <= RangeToModify.EndY);

            foreach (ChristmasLight light in range)
            {
                light.TurnOn();
            }
        }
    }
}