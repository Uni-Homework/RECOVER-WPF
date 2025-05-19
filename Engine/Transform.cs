using System.Windows;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Engine;

public class Transform : DeafNotificationObject
{
    private Vector _position = new Vector(0, 0);
    private Vector _velocity = new Vector(0, 0);
    private Point _origin = new Point(0, 0);
    private double _rotation = 0;

    public Vector Position
    {
        get => _position;
        set => Set(ref _position, value);
    }

    public Vector Velocity
    {
        get => _velocity;
        set => Set(ref _velocity, value);
    }

    public double Rotation
    {
        get => _rotation;
        set => Set(ref _rotation, value);
    }

    public Point Origin
    {
        get => _origin;
        set { Set(ref _origin, value); }
    }
}