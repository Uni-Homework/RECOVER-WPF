using System.Windows.Controls;
using System.Windows.Input;

namespace RECOVER.Assets.Scenes.MainBase;

public partial class MainBase : Page
{
    private MainBaseScene _baseScene;

    public MainBase()
    {
        InitializeComponent();
        Focusable = true;
        Focus();

        _baseScene = new MainBaseScene();
        _baseScene.Start();

        DataContext = BaseScene;
    }

    public MainBaseScene BaseScene
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
}