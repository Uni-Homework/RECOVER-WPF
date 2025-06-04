using System.Diagnostics;
using RECOVER.Engine.Components;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public class GameObject : DeafNotificationObject
{
    private List<Component> components;
    private Transform transform;
    public string Name { get; set; }

    public GameObject(string name = "GameObject")
    {
        components = new List<Component>();
        transform = new Transform();
        Debug.WriteLine($"GameObject constructor called for {GetType().Name}");
        Name = name;

    }

    public List<Component> Components
    {
        get => components;
        private set => Set(ref components, value);
    }

    public Transform Transform
    {
        get => transform; 
        set => Set(ref transform, value);
    }

    public T AddComponent<T>(T component) where T : Component
    {
        if (component == null)
        {
            Debug.WriteLine($"Warning: Attempted to add null component to {GetType().Name}");
            return null;
        }

        component.GameObject = this;
        components.Add(component);
        Debug.WriteLine($"Added component {component.GetType().Name} to {GetType().Name}");
        return component;
    }

    public T GetComponent<T>() where T : Component => GetComponents<T>().FirstOrDefault();
    
    public IEnumerable<T> GetComponents<T>() where T : Component => components.OfType<T>();

    public virtual void Update(double deltaTime)
    {
        // Debug.WriteLine($"GameObject.Update() called for {GetType().Name}, deltaTime: {deltaTime}");
        foreach (var component in components) 
        {
            if (component == null)
            {
                Debug.WriteLine($"Warning: Null component found in {GetType().Name}");
                continue;
            }
            // that thing ate too much performance
            // Debug.WriteLine($"Updating component {component.GetType().Name}");
            component.Update(deltaTime);
        }
        Transform.Position += Transform.Velocity;
    }

    public virtual void Start()
    {
        Debug.WriteLine($"GameObject.Start() called for {GetType().Name}");
        foreach (var component in components) 
        {
            if (component == null)
            {
                Debug.WriteLine($"Warning: Null component found in {GetType().Name}");
                continue;
            }
            Debug.WriteLine($"Starting component {component.GetType().Name}");
            component.Start();
        }
    }
}