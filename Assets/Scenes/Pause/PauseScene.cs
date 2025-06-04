using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.Pause;

public class PauseScene : Scene
{
    private ICommand _continuedCommand;
    private ICommand _toMainScreenCommand;
    private ICommand _exitCommand;
    private ICommand _tutorialCommand;

    public PauseScene()
    {
        ContinuedCommand = new LambdaCommand<object, object>(ContinuedExecute);
        ToMainScreenCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.MainMenu));
        TutorialCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.Learning));
        ExitCommand = new LambdaCommand<object, object>(_ => App.Current.Shutdown(0));
    }

    public ICommand ExitCommand
    {
        get => _exitCommand;
        private set => Set(ref _exitCommand, value);
    }

    public ICommand ContinuedCommand
    {
        get => _continuedCommand;
        private set => Set(ref _continuedCommand, value);
    }

    public ICommand ToMainScreenCommand
    {
        get => _toMainScreenCommand;
        private set => Set(ref _toMainScreenCommand, value);
    }

    public ICommand TutorialCommand
    {
        get => _tutorialCommand;
        private set => Set(ref _tutorialCommand, value);
    }

    public void ContinuedExecute(object _)
    {
        App.SetScene(SceneType.CosmicStation);
    }
}