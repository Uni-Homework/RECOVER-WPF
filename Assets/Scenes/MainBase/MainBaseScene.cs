using System.Windows;
using RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Assets.Prefabs.SpaceStation;
using RECOVER.Assets.Prefabs.SpaceTrash;
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
            "ABBBBBBBBBBBBBBBBBBC\n" +
            "DabbbbbbbbbbbbbbbbcE\n" +
            "DdeeeeeeeeeeeeeeeefE\n" +
            "Ddeeeeeeeeeeeeeeeeee\n" +
            "Ddeeeeeeeeeeeeeeeeee\n" +
            "Ddeeeeeeeeeeeeeeeeee\n" +
            "Ddeeeeeeeeeeeeeeeeee\n" +
            "DdeeeeeeeeeeeeeeeefE\n" +
            "DghhhhhhhhhhhhhhhhiE\n" +
            "FGGGGGGGGGGGGGGGGGGH";

        // Create and add the space station
        var spaceStation = new SpaceStationPrefab(spaceStationLayout, new Vector(0, 0));
        objects.Add(spaceStation);

        // Add wall tiles to the scene
        foreach (var wallTile in spaceStation.WallTiles)
        {
            objects.Add(wallTile);
        }

        var player = new PlayerPrefab(new Vector(400, 200));
        var item = new TerminalPrefab(100, 100, player);
        var enetgyenricher = new EnergyPlayerResourceFiller(100, 200);
        var waterPlayerResourceFiller = new WaterPlayerResourceFiller(200, 200);
        DetectorItems = player.GetComponent<DetectedItemsComponent>();
        objects.Add(player);
        objects.Add(item);
        objects.Add(enetgyenricher);
        objects.Add(waterPlayerResourceFiller);

        for (int i = 0; i < 50; i++)
        {
            Random r = new Random();
            int x = r.Next(-1000, 1900); 
            int y = r.Next(-1000, 1900);
            if ((x > -300 && x < 900) && (y > -300 && y < 900))
            {
            }
            else
            {
                var prefab = new SpaceTrashPrefab(x, y);
                prefab.Transform.Rotation = r.Next(0, 360);
                prefab.Transform.Velocity = new Vector(0.08, 0);
                objects.Add(prefab);
            }
        }
    }

    public DetectedItemsComponent DetectorItems
    {
        get => _detectorItems;
        private set { Set(ref _detectorItems, value); }
    }
}