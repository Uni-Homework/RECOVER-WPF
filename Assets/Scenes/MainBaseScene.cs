using System.Windows;
using RECOVER.Inner;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;
using RECOVER.Scripts.Model;
using RECOVER.Type;

public class MainBaseScene : DeafNotificationObject, IScene
{
    private GameObject player;
    private List<GameObject> gameObjects;
    // TODO
    // private Map map;
    // private ColliderMap colliderMap;

    public MainBaseScene()
    {
        this.gameObjects = new List<GameObject>();
        // this.colliderMap = new ColliderMap();
    }

    public GameObject Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    // TODO
    // public Map Map
    // {
    //     get => map;
    //     private set => Set(ref map, value);
    // }

    public void Start()
    {
        Player = new GameObject();
        Player.Transform.Position = new Vector(200, 200);
        Player.AddComponent(new RigidBody { IsKinematic = false });
        Player.AddComponent(new PlayerController());
        Player.AddComponent(new BoxCollider(20, 20));
        Player.AddComponent(new PlayerColliderController());

        // TODO: re-enable the TileMap here
        // Map = MapLayoutLoader.GetMapsBy(SceneType.MainBaseScene, player);

        gameObjects.Add(Player);
        // TODO
        // gameObjects.Add(new GameObject
        // {
        //     Components = { Map }
        // });
    }

    public void Update(double deltaTime)
    {
        foreach (var go in gameObjects)
            go.Update(deltaTime);
    }

    // public ColliderMap ColliderMap => colliderMap;
}