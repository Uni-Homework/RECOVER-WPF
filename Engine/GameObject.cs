using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public abstract class GameObject : DeafNotificationObject
{
    private List<Component> components;
    private Transform transform;

    public GameObject()
    {
        Components = new List<Component>();
        Transform = new Transform();
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
        component.GameObject = this;
        components.Add(component);
        return component;
    }

    public T GetComponent<T>() where T : Component => components.OfType<T>().FirstOrDefault();

    public virtual void Update(double deltaTime)
    {
        foreach (var component in components) component.Update(deltaTime);
    }

    public virtual void Start()
    {
        foreach (var component in components) component.Start(); 
    }
}