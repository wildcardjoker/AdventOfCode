#region Information

// AdventOfCode: libChristmasLight
// Created: 2015-12-06
// Modified: 2015-12-06 5:23 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System.ComponentModel;
using System.Runtime.CompilerServices;
using libChristmasLight.Annotations;

#endregion

namespace libChristmasLight
{
    public class ChristmasLight : INotifyPropertyChanged
    {
        #region  Fields
        private bool _lit;
        private int _posX;
        private int _posY;
        #endregion

        #region Constructors
        public ChristmasLight() : this(0, 0) {}

        public ChristmasLight(int x, int y)
        {
            PosX = x;
            PosY = y;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     Indicates if Light is turned on
        /// </summary>
        public bool Lit
        {
            get { return _lit; }
            set
            {
                if (value == _lit)
                {
                    return;
                }
                _lit = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     X coordinate of light
        /// </summary>
        public int PosX
        {
            get { return _posX; }
            set
            {
                if (value == _posX)
                {
                    return;
                }
                _posX = value;
                OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Y coordinate of light
        /// </summary>
        public int PosY
        {
            get { return _posY; }
            set
            {
                if (value == _posY)
                {
                    return;
                }
                _posY = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        /// <summary>
        ///     Turn light On
        /// </summary>
        public void TurnOn() => Lit = true;

        /// <summary>
        ///     Turn light Off
        /// </summary>
        public void TurnOff() => Lit = false;

        /// <summary>
        ///     Toggle light - turn On if Off, turn Off if On
        /// </summary>
        public void Toggle() => Lit = !Lit;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}