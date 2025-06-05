using System.Collections.ObjectModel;
using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.Models;
using RECOVER.Engine.Serialization;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.Leaderboard;

public class LeaderboardScene : Scene
{
    private ICommand _commandMenu;
    public ObservableCollection<LeaderboardEntry> LeaderboardEntries { get; }

    public LeaderboardScene()
    {
        _commandMenu = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.MainMenu));
        LeaderboardEntries = new ObservableCollection<LeaderboardEntry>();
        LoadLeaderboard();

        // Subscribe to leaderboard updates
        LeaderboardSerializer.LeaderboardUpdated += (sender, args) => LoadLeaderboard();
    }

    private void LoadLeaderboard()
    {
        var entries = LeaderboardSerializer.LoadLeaderboard().OrderByDescending(le => le.Score);
        LeaderboardEntries.Clear();
        foreach (var entry in entries)
        {
            LeaderboardEntries.Add(entry);
        }
    }

    public ICommand BackCommand
    {
        get => _commandMenu;
        private set => Set(ref _commandMenu, value);
    }
}