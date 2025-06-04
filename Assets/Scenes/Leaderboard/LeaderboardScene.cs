using System.Collections.ObjectModel;
using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.Models;
using RECOVER.Engine.Serialization;

namespace RECOVER.Assets.Scenes.Leaderboard;
public class LeaderboardScene : Scene
{
    private ICommand _commandMenu;
    public ObservableCollection<LeaderboardEntry> LeaderboardEntries { get; }

    public LeaderboardScene()
    {
        LeaderboardEntries = new ObservableCollection<LeaderboardEntry>();
        LoadLeaderboard();
    }

    private void LoadLeaderboard()
    {
        var entries = LeaderboardSerializer.LoadLeaderboard();
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