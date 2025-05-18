namespace RECOVER.Scripts.Engine;

public abstract class ColliderReaction : Component
{
    public virtual void OnCollisionEnter()
    {
    }

    public virtual void OnCollisionStay()
    {
    }

    public virtual void OnCollisionExit()
    {
    }

    public virtual void OnTriggerEnter()
    {
    }

    public virtual void OnTriggerStay()
    {
    }

    public virtual void OnTriggerExit()
    {
    }
}