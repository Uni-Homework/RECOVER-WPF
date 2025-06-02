using RECOVER.Assets.Scenes.CommonScene;

namespace RECOVER.Assets.Scenes.GameOver;

public partial class GameOver : SceneView
{
    private GameOverScene _baseScene;

    public GameOver(bool isWin)
    {
        InitializeComponent();
        _baseScene = new GameOverScene(isWin);
        DataContext = _baseScene;
    }

    public override GameOverScene Scene => _baseScene;
} 