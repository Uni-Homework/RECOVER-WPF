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
        switch (e.Key)
        {
            case Key.F3:
                GameObjectCanvas.IsDebug = !GameObjectCanvas.IsDebug;
                break;
            case Key.W:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    Y = -1
                };
                break;
            case Key.S:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    Y = 1
                };
                break;
            case Key.A:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    X = -1
                };
                break;
            case Key.D:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    X = 1
                };
                break;
            case Key.Tab:
                _baseScene.ResourceViewer.OpenResourceViewer();
                break;
            case Key.E:
                _baseScene.PlayerController.RotateRight = true;
                break;
            case Key.Q:
                _baseScene.PlayerController.RotateLeft = true;
                break;
            case Key.Escape:
                App.SetScene(SceneType.Pause);
                break;
            default:
                foreach (var surroundingItem in _baseScene.DetectorItems.SurroundingItems)
                {
                    if (Keyboard.GetKeyStates(surroundingItem.ActivationKey) != KeyStates.Down) continue;
                    surroundingItem.Action.Invoke();
                    return;
                }

                break;
        }

        base.OnKeyDown(e);
    }

    protected override void OnKeyUp(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.F3:
                GameObjectCanvas.IsDebug = !GameObjectCanvas.IsDebug;
                break;
            case Key.W or Key.S:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    Y = 0
                };
                break;
            case Key.A or Key.D:
                _baseScene.PlayerController.Input = _baseScene.PlayerController.Input with
                {
                    X = 0
                };
                break;
            case Key.E:
                _baseScene.PlayerController.RotateRight = false;
                break;
            case Key.Q:
                _baseScene.PlayerController.RotateLeft = false;
                break;
        }

        base.OnKeyDown(e);
    }

    public override CosmicStationScene Scene => _baseScene;
}