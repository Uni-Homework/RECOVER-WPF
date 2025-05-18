namespace RECOVER.Scenes;

public partial class MainBase : SceneView
{
    public MainBase(MainBaseScene baseScene) : base(baseScene)
    {
        DataContext = baseScene;
        InitializeComponent();
    }
}