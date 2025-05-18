using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using RECOVER.Assets.Scenes;
using RECOVER.Engine;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application, INotifyPropertyChanged
{
    private DateTime lastFrameTime;
    private MainWindow mainWindow;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        mainWindow = new MainWindow();
        mainWindow.Show();
        Start();
    }

    private void Start()
    {
        lastFrameTime = DateTime.Now;
        SetScene();
        CompositionTarget.Rendering += GameLoop;
    }

    private void SetScene()
    {
        var scene = new MainBaseScene();
        mainWindow.Content = new MainBase();
        scene.Start();
    }

    private void GameLoop(object sender, EventArgs e)
    {
        DateTime currentFrameTime = DateTime.Now;
        double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

        if (mainWindow.Content is MainBase mainBase && mainBase.BaseScene != null)
        {
            mainBase.BaseScene.Update(deltaTime);
            mainBase.BaseScene.UpdatePhysics(deltaTime);
        }

        lastFrameTime = currentFrameTime;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}