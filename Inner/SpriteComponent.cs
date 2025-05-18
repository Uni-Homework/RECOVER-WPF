using System.Windows.Media;
using RECOVER.Scripts.Engine;
using RECOVER.Type;

namespace RECOVER.Inner;

public class SpriteComponent(TileType tileType) : Component
{
    private ImageSource _source = App.Current.Resources[tileType.ToString()] as ImageSource;

    public ImageSource Source
    {
        get => _source;
        set => Set(ref _source, value);
    }
}