using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
    }
    
    public Rectangle GetRectangle() => _rectangle;
}
