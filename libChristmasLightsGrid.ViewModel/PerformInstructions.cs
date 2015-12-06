#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-07
// Modified: 2015-12-07 6:17 AM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Collections.Generic;
using libChristmasLight;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        /// <summary>
        ///     Turn a range of lights on
        /// </summary>
        /// <param name="range">Start/End coordinates of lights to turn on</param>
        private static void TurnOnRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.TurnOn();
            }
        }

        /// <summary>
        ///     Turn a range of lights off
        /// </summary>
        /// <param name="range">Start/End coordinates of lights to turn off</param>
        private static void TurnOffRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.TurnOff();
            }
        }

        /// <summary>
        ///     Toggle a range of lights on or off
        /// </summary>
        /// <param name="range">Start/End coordinates of lights to toggle</param>
        private static void ToggleRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.Toggle();
            }
        }
    }
}