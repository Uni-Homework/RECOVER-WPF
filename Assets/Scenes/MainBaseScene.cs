using System.Windows;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    public override void Start()
    {
        base.Start();
        Objects.Add(new PlayerPrefab(new Vector(0, 0)));
    }
}