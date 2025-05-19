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
        if (e.Key == Key.F3)
        {
            GameObjectCanvas.IsDebug = !GameObjectCanvas.IsDebug;
        }

        base.OnKeyDown(e);
    }
}