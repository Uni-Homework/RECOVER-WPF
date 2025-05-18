using RECOVER.Inner;

namespace RECOVER.Scripts.Engine;

public abstract class Component : DeafNotificationObject
{
    public GameObject GameObject { get; internal set; }
    public virtual void Update(double deltaTime) { }
}