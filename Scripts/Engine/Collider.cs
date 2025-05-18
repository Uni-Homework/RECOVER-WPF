using System.Windows;
using RECOVER.Inner;

namespace RECOVER.Scripts.Engine;

public abstract class Collider : Component, IDisposable
{
    public virtual Rect Bounds { get; }

    public abstract bool Intersects(Collider other);
    public abstract bool IntersectsDelta(Collider other, double deltaTime);

    protected Collider()
    {
        ColliderMap.RegisterGlobal(this);
    }


    public void Dispose()
    {
        ColliderMap.RemoveGlobal(this);
    }
}

public class BoxCollider(double wight, double height) : Collider
{
    private double wight = wight;
    private double height = height;

    public double Wight
    {
        get => wight;
        set => Set(ref wight, value);
    }

    public double Height
    {
        get => height;
        set => Set(ref height, value);
    }

    public override Rect Bounds => new Rect(GameObject.Transform.Position.X, GameObject.Transform.Position.Y,
        wight, height);

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