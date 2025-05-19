using System.Windows.Controls;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;


// No idea why it exists
// Don't touch - it won't work otherwise
// TODO pls explain
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