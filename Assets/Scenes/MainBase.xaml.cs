using System.Windows.Controls;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

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
        DataContext = this;
    }
}