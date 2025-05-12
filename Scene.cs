using System.Windows;
using System.Windows.Controls;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;

namespace RECOVER;

public class Scene
{
    private List<GameObject> gameObjects;
    private PhysicalWorld physicalWorld;

    public Scene()
    {
        this.gameObjects = new List<GameObject>();
        this.physicalWorld = new PhysicalWorld();
    }

    public PhysicalWorld PhysicalWorld => physicalWorld;
    
    public void Start()
    {
        var world = new GameObject();
        world.Transform.Position = new Vector(0, 0);
        world.AddComponent(new BoxCollider(1000, 1000));

        var player = new GameObject();
        player.Transform.Position = new Vector(200, 200);
        player.AddComponent(new RigidBody { IsKinematic = false });
        player.AddComponent(new PlayerController());
        player.AddComponent(new BoxCollider(200, 200));
        player.AddComponent(new SpriteRender());
        gameObjects.Add(player);
        gameObjects.Add(world);
    }

    public void Update(double deltaTime)
    {
        foreach (var go in gameObjects)
            go.Update(deltaTime);
    }

    public void Render(Canvas gameCanvas)
    {
        gameCanvas.Children.Clear();
        foreach (var go in gameObjects)
        {
            go.GetComponent<SpriteRender>()?.Render(gameCanvas);
        }
    }
}