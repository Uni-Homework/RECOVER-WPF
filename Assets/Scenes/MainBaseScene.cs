using System.Windows;
using System.Windows.Input;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    public MainBaseScene() : base()
    {
        base.Start();
        PlayerPrefab player = new PlayerPrefab(new Vector(200, 0));
        ItemPrefab item = new ItemPrefab(100, 100, 20, 20, Key.A, () => {}, "");
        objects.Add(player);
        objects.Add(item);
    }
}