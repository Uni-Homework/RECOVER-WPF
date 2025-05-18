using System.Windows.Controls;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public partial class SceneView : Page
{
    public Scene BaseScene { get; }

    public SceneView(Scene baseScene)
    {
        BaseScene = baseScene;
        DataContext = this;
        InitializeComponent();
    }
} 