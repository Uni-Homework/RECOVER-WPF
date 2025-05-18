using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts.Model;

public class Cell : Component
{
    private int x;
    private int y;
    private bool hasCollider;

    public bool HasCollider
    {
        get => hasCollider;
        set => Set(ref hasCollider, value);
    }

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

    public Cell(int x, int y, bool hasCollider)
    {
        this.x = x;
        this.y = y;
        this.hasCollider = hasCollider;
    }
}