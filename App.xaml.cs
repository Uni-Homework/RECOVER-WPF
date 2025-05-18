using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;

namespace RECOVER;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : INotifyPropertyChanged
{
    private DateTime lastFrameTime;

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        Start();
    }


    private void Start()
    {
        lastFrameTime = DateTime.Now;

        // SetScene(SceneType.MainBaseScene);
        CompositionTarget.Rendering += GameLoop;
    }


    private void GameLoop(object sender, EventArgs e)
    {
        DateTime currentFrameTime = DateTime.Now;
        double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

        // CurrentScene.BaseScene.Update(deltaTime);

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