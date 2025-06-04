using System.Windows;
using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.Pause;

public class PauseScene : Scene
{
    private ICommand continuedCommand;
    private ICommand toMainScreenCommand;
    private ICommand exitCommand;

    public PauseScene()
    {
        ContinuedCommand = new LambdaCommand<object, object>(ContinuedExecute);
        ToMainScreenCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.MainMenu));
        ExitCommand = new LambdaCommand<object, object>(_ => App.Current.Shutdown(0));
    }

    public ICommand ExitCommand
    {
        get => exitCommand;
        private set { Set(ref exitCommand, value); }
    }

    public ICommand ContinuedCommand
    {
        get => continuedCommand;
        private set { Set(ref continuedCommand, value); }
    }

    public ICommand ToMainScreenCommand
    {
        get => toMainScreenCommand;
        private set { Set(ref toMainScreenCommand, value); }
    }

    public void ContinuedExecute(object _)
    {
        App.SetScene(SceneType.CosmicStation);
    }
}