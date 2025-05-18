using System.Windows.Media;
using RECOVER.Type;

namespace RECOVER.Scripts.Engine;

public class SpriteComponent(TileType tileType) : Component
{
    private ImageSource _source = App.Current.Resources[tileType.ToString()] as ImageSource;

    public ImageSource Source
    {
        get => _source;
        set => Set(ref _source, value);
    }
}