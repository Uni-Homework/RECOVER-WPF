using System.Windows;
using RECOVER.Inner;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;
using RECOVER.Scripts.Model;
using RECOVER.Type;

namespace RECOVER;

public class MainBaseScene : DeafNotificationObject, IScene
{
    private GameObject player;
    private List<GameObject> gameObjects;
    private List<Cell> baseMap;

    public MainBaseScene()
    {
        this.gameObjects = new List<GameObject>();
    }

    public GameObject Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    public List<Cell> BaseMap
    {
        get => baseMap;
        private set => Set(ref baseMap, value);
    }

    public void Start()
    {
        Player = new GameObject();
        Player.Transform.Position = new Vector(200, 200);
        Player.AddComponent(new RigidBody { IsKinematic = false });
        Player.AddComponent(new PlayerController());
        gameObjects.Add(Player);
        BaseMap = MapLayoutLoader.GetMapsBy(SceneType.MainBaseScene);
    }

    public void Update(double deltaTime)
    {
        foreach (var go in gameObjects)
            go.Update(deltaTime);
    }
}

public class MapLayoutLoader
{
    public static List<Cell> GetMapsBy(SceneType mainBaseScene)
    {
        string d = "1111111111\n" +
                   "1222111121\n" +
                   "1222211221\n" +
                   "1222211121\n" +
                   "1222221121\n" +
                   "1111111111";
        string[] s = d.Split("\n");
        List<Cell> cells = new List<Cell>();

        for (int x = 0; x < s.Length; x++)
        {
            for (int y = 0; y < s[x].Length; y++)
            {
                cells.Add(new Cell(y, x, Enum.GetValues<TileType>()[int.Parse(s[x].Substring(y, 1)) - 1]));
            }
        }

        return cells;
    }
}