using System.Windows;

namespace RECOVER.Scripts.Engine;

public class Transform
{
    public Vector Position { get; set; } = new Vector(0, 0);
    public Vector Velocity { get; set; } = new Vector(0, 0);
}