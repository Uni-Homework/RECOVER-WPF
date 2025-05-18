using System.Windows;
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

    public static void NextPositionGlobal(GameObject gameObject, double deltaTime)
    {
        if ((App.Current as App).CurrentScene.BaseScene is ITangible scene)
        {
            scene.ColliderMap.ColliderIteration(gameObject, deltaTime);
        }
    }

    public void ColliderIteration(GameObject gameObject, double deltaTime)
    {
        Collider goCollider = gameObject.GetComponent<Collider>();
        ColliderReaction reaction = gameObject.GetComponent<ColliderReaction>();

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
                    reaction.OnTriggerExit();
                }
                else
                {
                    reaction.OnCollisionExit();
                }
            }
            else if (ncp && !nop)
            {
                if (isTrigger)
                {
                    reaction.OnTriggerEnter();
                }
                else
                {
                    reaction.OnCollisionEnter();
                }
            }
            else if (ncp && nop)
            {
                if (isTrigger)
                {
                    reaction.OnTriggerStay();
                }
                else
                {
                    reaction.OnCollisionStay();
                }
            }
        }
    }
}