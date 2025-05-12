namespace RECOVER.Scripts.Engine;

public abstract class Component
{
    public GameObject GameObject { get; internal set; }
    public virtual void Update(double deltaTime) { }
}