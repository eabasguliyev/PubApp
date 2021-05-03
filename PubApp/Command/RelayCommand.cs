using System;
using System.Windows.Input;

namespace PubApp.Command
{
    public class RelayCommand:ICommand
    {
        private Action<object> _action;
        private Predicate<object> _predicate;

        public RelayCommand(Action<object> action, Predicate<object> predicate = null)
        {
            _action = action ?? throw new ArgumentNullException();
            _predicate = predicate;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _predicate == null || _predicate.Invoke(parameter);
        }

        public void Execute(object parameter)
        {
            _action.Invoke(parameter);
        }
    }
}