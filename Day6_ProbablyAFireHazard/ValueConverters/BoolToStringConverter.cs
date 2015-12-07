#region Information

// AdventOfCode: Day6_ProbablyAFireHazard
// Created: 2015-12-07
// Modified: 2015-12-07 12:32 PM
// Last modified by: MOORE Jason (jasonmo)
#endregion

#region Using Directives
using System;
using System.Globalization;
using System.Windows.Data;

#endregion

namespace Day6_ProbablyAFireHazard.ValueConverters
{
    class BoolToStringConverter : IValueConverter
    {
        #region Implementation of IValueConverter
        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value produced by the binding source.</param>
        /// <param name="targetType">The type of the binding target property.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool) value ? "1" : "0";
        }

        /// <summary>
        ///     Converts a value.
        /// </summary>
        /// <returns>
        ///     A converted value. If the method returns null, the valid null value is used.
        /// </returns>
        /// <param name="value">The value that is produced by the binding target.</param>
        /// <param name="targetType">The type to convert to.</param>
        /// <param name="parameter">The converter parameter to use.</param>
        /// <param name="culture">The culture to use in the converter.</param>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}