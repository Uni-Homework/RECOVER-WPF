using System.Windows;
using RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Assets.Prefabs.Player.PlayerResource;
using RECOVER.Assets.Prefabs.SpaceStation;
using RECOVER.Assets.Prefabs.SpaceTrash;
using RECOVER.Assets.Prefabs.Terminal;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.MainBase;

public class MainBaseScene : Scene
{
    private DetectedItemsComponent _detectorItems;
    private PlayerController _playerController;
    private PlayerResourceViewer _resourceViewer;
    private const uint MaxTrashCount = 50;

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
        PlayerController = player.GetComponent<PlayerController>();
        ResourceViewer = player.GetComponent<PlayerResourceViewer>();
        objects.Add(player);
        objects.Add(item);
        objects.Add(enetgyenricher);
        objects.Add(waterPlayerResourceFiller);

        int cn = 0;
        for (int i = 0; i < MaxTrashCount; i++)
        {
            Random r = new Random();

            int x;
            int y;
            x = y = 0;
            
            // Is trash in "bad" zone (where it shouldn't spawn)?
            bool c = true;
            while (c)
            {
                x = r.Next(-1000, 1900);
                y = r.Next(-1000, 1900);
                c = (x > -300 && x < 900) && (y > -300 && y < 900);
            }
            
            var prefab = new SpaceTrashPrefab(x, y);
            prefab.Transform.Rotation = r.Next(0, 360);
            prefab.Transform.Velocity = new Vector(0.08, 0);
            objects.Add(prefab);
            cn++;
        }
        Console.WriteLine(cn);
    }

    public DetectedItemsComponent DetectorItems
    {
        get => _detectorItems;
        private set { Set(ref _detectorItems, value); }
    }

    public PlayerController PlayerController
    {
        get => _playerController;
        private set => Set(ref _playerController, value);
    }

    public PlayerResourceViewer ResourceViewer
    {
        get => _resourceViewer;
        private set => Set(ref _resourceViewer, value);
    }
}