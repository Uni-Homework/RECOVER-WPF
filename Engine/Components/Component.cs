using RECOVER.Engine.WPFTools;
using RECOVER.Scripts;

namespace RECOVER.Engine;

public abstract class Component : DeafNotificationObject
{
    public GameObject GameObject { get; internal set; }

    public virtual void Start() { }
    public virtual void Update(double deltaTime) { }
}