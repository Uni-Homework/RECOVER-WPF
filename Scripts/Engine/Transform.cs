using System.Windows;
using RECOVER.Inner;

namespace RECOVER.Scripts.Engine;

public class Transform : DeafNotificationObject
{
    private Vector _position = new Vector(0, 0);
    private Vector _velocity = new Vector(0, 0);
    private Vector _rotation = new Vector(0, 0);

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

    public Vector Rotation
    {
        get => _rotation;
        set => Set(ref _rotation, value);
    }
}