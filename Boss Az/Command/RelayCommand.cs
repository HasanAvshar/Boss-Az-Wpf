using System.Windows.Controls;
using System.Windows.Input;

namespace Command.Commands;

public class RelayCommand : ICommand
{
    private Action<object?>? _execute;
    public Predicate<object?>? _canExecute;
    private Action focusEmail;
    private Action<object, MouseButtonEventArgs> textEmail_MouseDown;
    private Action<object, TextChangedEventArgs> textBox_TextChanged;

    public RelayCommand(Action<object?>? execute = null, Predicate<object?>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public RelayCommand(Action focusEmail)
    {
        this.focusEmail = focusEmail;
    }

    public RelayCommand(Action<object, MouseButtonEventArgs> textEmail_MouseDown)
    {
        this.textEmail_MouseDown = textEmail_MouseDown;
    }

    public RelayCommand(Action<object, TextChangedEventArgs> textBox_TextChanged)
    {
        this.textBox_TextChanged = textBox_TextChanged;
    }

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public bool CanExecute(object? parameter)
    {
        if (_canExecute is null)
            return true;
        return _canExecute(parameter);
    }

    public void Execute(object? parameter)
    {
        if (_execute is not null)
            _execute(parameter);
    }
}