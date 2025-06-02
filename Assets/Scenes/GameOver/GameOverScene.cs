using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.GameOver;

public class GameOverScene : Scene
{
    private string _message;
    private ICommand _restartCommand;
    private ICommand _mainMenuCommand;

    public GameOverScene(bool isWin)
    {
        Message = isWin ? "Победа!" : "Поражение!";
        
        RestartCommand = new LambdaCommand<object, object>(
            _ => ((App)App.Current).SetScene(SceneType.CosmicStation),
            _ => true);
            
        MainMenuCommand = new LambdaCommand<object, object>(
            _ => ((App)App.Current).SetScene(SceneType.MainMenu),
            _ => true);
    }

    public string Message
    {
        get => _message;
        private set => Set(ref _message, value);
    }

    public ICommand RestartCommand
    {
        get => _restartCommand;
        private set => Set(ref _restartCommand, value);
    }

    public ICommand MainMenuCommand
    {
        get => _mainMenuCommand;
        private set => Set(ref _mainMenuCommand, value);
    }
} 