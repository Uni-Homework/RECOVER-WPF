using System.Windows.Media;
using Rectangle = System.Windows.Shapes.Rectangle;


namespace RECOVER.Engine.Components;

public class SpriteComponent : Component
{
    private ImageBrush _imageBrush;
    private ImageSource _image;
    private Rectangle _rectangle;

    public SpriteComponent(ImageSource source)
    {
        _image = source;
        _imageBrush = new ImageBrush();
        _imageBrush.ImageSource = _image;
        
        _rectangle = new Rectangle();
        _rectangle.Width = _image.Width;
        _rectangle.Height = _image.Height;
        _rectangle.Fill = _imageBrush;
    }
    
    public Rectangle GetRectangle() => _rectangle;
}
