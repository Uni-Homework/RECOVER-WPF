using System.Windows;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;

namespace RECOVER.Inner;

public class ColliderMap
{
    private HashSet<Collider> colliders = new HashSet<Collider>();
    private Dictionary<Collider, HashSet<Collider>> intersections = new Dictionary<Collider, HashSet<Collider>>();

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

    public static Vector CheckGlobal(GameObject gameObject, double deltaTime)
    {
        if ((App.Current as App).CurrentScene.BaseScene is ITangible scene)
        {
            return scene.ColliderMap.Check(gameObject, deltaTime);
        }
        else
        {
            return gameObject.Transform.Velocity * deltaTime;
        }
    }

    public Vector Check(GameObject gameObject, double deltaTime)
    {
        Collider goCollider = gameObject.GetComponent<Collider>();

        if (goCollider == null)
        {
            return gameObject.Transform.Velocity * deltaTime;
        }

        if (intersections.TryGetValue(goCollider, out var set))
        {
            HashSet<Collider> colliders = new HashSet<Collider>(this.colliders);
            colliders.ExceptWith(set);

            foreach (Collider other in colliders)
            {
                if (other == goCollider)
                {
                    continue;
                }

                if (goCollider.IntersectsDelta(other, deltaTime))
                {
                    set.Add(other);
                    return new Vector();
                }
            }

            set.RemoveWhere(b =>
            {
                bool result = !goCollider.IntersectsDelta(b, deltaTime);
                return result;
            });

            if (set.Count != 0)
            {
                return new Vector();
            }
        }
        else
        {
            set = new HashSet<Collider>();
            foreach (Collider other in colliders)
            {
                if (other == goCollider)
                {
                    continue;
                }

                if (goCollider.IntersectsDelta(other, deltaTime))
                {
                    set.Add(other);
                    return new Vector();
                }
            }

            intersections.Add(goCollider, set);
            
            if (set.Count != 0)
            {
                return new Vector();
            }
        }

        return gameObject.Transform.Velocity * deltaTime;
    }
}