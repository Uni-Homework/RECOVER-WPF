using RECOVER.Assets.Scenes.CommonScene;

namespace RECOVER.Assets.Scenes.Leaderboard;

public partial class Leaderboard : SceneView
{
    private LeaderboardScene _leaderboardScene;

    public Leaderboard()
    {
        InitializeComponent();
        DataContext = new LeaderboardScene();
    }

    public override LeaderboardScene Scene => _leaderboardScene;
}