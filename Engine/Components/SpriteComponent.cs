using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Rectangle = System.Windows.Shapes.Rectangle;

namespace RECOVER.Engine.Components;

public class SpriteComponent : Component
{
    private ImageBrush _imageBrush;
    private BitmapImage _image;
    private Rectangle _rectangle;

    public SpriteComponent(Uri uri)
    {
        _image = new BitmapImage(uri);
        
        _imageBrush = new ImageBrush();
        _imageBrush.ImageSource = _image;
        
        _rectangle = new Rectangle();
        _rectangle.Width = _image.Width;
        _rectangle.Height = _image.Height;
        _rectangle.Fill = _imageBrush;
        _rectangle.Tag = "SpriteComponent";
        _rectangle.RenderTransformOrigin = new Point(0.5, 0.5); 
    }

    public override void Update(double deltaTime)
    {
        Canvas.SetLeft(_rectangle, GameObject.Transform.Position.X);
        Canvas.SetTop(_rectangle, GameObject.Transform.Position.Y);
        
        _rectangle.RenderTransform = new RotateTransform(GameObject.Transform.Rotation);
    }
    
    public Rectangle GetRectangle() => _rectangle;
}
