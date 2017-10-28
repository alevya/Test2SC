using System;
using System.Windows.Input;

namespace WpfApp.ViewModel.Helpers
{
    internal class DelegateCommand : ICommand
    {
        private readonly Predicate<object> _canExecPredicate;
        private readonly Action<object> _execAction;

        public DelegateCommand(Action<object> execute) : this(execute, null)
        {
        }

        public DelegateCommand(Action<object> execute, Predicate<object> predicate)
        {
            _execAction = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecPredicate = predicate;
        }

        #region ICommand Implements
        public bool CanExecute(object parameter)
        {
            return _canExecPredicate?.Invoke(parameter) ?? false;
        }

        public void Execute(object parameter)
        {
            if (!CanExecute(parameter))
            {
                throw new InvalidOperationException("Команда не действительна для выполнения");
            }

            _execAction(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        //public event EventHandler CanExecuteChanged;
        #endregion
    }
}
