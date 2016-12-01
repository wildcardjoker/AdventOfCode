#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-07
// Modified: 2015-12-07 8:39 PM
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
        private static void TurnOnBrightnessRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.TurnOnBrightness();
            }
        }

        /// <summary>
        ///     Turn a range of lights off
        /// </summary>
        /// <param name="range">Start/End coordinates of lights to turn off</param>
        private static void TurnOffBrightnessRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.TurnOffBrightness();
            }
        }

        /// <summary>
        ///     Toggle a range of lights on or off
        /// </summary>
        /// <param name="range">Start/End coordinates of lights to toggle</param>
        private static void ToggleBrightnessRange(IEnumerable<ChristmasLight> range)
        {
            foreach (ChristmasLight light in range)
            {
                light.ToggleBrightness();
            }
        }
    }
}