using System.Windows;
using System.Windows.Controls;
using RECOVER.Engine.Components;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public abstract class Scene : DeafNotificationObject
{
    protected List<GameObject> objects;
    protected Canvas SceneCanvas;
    
    private bool _isInitialized = false;

    /// <summary>
    /// Default constructor for a scene.
    /// </summary>
    /// <param name="canvas">A canvas of a window - required for GameObjects rendering.</param>
    public Scene(Canvas canvas)
    {
        objects = new List<GameObject>();
        SceneCanvas = canvas;
    }

    public IReadOnlyList<GameObject> Objects => objects;

    /// <summary>
    /// Runs once
    /// </summary>
    public virtual void Start()
    {
        foreach (var obj in objects) obj.Start();
    }

    
    /// <summary>
    /// Needs to be executed once on the first Update to initialize all the GameObjects on the canvas.
    /// </summary>
    private void PreUpdate()
    {
        _isInitialized = true;

        foreach (var obj in Objects)
        {
            var sprite = obj.GetComponent<SpriteComponent>();
            if (sprite != null)
            {
                SceneCanvas.Children.Add(sprite.GetRectangle());
            }
        }
    }
    
    /// <summary>
    /// Runs indefinitely
    /// </summary>
    /// <param name="deltaTime">Just pass it here. It's important, I swear...</param>
    public virtual void Update(double deltaTime)
    {
        if(!_isInitialized) PreUpdate();
        UpdatePhysics(deltaTime);
        
        foreach (var obj in objects) obj.Update(deltaTime);
    }

    public virtual void UpdatePhysics(double deltaTime)
    {
        // Check for collisions between all objects
        for (int i = 0; i < objects.Count; i++)
        {
            var obj1 = objects[i];
            var collider1 = obj1.GetComponent<Collider>();
            if (collider1 == null) continue;

            for (int j = i + 1; j < objects.Count; j++)
            {
                var obj2 = objects[j];
                var collider2 = obj2.GetComponent<Collider>();
                if (collider2 == null) continue;

                // If objects are colliding
                if (collider1.Intersects(collider2))
                {
                    // Stop both objects
                    obj1.Transform.Velocity = new Vector(0, 0);
                    obj2.Transform.Velocity = new Vector(0, 0);

                    // Notify collision reactions if they exist
                    var reaction1 = obj1.GetComponent<ColliderReaction>();
                    var reaction2 = obj2.GetComponent<ColliderReaction>();

                    if (reaction1 != null) reaction1.OnCollisionEnter();
                    if (reaction2 != null) reaction2.OnCollisionEnter();
                }
            }
        }
    }
}