using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using RECOVER.Assets.Prefabs;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Scenes;

public class MainBaseScene : Scene
{
    // Necessary for that stupid thing called WPF
    private PlayerPrefab player;
    
    // for debug
    private List<Rectangle> _debugBoxes = new List<Rectangle>();
    
    public PlayerPrefab Player
    {
        get => player;
        private set => Set(ref player, value);
    }

    public MainBaseScene(Canvas canvas) : base(canvas)
    {
        base.Start();
        
        // Creating player
        player = new PlayerPrefab(new Vector(200, 0));
        
        // You can rotate Player as well!
        player.Transform.Rotation = 180.0;
        objects.Add(player);
        
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
    }

    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
        
        // Debug section!
        foreach (var box in _debugBoxes) SceneCanvas.Children.Remove(box);
        _debugBoxes.Clear();
        
        foreach (var obj in Objects)
        {
            // Behaviour for cubes to fly, rotate, etc.
            if (obj.Name == "Cube1") obj.Transform.Position += new Vector(0, 0.5);
            if (obj.Name == "Cube2") obj.Transform.Position += new Vector(-0.2, 0);
            if (obj.Name == "Cube3") obj.Transform.Rotation += 2;

            
            // Also debug section!
            var collider = obj.GetComponent<BoxCollider>();
            if (collider != null)
            {
                // Rectangle is a main drawable structure for WPF
                Rectangle rect = new Rectangle();
                rect.Width = (double)collider.Bounds.Width;
                rect.Height = (double)collider.Bounds.Height;
                rect.Stroke = Brushes.Red;
                rect.Fill = Brushes.Transparent;

                // These methods are to update the positions of the debug rects
                Canvas.SetLeft(rect, (double)collider?.Bounds.Left);
                Canvas.SetTop(rect, (double)collider?.Bounds.Top);

                // This one draws a rect on the Canvas
                SceneCanvas.Children.Add(rect);
                
                _debugBoxes.Add(rect);
            }
        }
    }
    
    
}