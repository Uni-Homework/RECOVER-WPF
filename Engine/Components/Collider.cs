using System.Windows;

namespace RECOVER.Engine;

public abstract class Collider : Component
{
    private bool _isTrigger;

    public virtual Rect Bounds { get; }

    public bool IsTrigger
    {
        get => _isTrigger;
        set => Set(ref _isTrigger, value);
    }

    public abstract bool Intersects(Collider other);
    public abstract bool IntersectsDelta(Collider other, double deltaTime);
}

public class BoxCollider(double width, double height) : Collider
{
    private double width = width;
    private double height = height;

    public double Width
    {
        get => width;
        set => Set(ref width, value);
    }

    public double Height
    {
        get => height;
        set => Set(ref height, value);
    }

    public override Rect Bounds => new Rect(GameObject.Transform.Position.X, GameObject.Transform.Position.Y,
        width, height);

    public override bool Intersects(Collider other)
    {
        if (other is BoxCollider boxCollider)
        {
            return Bounds.IntersectsWith(boxCollider.Bounds);
        }

        return false;
    }

    public override bool IntersectsDelta(Collider other, double deltaTime)
    {
        Rect rect = Bounds;
        rect.Location += GameObject.Transform.Velocity * deltaTime;
        return rect.IntersectsWith(other.Bounds);
    }
}