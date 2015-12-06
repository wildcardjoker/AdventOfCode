#region Information

// AdventOfCode: libChristmasLightsGrid.ViewModel
// Created: 2015-12-06
// Modified: 2015-12-06 5:57 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using libChristmasLight;
using libChristmasLightsGrid.ViewModel.Annotations;

#endregion

namespace libChristmasLightsGrid.ViewModel
{
    public class ChristmasLightsGrid : INotifyPropertyChanged
    {
        #region  Fields
        private int _columns;
        private List<ChristmasLight> _lights;
        private int _rows;
        #endregion

        #region Properties
        /// <summary>
        ///     Number of Columns in Grid
        /// </summary>
        public int Columns
        {
            get { return _columns; }
            set
            {
                if (value == _columns)
                {
                    return;
                }
                _columns = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     List representing a Grid of Christmas Lights
        /// </summary>
        public List<ChristmasLight> Lights
        {
            get { return _lights; }
            set
            {
                if (Equals(value, _lights))
                {
                    return;
                }
                _lights = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Number of Rows in Grid
        /// </summary>
        public int Rows
        {
            get { return _rows; }
            set
            {
                if (value == _rows)
                {
                    return;
                }
                _rows = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}