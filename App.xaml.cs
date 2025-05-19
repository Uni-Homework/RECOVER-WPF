using System.Windows;
using System.Windows.Media;
using RECOVER.Assets.Scenes.MainBase;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
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


    // lmao wha
    // why we do it twice???
    // check MainBase.xaml.cs
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

        }

        lastFrameTime = currentFrameTime;
    }
}