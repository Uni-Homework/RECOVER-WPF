using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts.Model;

public class Map : Component
{
    private List<GameObject> cellsOfMap;
    private GameObject player;
    private double widthOfCell;
    private double heightOfCell;

    public List<GameObject> CellsOfMap
    {
        get => cellsOfMap;
        set
        {
            Set(ref cellsOfMap, value);
        }
    }

    public GameObject Player
    {
        get => player;
        set => Set(ref player, value);
    }

    public double WidthOfCell
    {
        get => widthOfCell;
        set { Set(ref widthOfCell, value); }
    }

    public double HeightOfCell
    {
        get => heightOfCell;
        set { Set(ref heightOfCell, value); }
    }

    public override void Update(double deltaTime)
    {
    }
}