using System;
using System.Windows.Input;

/*
The benefit of using relaycommand is that you can bind commands directly to the ViewModels. 
By using commands in such a way you avoid writing code in the view's code behind.
When using relay commands, you will have to provide two methods. 
The first one provides a value whether the command can be executed (e.g. "Can Execute Safe"), 
while the other one will be responsible for executing the command ("ExecuteSave").
*/

namespace Que.Core
{
    class RelayCommand : ICommand // execute
    {
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        // Constructor

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        // Methods

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
