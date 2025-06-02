using RECOVER.Assets.Scenes.CommonScene;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.MainMenu;

public partial class MainMenu : SceneView
{
    private MainMenuScene _menuScene;

    public MainMenu()
    {
        InitializeComponent();
        DataContext = _menuScene = new MainMenuScene();
    }

    public override Scene Scene => _menuScene;
}