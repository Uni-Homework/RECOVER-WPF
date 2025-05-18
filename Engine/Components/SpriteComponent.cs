using System.Windows;
using System.Windows.Media;

namespace RECOVER.Engine;

public class SpriteComponent : Component
{
    public ImageSource Image { get; set; }
    public Rect Bounds => new Rect(
        GameObject.Transform.Position.X,
        GameObject.Transform.Position.Y,
        Width,
        Height
    );
    public double Width { get; set; } = 50;
    public double Height { get; set; } = 50;

    public SpriteComponent(double width, double height)
    {
        Width = width;
        Height = height;
    }
    public SpriteComponent(double width, double height, ImageSource image)
    {
        Width = width;
        Height = height;
        Image = image;
    }
}
