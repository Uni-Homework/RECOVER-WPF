using System.Windows.Input;

namespace RECOVER.Engine.WPFTools;

public class LambdaCommand<T, R>(Action<R> execute, Func<T, bool> canExecuteL) : ICommand
{
    public LambdaCommand(Action<R> execute) : this(execute, arg => true)
    {
    }

    public bool CanExecute(object parameter)
    {
        return canExecuteL.Invoke((T)parameter);
    }

    public void Execute(object parameter)
    {
        execute.Invoke((R)parameter);
    }

    public event EventHandler CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }
}