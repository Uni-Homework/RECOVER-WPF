using RECOVER.Assets.Scenes.CommonScene;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.Leaderboard;

public partial class Leaderboard : SceneView
{
    private LeaderboardScene _leaderboardScene;

    public Leaderboard()
    {
        InitializeComponent();
        DataContext = _leaderboardScene = new LeaderboardScene();
    }

    public override Scene Scene => _leaderboardScene;
}