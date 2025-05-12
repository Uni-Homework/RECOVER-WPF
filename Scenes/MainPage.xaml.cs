namespace RECOVER.Scenes;

public partial class MainPage : SceneView
{
    public MainPage(MainScene scene) : base(scene)
    {
        DataContext = scene;
        InitializeComponent();
    }
}