using System.Windows;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Assets.Prefabs.Terminal;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.MainBase;

public class MainBaseScene : Scene
{
    private DetectedItemsComponent _detectorItems;

    public MainBaseScene() : base()
    {
        PlayerPrefab player = new PlayerPrefab(new Vector(200, 0));
        TerminalPrefab item = new TerminalPrefab(100, 100);
        DetectorItems = player.GetComponent<DetectedItemsComponent>();
        objects.Add(player);
        objects.Add(item);
    }

    public DetectedItemsComponent DetectorItems
    {
        get => _detectorItems;
        private set { Set(ref _detectorItems, value); }
    }
}