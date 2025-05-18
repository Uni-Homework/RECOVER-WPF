using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public abstract class Scene : DeafNotificationObject
{
    public List<GameObject> Objects;

    // runs once
    public virtual void Start()
    {
        foreach (var obj in Objects) obj.Start();
    }
    
    // runs indefinitely
    public virtual void Update(double deltaTime)
    {
        foreach (var obj in Objects) obj.Update(deltaTime);
    }

    public virtual void UpdatePhysics(double deltaTime)
    {
        // TODO collision handling using Collider.cs and ColliderReaction.cs

        foreach (var obj in Objects)
        {
            
        }
    }
}