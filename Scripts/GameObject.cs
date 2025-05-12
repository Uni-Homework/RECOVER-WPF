using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

public class GameObject
{
    public Transform Transform { get; } = new Transform();
    private List<Component> _components = new();

    public T AddComponent<T>(T component) where T : Component
    {
        component.GameObject = this;
        _components.Add(component);
        return component;
    }

    public T GetComponent<T>() where T : Component => _components.OfType<T>().FirstOrDefault();

    public void Update(double deltaTime)
    {
        foreach (var component in _components)
            component.Update(deltaTime);
    }
}