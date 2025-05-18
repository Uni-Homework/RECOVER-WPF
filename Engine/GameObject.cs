using System.Windows;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public class GameObject : DeafNotificationObject
{
    private List<Component> components;
    private Transform transform;

    public GameObject()
    {
        components = new List<Component>();
        transform = new Transform();
        System.Diagnostics.Debug.WriteLine($"GameObject constructor called for {GetType().Name}");
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
            System.Diagnostics.Debug.WriteLine($"Warning: Attempted to add null component to {GetType().Name}");
            return null;
        }

        component.GameObject = this;
        components.Add(component);
        System.Diagnostics.Debug.WriteLine($"Added component {component.GetType().Name} to {GetType().Name}");
        return component;
    }

    public T GetComponent<T>() where T : Component => components.OfType<T>().FirstOrDefault();

    public virtual void Update(double deltaTime)
    {
        System.Diagnostics.Debug.WriteLine($"GameObject.Update() called for {GetType().Name}, deltaTime: {deltaTime}");
        foreach (var component in components) 
        {
            if (component == null)
            {
                System.Diagnostics.Debug.WriteLine($"Warning: Null component found in {GetType().Name}");
                continue;
            }
            System.Diagnostics.Debug.WriteLine($"Updating component {component.GetType().Name}");
            component.Update(deltaTime);
        }
    }

    public virtual void Start()
    {
        System.Diagnostics.Debug.WriteLine($"GameObject.Start() called for {GetType().Name}");
        foreach (var component in components) 
        {
            if (component == null)
            {
                System.Diagnostics.Debug.WriteLine($"Warning: Null component found in {GetType().Name}");
                continue;
            }
            System.Diagnostics.Debug.WriteLine($"Starting component {component.GetType().Name}");
            component.Start();
        }
    }
}