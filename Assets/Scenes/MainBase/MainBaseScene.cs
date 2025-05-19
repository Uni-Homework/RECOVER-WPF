using System.Windows;
using RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Assets.Prefabs.SpaceStation;
using RECOVER.Assets.Prefabs.Terminal;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.MainBase;

public class MainBaseScene : Scene
{
    private DetectedItemsComponent _detectorItems;

    public MainBaseScene() : base()
    {
        // Create a simple space station layout
        string spaceStationLayout = 
            "AAAAAAAAAAAAAAAAAAAA\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "A..................A\n" +
            "AAAAAAAAAAAAAAAAAAAA";

        // Create and add the space station
        var spaceStation = new SpaceStationPrefab(spaceStationLayout, new Vector(0, 0));
        objects.Add(spaceStation);

        // Add wall tiles to the scene
        foreach (var wallTile in spaceStation.WallTiles)
        {
            objects.Add(wallTile);
        }

        var player = new PlayerPrefab(new Vector(400, 200));
        var item = new TerminalPrefab(100, 100);
        var enetgyenricher = new EnergyPlayerResourceFiller(100, 200);
        var waterPlayerResourceFiller = new WaterPlayerResourceFiller(200, 200);
        DetectorItems = player.GetComponent<DetectedItemsComponent>();
        objects.Add(player);
        objects.Add(item);
        objects.Add(enetgyenricher);
        objects.Add(waterPlayerResourceFiller);
    }

    public DetectedItemsComponent DetectorItems
    {
        get => _detectorItems;
        private set { Set(ref _detectorItems, value); }
    }
}