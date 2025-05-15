using RECOVER.Inner;

namespace RECOVER.Scripts.Model;

public class Cell : DeafNotificationObject
{
    private int x;
    private int y;
    private int type;

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

    public int Type
    {
        get => type;
        private set => Set(ref type, value);
    }

    public Cell(int x, int y, int type)
    {
        X = x;
        Y = y;
        Type = type;
    }
}