using System.Windows.Input;
using RECOVER.Assets.Scenes.CommonScene;

namespace RECOVER.Assets.Scenes.Pause;

public partial class Pause : SceneView
{
    private PauseScene _scene;

    public Pause()
    {
        InitializeComponent();
        DataContext = _scene = new PauseScene();
        Focus();
    }

    public override PauseScene Scene => _scene;


    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
        {
            Scene.ContinuedExecute(this);
            e.Handled = true;
        }

        base.OnKeyDown(e);
    }
}