using System.Windows;
using RECOVER.Inner;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;
using RECOVER.Scripts.Model;
using RECOVER.Type;

namespace RECOVER.Scenes;

public class MainBaseScene : DeafNotificationObject, IScene, ITangible
{
    private GameObject player;
    private List<GameObject> gameObjects;
    private Map map;
    private ColliderMap colliderMap;
    private ItemActivator _itemActivator;

    public MainBaseScene()
    {
        this.gameObjects = new List<GameObject>();
        this.colliderMap = new ColliderMap();
    }

    public GameObject Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    public Map Map
    {
        get => map;
        private set => Set(ref map, value);
    }

    public ItemActivator ItemActivator
    {
        get => _itemActivator;
        private set => Set(ref _itemActivator, value);
    }

    public void Start()
    {
        Map = MapLayoutLoader.GetMapsBy(SceneType.MainBaseScene, player);
        ItemActivator = new ItemActivator();

        Player = new GameObject();
        Player.Transform.Position = new Vector(200, 200);
        Player.AddComponent(new RigidBody { IsKinematic = false });
        Player.AddComponent(new PlayerController());
        Player.AddComponent(new BoxCollider(20, 20));
        Player.AddComponent(new PlayerColliderController());
        Player.AddComponent(new ItemObjectReaction());
        Player.AddComponent(ItemActivator);

        gameObjects.Add(Player);
        gameObjects.Add(new GameObject
        {
            Components = { Map }
        });
    }

    public void Update(double deltaTime)
    {
        foreach (var go in gameObjects)
            go.Update(deltaTime);
    }

    public ColliderMap ColliderMap => colliderMap;
}