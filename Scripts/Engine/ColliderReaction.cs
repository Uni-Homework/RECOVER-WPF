namespace RECOVER.Scripts.Engine;

public abstract class ColliderReaction : Component
{
    public virtual void OnCollisionEnter(GameObject gameObject)
    {
    }

    public virtual void OnCollisionStay(GameObject gameObject)
    {
    }

    public virtual void OnCollisionExit(GameObject gameObject)
    {
    }

    public virtual void OnTriggerEnter(GameObject gameObject)
    {
    }

    public virtual void OnTriggerStay(GameObject gameObject)
    {
    }

    public virtual void OnTriggerExit(GameObject gameObject)
    {
    }
}