using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.MainMenu;

public class MainMenuScene : Scene
{
    private string playerName;
    private ICommand _startGameCommand;
    private ICommand _learningCommand;

    public MainMenuScene()
    {
        LearningCommand = new LambdaCommand<object, object>(_ => ((App)App.Current).SetScene(SceneType.Learning));
        StartGameCommand = new LambdaCommand<object, object>(
            _ => ((App)App.Current).SetScene(SceneType.CosmicStation),
            _ => !string.IsNullOrWhiteSpace(PlayerName));
    }

    public string PlayerName
    {
        get => playerName;
        set => Set(ref playerName, value);
    }

    public ICommand StartGameCommand
    {
        get => _startGameCommand;
        private set => Set(ref _startGameCommand, value);
    }

    public ICommand LearningCommand
    {
        get => _learningCommand;
        private set => Set(ref _learningCommand, value);
    }
}