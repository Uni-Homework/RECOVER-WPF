using System.Windows;
using RECOVER.Engine.Components;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public abstract class Scene : DeafNotificationObject
{
    protected List<GameObject> objects;

    public Scene()
    {
        objects = new List<GameObject>();
    }

    public IReadOnlyList<GameObject> Objects => objects;

    // runs once
    public virtual void Start()
    {
        foreach (var obj in objects) obj.Start();
    }
    
    // runs indefinitely
    public virtual void Update(double deltaTime)
    {
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