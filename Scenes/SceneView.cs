using System.Windows.Controls;

namespace RECOVER.Scenes;

public partial class SceneView : Page
{
    private IScene scene;

    public SceneView(IScene scene)
    {
        this.scene = scene;
    }

    public IScene Scene => scene;
}