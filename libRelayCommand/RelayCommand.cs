#region Information

// AdventOfCode: libRelayCommand
// Created: 2015-12-06
// Modified: 2015-12-06 6:22 PM
// Last modified by: Jason Moore (Jason)
#endregion

#region Using Directives
using System;
using System.Diagnostics;
using System.Windows.Input;

#endregion

namespace libRelayCommand
{
    /// <summary>
    ///     A command whose sole purpose is to relay its functionality to other
    ///     objects by invoking delegates. The default return value for the
    ///     CanExecute method is 'true'.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region  Fields
        private readonly Predicate<object> _canExecute;
        private readonly Action<object> _execute;
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute = null)
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region ICommand Members
        [DebuggerStepThrough]
        public bool CanExecute(object parameters)
        {
            return _canExecute == null || _canExecute(parameters);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameters)
        {
            _execute(parameters);
        }
        #endregion
    }
}