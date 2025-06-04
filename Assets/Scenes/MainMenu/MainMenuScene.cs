using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.MainMenu;

public class MainMenuScene : Scene
{
    private string _playerName;
    private ICommand _startGameCommand;
    private ICommand _continuedGameCommand;
    private ICommand _exitCommand;

    public MainMenuScene()
    {
        StartGameCommand = new LambdaCommand<object, object>(
            _ => App.CreateScene(SceneType.CosmicStation),
            _ => !string.IsNullOrWhiteSpace(PlayerName)
        );
        ContinuedGameCommand = new LambdaCommand<object, object>(
            _ => App.SetScene(SceneType.CosmicStation),
            _ => App.IsCachedScene(SceneType.CosmicStation)
        );
        ExitCommand = new LambdaCommand<object, object>(_ => App.Current.Shutdown(0));
    }

    public string PlayerName
    {
        get => _playerName;
        set
        {
            Set(ref _playerName, value);
            StartGameCommand.CanExecute(_playerName);
        }
    }

    public ICommand StartGameCommand
    {
        get => _startGameCommand;
        private set => Set(ref _startGameCommand, value);
    }

    public ICommand ContinuedGameCommand
    {
        get => _continuedGameCommand;
        private set => Set(ref _continuedGameCommand, value);
    }
    
    public ICommand ExitCommand
    {
        get => _exitCommand;
        private set => Set(ref _exitCommand, value);
    }
}