using RECOVER.Inner;
using RECOVER.Scripts;

namespace RECOVER.Engine;

public abstract class Component : DeafNotificationObject
{
    public GameObject GameObject { get; internal set; }
    public virtual void Update(double deltaTime) { }
}