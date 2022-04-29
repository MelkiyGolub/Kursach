using System;
using System.Windows.Input;

namespace Kursach.Objects;

public class Command : ICommand
{
    public Command(Action<object> execute, Func<object, bool> canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }
    private Action<object> _execute;
    private Func<object, bool> _canExecute;

    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        return _canExecute is null || _canExecute(parameter!);
    }

    public void Execute(object? parameter)
    {
        _execute(parameter!);
    }
}