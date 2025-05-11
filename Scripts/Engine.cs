using System.Windows;

namespace RECOVER.Scripts;

public class Engine
{
    public abstract class Component
    {
        public GameObject GameObject { get; internal set; }
        public virtual void Update(double deltaTime) { }
    }

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

    public class Transform
    {
        public Vector Position { get; set; } = new Vector(0, 0);
        public Vector Velocity { get; set; } = new Vector(0, 0);
    }

    public class RigidBody : Component
    {
        public bool IsKinematic { get; set; }
        public bool UseGravity { get; set; }

        public override void Update(double deltaTime)
        {
            if (!IsKinematic)
            {
                if (UseGravity)
                    GameObject.Transform.Velocity += new Vector(0, 9.81) * deltaTime;

                GameObject.Transform.Position += GameObject.Transform.Velocity * deltaTime;
            }
        }
    }

}