using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using RECOVER.Scenes;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, INotifyPropertyChanged
{
    private DateTime lastFrameTime;
    private SceneView currentScene;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Start();
    }

    public SceneView CurrentScene
    {
        get => currentScene;
        set => Set(ref currentScene, value);
    }

    private void Start()
    {
        lastFrameTime = DateTime.Now;
        CurrentScene = new MainPage(new MainScene());
        CurrentScene.Scene.Start();
        CompositionTarget.Rendering += GameLoop;
    }

    private void GameLoop(object sender, EventArgs e)
    {
        DateTime currentFrameTime = DateTime.Now;
        double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

        CurrentScene.Scene.Update(deltaTime);

        lastFrameTime = currentFrameTime;
    }

    public event PropertyChangedEventHandler PropertyChanged = delegate { };

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
    {
        if (Equals(field, value))
            return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}