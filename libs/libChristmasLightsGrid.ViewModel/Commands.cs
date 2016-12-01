#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-07 8:48 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Windows.Input;
using libRelayCommand;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public partial class ChristmasLightsGrid
    {
        #region  Fields
        private ICommand _adjustBrightnessInstructionsCommand;
        private ICommand _followInstructionsCommand;
        private ICommand _generateGridCommand;
        private ICommand _highlightCornersCommand;
        #endregion

        #region Properties
        public ICommand AdjustBrightnessInstructionsCommand
        {
            get
            {
                return
                    _adjustBrightnessInstructionsCommand ?? (_adjustBrightnessInstructionsCommand =
                                                             new RelayCommand(param => PerformBrightnessInstructions()));
            }
        }

        public ICommand FollowInstructionsCommand
        {
            get
            {
                return
                    _followInstructionsCommand ?? (_followInstructionsCommand =
                                                   new RelayCommand(param => PerformInstructions()));
            }
        }

        public ICommand GenerateGridCommand
        {
            get
            {
                return
                    _generateGridCommand ?? (_generateGridCommand =
                                             new RelayCommand(param => CreateGrid(),
                                                              canExecute => Rows > 0 && Columns > 0));
            }
        }

        public ICommand HighlightCornersCommand
        {
            get
            {
                return
                    _highlightCornersCommand ?? (_highlightCornersCommand =
                                                 new RelayCommand(param => HighlightCorners(),
                                                                  canExecute => Rows > 0 && Columns > 0));
            }
        }
        #endregion
    }
}