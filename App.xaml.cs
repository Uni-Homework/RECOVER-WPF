using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using RECOVER.Scenes;
using RECOVER.Type;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, INotifyPropertyChanged
{
    private DateTime lastFrameTime;
    private SceneView currentScene;
    private Dictionary<SceneType, SceneView> cacheScenes;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Start();
    }

    public SceneView CurrentScene
    {
        get => currentScene;
        private set => Set(ref currentScene, value);
    }

    private void Start()
    {
        lastFrameTime = DateTime.Now;
        cacheScenes = new Dictionary<SceneType, SceneView>();

        SetScene(SceneType.MainScene);
        CompositionTarget.Rendering += GameLoop;
    }

    public void SetScene(SceneType type)
    {
        if (cacheScenes.TryGetValue(type, out var sceneView))
        {
            CurrentScene = sceneView;
        }
        else
        {
            CurrentScene = type switch
            {
                SceneType.MainScene => new MainPage(new MainScene())
            };
            CurrentScene.Scene.Start();
        }
    }

    private void GameLoop(object sender, EventArgs e)
    {
        DateTime currentFrameTime = DateTime.Now;
        double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

        CurrentScene.Scene.Update(deltaTime);

        lastFrameTime = currentFrameTime;
    }

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
            return false;
        field = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        return true;
    }
}