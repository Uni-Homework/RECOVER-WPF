using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.MainMenu;

public class MainMenuScene : Scene
{
    private string playerName;
    private ICommand _startGameCommand;

    public MainMenuScene()
    {
        StartGameCommand = new LambdaCommand<object, object>(
            _ => ((App)App.Current).SetScene(SceneType.CosmicStation),
            _ => !string.IsNullOrWhiteSpace(PlayerName));
    }

    public string PlayerName
    {
        get => playerName;
        set
        {
            Set(ref playerName, value);
            StartGameCommand.CanExecute(playerName);
        }
    }

    public ICommand StartGameCommand
    {
        get => _startGameCommand;
        private set => Set(ref _startGameCommand, value);
    }
}