using System.Windows.Input;
using RECOVER.Assets.Scenes.CommonScene;

namespace RECOVER.Assets.Scenes.CosmicStation;

public partial class CosmicStation : SceneView
{
    private CosmicStationScene _baseScene;
    
    public CosmicStation()
    {
        InitializeComponent();
        Focusable = true;
        Focus();

        this._baseScene = new CosmicStationScene();
        DataContext = BaseScene;
    }

    public CosmicStationScene BaseScene
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

    public override CosmicStationScene Scene => _baseScene;
}