using RECOVER.Inner;
using RECOVER.Type;

namespace RECOVER.Scripts.Model;

public class Cell : DeafNotificationObject
{
    private int x;
    private int y;
    private TileType type;

    public int X
    {
        get => x;
        private set => Set(ref x, value);
    }

    public int Y
    {
        get => y;
        private set => Set(ref y, value);
    }

    public TileType Type
    {
        get => type;
        private set => Set(ref type, value);
    }

    public Cell(int x, int y, TileType type)
    {
        X = x;
        Y = y;
        Type = type;
    }
}