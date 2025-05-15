using System.Windows.Controls;
using RECOVER.Inner;

namespace RECOVER.Scenes;

public partial class SceneView : Page
{
    private IScene _baseScene;

    public SceneView(IScene baseScene)
    {
        this._baseScene = baseScene;
    }

    public IScene BaseScene => _baseScene;
}