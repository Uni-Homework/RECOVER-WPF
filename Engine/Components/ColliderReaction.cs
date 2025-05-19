namespace RECOVER.Engine.Components;

public abstract class ColliderReaction : Component
{
    public virtual void OnCollisionEnter(GameObject other)
    {
    }

    public virtual void OnCollisionStay(GameObject other)
    {
    }

    public virtual void OnCollisionExit(GameObject other)
    {
    }

    public virtual void OnTriggerEnter(GameObject other)
    {
    }

    public virtual void OnTriggerStay(GameObject other)
    {
    }

    public virtual void OnTriggerExit(GameObject other)
    {
    }
}