using System.Windows;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    // Necessary for that stupid thing called WPF
    private PlayerPrefab player;
    
    public PlayerPrefab Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    public MainBaseScene()
    {
        base.Start();
        player = new PlayerPrefab(new Vector(200, 200));
        objects.Add(player);
    }
}