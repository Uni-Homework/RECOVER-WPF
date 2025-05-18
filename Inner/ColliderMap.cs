using RECOVER.Scripts;
using RECOVER.Scripts.Engine;

namespace RECOVER.Inner;

public class ColliderMap
{
    private HashSet<Collider> colliders = new HashSet<Collider>();

    public void Register(Collider collider)
    {
        colliders.Add(collider);
    }

    public void Remove(Collider collider)
    {
        colliders.Remove(collider);
    }

    public static void RemoveGlobal(Collider collider)
    {
        if ((App.Current as App).CurrentScene.BaseScene is ITangible scene)
        {
            scene.ColliderMap.Remove(collider);
        }
    }

    public static void RegisterGlobal(Collider collider)
    {
        if ((App.Current as App).CurrentScene.BaseScene is ITangible scene)
        {
            scene.ColliderMap.Register(collider);
        }
    }

    public static void ColliderIterationGlobal(GameObject gameObject, double deltaTime)
    {
        if ((App.Current as App).CurrentScene.BaseScene is ITangible scene)
        {
            scene.ColliderMap.ColliderIteration(gameObject, deltaTime);
        }
    }

    public void ColliderIteration(GameObject gameObject, double deltaTime)
    {
        Collider goCollider = gameObject.GetComponent<Collider>();
        IEnumerable<ColliderReaction> reactions = gameObject.GetComponents<ColliderReaction>();

        foreach (var collider in colliders)
        {
            bool ncp = goCollider.IntersectsDelta(collider, deltaTime);
            bool nop = goCollider.Intersects(collider);
            bool isTrigger = collider.IsTrigger;

            if (collider == goCollider)
            {
                continue;
            }

            if (!ncp && nop)
            {
                if (isTrigger)
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnTriggerExit(collider.GameObject);
                    }
                }
                else
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnCollisionExit(collider.GameObject);
                    }
                }
            }
            else if (ncp && !nop)
            {
                if (isTrigger)
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnTriggerEnter(collider.GameObject);
                    }
                }
                else
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnCollisionEnter(collider.GameObject);
                    }
                }
            }
            else if (ncp && nop)
            {
                if (isTrigger)
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnTriggerStay(collider.GameObject);
                    }
                }
                else
                {
                    foreach (var colliderReaction in reactions)
                    {
                        colliderReaction.OnCollisionStay(collider.GameObject);
                    }
                }
            }
        }
    }
}