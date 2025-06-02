using System.Windows.Input;
using RECOVER.Assets.Scenes.CommonScene;

namespace RECOVER.Assets.Scenes.MainBase;

public partial class MainBase : SceneView
{
    private MainBaseScene _baseScene;
    
    public MainBase()
    {
        InitializeComponent();
        Focusable = true;
        Focus();

        this._baseScene = new MainBaseScene();
        DataContext = BaseScene;
    }

    public MainBaseScene BaseScene
    {
        get => _baseScene;
        private set => _baseScene = value;
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.F3)
        {
            GameObjectCanvas.IsDebug = !GameObjectCanvas.IsDebug;
        }

        base.OnKeyDown(e);
    }

    public override MainBaseScene Scene => _baseScene;
}