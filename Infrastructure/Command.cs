using System;
using System.Windows.Input;

namespace Infrastructure
{
    public class Command : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        private readonly Action<object?> _execute;
        private readonly Predicate<object?> _canExecute;

        public Command(Action<object?> execute, Predicate<object?> canExecute = null!)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
            => _canExecute?.Invoke(parameter!) ?? true;

        public void Execute(object? parameter)
            => _execute?.Invoke(parameter!);
    }
}
