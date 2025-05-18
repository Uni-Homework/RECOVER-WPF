using System.Windows;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    public GameObject Player { get; private set; }

    public override void Start()
    {
        base.Start();
        
        Player = new PlayerPrefab(new Vector(200, 200));
        Objects.Add(Player);
    }
}