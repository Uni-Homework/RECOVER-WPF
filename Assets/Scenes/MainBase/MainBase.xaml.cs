using System.Windows.Controls;

namespace RECOVER.Assets.Scenes.MainBase;

public partial class MainBase : Page
{
    private MainBaseScene _baseScene;
    
    public MainBaseScene BaseScene
    {
        get => _baseScene;
        private set => _baseScene = value;
    }

    public MainBase()
    {
        InitializeComponent();

        _baseScene = new MainBaseScene();
        DataContext = BaseScene;
    }
}