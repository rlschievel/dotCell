using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NetworkAPIViewer.ViewModels.Commands
{
    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
            {
                throw new NullReferenceException("RelayCommand given a null execute Action");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        public RelayCommand(Action<object> execute) : this(execute, null)
        {
            // Empty constructor since the parent constructor does all the work needed.
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested += value; }
        }

        public bool CanExecute(object parameter)
        {
            bool result;
            
            if (_canExecute == null)
            {// If no predicate given then the command can always execute
                result = true;
            }
            else
            {// Return the result of the predicate function
                result = _canExecute(parameter);
            }

            return result;
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
