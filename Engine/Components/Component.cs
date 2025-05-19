using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine.Components;

public abstract class Component : DeafNotificationObject
{
    public GameObject GameObject { get; internal set; }

    public virtual void Start()
    {
    }

    public virtual void Update(double deltaTime)
    {
    }
}