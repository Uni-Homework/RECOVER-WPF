using System.Windows;
using RECOVER.Assets.Prefabs;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    public MainBaseScene() : base()
    {
        base.Start();
        
        // Creating player
        PlayerPrefab player = new PlayerPrefab(new Vector(200, 0));
        
        // You can rotate Player as well!
        player.Transform.Rotation = 180.0;
        
        // Creating game objects
        GameObject cube1 = new DebugBoxPrefab(new Vector(100, 200));
        GameObject cube2 = new DebugBoxPrefab(new Vector(200, 200));
        GameObject cube3 = new DebugBoxPrefab(new Vector(300, 200));
        
        // Naming our cubes to modify their behaviour in Update()
        cube1.Name = "Cube1";
        cube2.Name = "Cube2";
        cube3.Name = "Cube3";
        
        // Adding game objects to the scene objects list
        objects.Add(cube1);
        objects.Add(cube2);
        objects.Add(cube3);
        objects.Add(player);
    }

    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
        
        foreach (var obj in Objects)
        {
            // Behaviour for cubes to fly, rotate, etc.
            if (obj.Name == "Cube1") obj.Transform.Position += new Vector(0, 0.5);
            if (obj.Name == "Cube2") obj.Transform.Position += new Vector(-0.2, 0);
            if (obj.Name == "Cube3") obj.Transform.Rotation += 2;
        }
    }
    
    

}