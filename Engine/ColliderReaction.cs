namespace RECOVER.Engine;

public abstract class ColliderReaction : Component
{
    public abstract void OnCollisionEnter();
    public abstract void OnCollisionStay();
    public abstract void OnCollisionExit();
    public abstract void OnTriggerEnter();
    public abstract void OnTriggerStay();
    public abstract void OnTriggerExit();
}