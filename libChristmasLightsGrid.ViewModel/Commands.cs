#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 9:09 PM
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
        private ICommand _followInstructionsCommand;
        private ICommand _generateGridCommand;
        #endregion

        #region Properties
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
        #endregion
    }
}