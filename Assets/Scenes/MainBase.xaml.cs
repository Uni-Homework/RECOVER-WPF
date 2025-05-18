namespace RECOVER.Assets.Scenes;

public partial class MainBase : SceneView
{
    public MainBase(MainBaseScene baseScene) 
    {
        DataContext = baseScene;
        InitializeComponent();
    }
}