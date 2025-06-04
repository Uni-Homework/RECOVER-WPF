using System.ComponentModel;
using System.Windows;
using System.Windows.Media;
using RECOVER.Assets.Scenes;
using RECOVER.Assets.Scenes.CommonScene;
using RECOVER.Assets.Scenes.CosmicStation;
using RECOVER.Assets.Scenes.GameOver;
using RECOVER.Assets.Scenes.MainMenu;
using RECOVER.Assets.Scenes.Pause;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, INotifyPropertyChanged
{
    private DateTime lastFrameTime;
    private Dictionary<SceneType, SceneView> cacheScenes = new Dictionary<SceneType, SceneView>();
    private SceneView _currentScene;

    public event PropertyChangedEventHandler PropertyChanged;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Start();
    }

    private void Start()
    {
        lastFrameTime = DateTime.Now;
        SetScene(SceneType.MainMenu);
        CompositionTarget.Rendering += GameLoop;
    }

    public static void SetScene(SceneType type, bool isWin = false)
    {
        ((App)Current).SetSceneInternal(type, isWin);
    }

    public void SetSceneInternal(SceneType type, bool isWin = false)
    {
        if (cacheScenes.TryGetValue(type, out var sceneView))
        {
            CurrentScene = sceneView;
        }
        else
        {
            CreateSceneInternal(type, isWin);
        }
    }

    public static void CreateScene(SceneType type, bool isWin = false)
    {
        ((App)Current).CreateSceneInternal(type, isWin);
    }

    public void CreateSceneInternal(SceneType type, bool isWin)
    {
        CurrentScene = type switch
        {
            SceneType.MainMenu => new MainMenu(),
            SceneType.CosmicStation => new CosmicStation(),
            SceneType.GameOver => new GameOver(isWin),
            SceneType.Pause => new Pause()
        };
        CurrentScene.Scene.Start();
        if (!cacheScenes.TryAdd(type, CurrentScene))
        {
            cacheScenes[type] = CurrentScene;
        }
    }

    public static bool IsCachedScene(SceneType type)
    {
        return ((App)Current).cacheScenes.ContainsKey(type);
    }

    public SceneView CurrentScene
    {
        get => _currentScene;
        set
        {
            _currentScene = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentScene)));
        }
    }

    private void GameLoop(object sender, EventArgs e)
    {
        DateTime currentFrameTime = DateTime.Now;
        double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;
        CurrentScene.Scene.Update(deltaTime);
        lastFrameTime = currentFrameTime;
    }

    public static void DropScene(SceneType type)
    {
        ((App)Current).cacheScenes.Remove(type);
    }
}