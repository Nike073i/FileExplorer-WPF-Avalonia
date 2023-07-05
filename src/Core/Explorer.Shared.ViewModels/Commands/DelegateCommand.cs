using System.Windows.Input;

namespace Explorer.Shared.ViewModels.Commands
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _open;
        private readonly Predicate<object?>? _canExecute;

        public event EventHandler? CanExecuteChanged;

        public DelegateCommand(Action<object?> _action, Predicate<object?>? canExecute = null)
        {
            _open = _action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute(parameter);

        public void Execute(object? parameter) => _open?.Invoke(parameter);    

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }
}