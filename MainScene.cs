using System.Windows;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;

namespace RECOVER;

public class MainScene : DeafNotificationObject, IScene
{
    private List<GameObject> gameObjects;
    private GameObject player;

    public MainScene()
    {
        this.gameObjects = new List<GameObject>();
    }

    public GameObject Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    public void Start()
    {
        Player = new GameObject();
        Player.Transform.Position = new Vector(200, 200);
        Player.AddComponent(new RigidBody { IsKinematic = false });
        Player.AddComponent(new PlayerController());
        gameObjects.Add(Player);
    }

    public void Update(double deltaTime)
    {
        foreach (var go in gameObjects)
            go.Update(deltaTime);
    }
}