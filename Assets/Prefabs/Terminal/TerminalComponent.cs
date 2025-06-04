using System.Collections.ObjectModel;
using System.Windows;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Assets.Scenes.Terminal;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Terminal;

public class TerminalComponent : Component
{
    private bool _isShow;
    private ObservableCollection<string> history;
    private string command;
    private PlayerPrefab _player;
    private Window _terminalWindow;

    public TerminalComponent(PlayerPrefab player)
    {
        _player = player;
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
        set => Set(ref history, value);
    }

    public string Command
    {
        get => command;
        set => Set(ref command, value);
    }

    public void OpenTerminal()
    {
        if (IsShow)
        {
            return;
        }

        IsShow = true;
        var view = new TerminalView(this);
        _terminalWindow = view;
        view.Closed += OnClosedTerminal;
        view.ShowDialog();
    }

    private void OnClosedTerminal(object sender, EventArgs e)
    {
        (sender as Window).Closed -= OnClosedTerminal;
        ClearCommand();
        IsShow = false;
        _terminalWindow = null;
    }

    private void ClearCommand()
    {
        Command = String.Empty;
    }

    public void DoCommand()
    {
        History.Add(Command);

        switch (Command.ToLower())
        {
            case "help":
                History.Add("Рассказ об управлении - get control\n" +
                            "Выйти из игры - exit\n" +
                            "Отчистка истории терминала - clear\n" +
                            "Убить игрока - kill");
                break;
            case "get control":
                History.Add("Ходьба - W, A, S, D\n" +
                            "Проверить показатели ресурсов - Tab\n" +
                            "Обработка уведенных предметов - зависит от предметов в правом нижнем углу\n");
                break;
            case "exit":
                App.Current.Shutdown(0);
                break;
            case "clear":
                History.Clear();
                break;
            case "kill":
                if (_player != null)
                {
                    _player.Die();
                    History.Add("Player terminated.");
                    _terminalWindow?.Close();
                }
                else
                {
                    History.Add("Error: Player reference not found.");
                }
                break;
            default:
                History.Add($"Unknown command: {Command}.\nType \"help\" for a list of available commands.");
                break;
        }

        ClearCommand();
    }
}