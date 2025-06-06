﻿using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.MainMenu;

public class MainMenuScene : Scene
{
    private string _playerName;
    private ICommand _startGameCommand;
    private ICommand _continuedGameCommand;
    private ICommand _learningCommand;
    private ICommand _exitCommand;
    private ICommand _leaderboardCommand;

    public MainMenuScene()
    {
        LearningCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.Learning));
        ExitCommand = new LambdaCommand<object, object>(_ => App.Current.Shutdown(0));
        StartGameCommand = new LambdaCommand<object, object>(
            _ => App.CreateScene(SceneType.CosmicStation),
            _ => !string.IsNullOrWhiteSpace(PlayerName)
        );
        ContinuedGameCommand = new LambdaCommand<object, object>(
            _ => App.SetScene(SceneType.CosmicStation),
            _ => App.IsCachedScene(SceneType.CosmicStation)
        );
        LeaderboardCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.Leaderboard));

    }


    public string PlayerName
    {
        get => _playerName;
        set
        {
            Set(ref _playerName, value);
            StaticValuesContainer.Nickname = value;
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

    public ICommand LearningCommand
    {
        get => _learningCommand;
        private set => Set(ref _learningCommand, value);
    }

    public ICommand ExitCommand
    {
        get => _exitCommand;
        private set => Set(ref _exitCommand, value);
    }
    
    public ICommand LeaderboardCommand
    {
        get => _leaderboardCommand;
        private set => Set(ref _leaderboardCommand, value);
    }
}