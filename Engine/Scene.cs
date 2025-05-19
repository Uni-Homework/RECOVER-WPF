using RECOVER.Engine.Components;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public abstract class Scene : DeafNotificationObject
{
    protected List<GameObject> objects;

    private Dictionary<(Collider, Collider), bool> _previousCollisions;
    private bool _isInitialized = false;

    /// <summary>
    /// Default constructor for a scene.
    /// </summary>
    public Scene()
    {
        objects = new List<GameObject>();
        _previousCollisions = new Dictionary<(Collider, Collider), bool>();
    }

    public IReadOnlyList<GameObject> Objects => objects;

    /// <summary>
    /// Runs once
    /// </summary>
    public virtual void Start()
    {
        foreach (var obj in objects) obj.Start();
    }

    /// <summary>
    /// Runs indefinitely
    /// </summary>
    /// <param name="deltaTime">Just pass it here. It's important, I swear...</param>
    public virtual void Update(double deltaTime)
    {
        UpdatePhysics(deltaTime);
        foreach (var obj in objects) obj.Update(deltaTime);
    }

    public virtual void UpdatePhysics(double deltaTime)
    {
        Dictionary<(Collider, Collider), bool> previousCollisionsCopy =
            new Dictionary<(Collider, Collider), bool>(_previousCollisions);
        _previousCollisions.Clear();
        
        List<Collider> allColliders = objects.SelectMany(go => go.Components.OfType<Collider>()).ToList();
        
        for (int i = 0; i < allColliders.Count; i++)
        {
            for (int j = i + 1; j < allColliders.Count; j++)
            {
                Collider colliderA = allColliders[i];
                Collider colliderB = allColliders[j];
                
                bool intersects = colliderA.IntersectsDelta(colliderB, deltaTime);
                var collisionKey = (colliderA, colliderB);
                
                if (intersects)
                {
                    _previousCollisions[collisionKey] = true;
                    
                    GameObject gameObjectA = colliderA.GameObject;
                    GameObject gameObjectB = colliderB.GameObject;
                    List<ColliderReaction> reactionsA = gameObjectA.GetComponents<ColliderReaction>().ToList();
                    List<ColliderReaction> reactionsB = gameObjectB.GetComponents<ColliderReaction>().ToList();
                    
                    if (colliderA.IsTrigger || colliderB.IsTrigger)
                    {
                        foreach (ColliderReaction reaction in reactionsA)
                        {
                            if (!previousCollisionsCopy.ContainsKey(collisionKey))
                            {
                                reaction.OnTriggerEnter();
                            }
                            else
                            {
                                reaction.OnTriggerStay();
                            }
                        }

                        foreach (ColliderReaction reaction in reactionsB)
                        {
                            if (!previousCollisionsCopy.ContainsKey(collisionKey))
                            {
                                reaction.OnTriggerEnter();
                            }
                            else
                            {
                                reaction.OnTriggerStay();
                            }
                        }
                    }
                    else
                    {
                        foreach (ColliderReaction reaction in reactionsA)
                        {
                            if (!previousCollisionsCopy.ContainsKey(collisionKey))
                            {
                                reaction.OnCollisionEnter();
                            }
                            else
                            {
                                reaction.OnCollisionStay();
                            }
                        }

                        foreach (ColliderReaction reaction in reactionsB)
                        {
                            if (!previousCollisionsCopy.ContainsKey(collisionKey))
                            {
                                reaction.OnCollisionEnter();
                            }
                            else
                            {
                                reaction.OnCollisionStay();
                            }
                        }
                    }
                }
            }
        }
        
        foreach (var collision in previousCollisionsCopy)
        {
            var colliderA = collision.Key.Item1;
            var colliderB = collision.Key.Item2;
            
            if (!_previousCollisions.ContainsKey(collision.Key))
            {
                GameObject gameObjectA = colliderA.GameObject;
                GameObject gameObjectB = colliderB.GameObject;
                
                List<ColliderReaction> reactionsA = gameObjectA.GetComponents<ColliderReaction>().ToList();
                List<ColliderReaction> reactionsB = gameObjectB.GetComponents<ColliderReaction>().ToList();
                
                if (colliderA.IsTrigger || colliderB.IsTrigger)
                {
                    foreach (ColliderReaction reaction in reactionsA)
                    {
                        reaction.OnTriggerExit();
                    }

                    foreach (ColliderReaction reaction in reactionsB)
                    {
                        reaction.OnTriggerExit();
                    }
                }
                else
                {
                    foreach (ColliderReaction reaction in reactionsA)
                    {
                        reaction.OnCollisionExit();
                    }

                    foreach (ColliderReaction reaction in reactionsB)
                    {
                        reaction.OnCollisionExit();
                    }
                }
            }
        }
    }
}