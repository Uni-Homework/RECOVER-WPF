using System.Collections.ObjectModel;
using System.Windows;
using RECOVER.Assets.Scenes.Terminal;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Terminal;

public class TerminalComponent : Component
{
    private bool _isShow;
    private ObservableCollection<string> history;
    private string command;

    public TerminalComponent()
    {
        history = new ObservableCollection<string>();
        command = String.Empty;
    }

    public bool IsShow
    {
        get => _isShow;
        private set => Set(ref _isShow, value);
    }

    public ObservableCollection<string> History
    {
        get => history;
        set { Set(ref history, value); }
    }

    public string Command
    {
        get => command;
        set { Set(ref command, value); }
    }

    public void OpenTerminal()
    {
        if (IsShow)
        {
            return;
        }

        IsShow = true;
        TerminalView view = new TerminalView(this);
        view.Closed += OnClosedTerminal;
        view.Show();
    }

    private void OnClosedTerminal(object sender, EventArgs e)
    {
        (sender as Window).Closed -= OnClosedTerminal;
        ClearCommand();
        IsShow = false;
    }

    private void ClearCommand()
    {
        Command = String.Empty;
    }

    public void DoCommand()
    {
        History.Add(Command);
    }
}