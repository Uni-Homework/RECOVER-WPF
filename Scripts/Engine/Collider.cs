using System.Windows;
using RECOVER.Inner;

namespace RECOVER.Scripts.Engine;

public abstract class Collider : Component, IDisposable
{
    private bool _isTrigger;
    private Vector _origin;

    protected Collider()
    {
        ColliderMap.RegisterGlobal(this);
    }

    public virtual Rect Bounds { get; }

    public bool IsTrigger
    {
        get => _isTrigger;
        set => Set(ref _isTrigger, value);
    }

    public Vector Origin
    {
        get => _origin;
        set => Set(ref _origin, value);
    }

    public abstract bool Intersects(Collider other);
    public abstract bool IntersectsDelta(Collider other, double deltaTime);

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

    public override Rect Bounds
    {
        get
        {
            Rect rect = new Rect(GameObject.Transform.Position.X, GameObject.Transform.Position.Y,
                wight, height);
            rect.Offset(wight * Origin.X, height * Origin.Y);
            return rect;
        }
    }

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