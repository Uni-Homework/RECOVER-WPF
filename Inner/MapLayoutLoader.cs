using System.Windows;
using System.Windows.Input;
using RECOVER.Scripts;
using RECOVER.Scripts.Engine;
using RECOVER.Scripts.Model;
using RECOVER.Type;

namespace RECOVER.Inner;

public class MapLayoutLoader
{
    private static int[,] mainBaseMap =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1 },
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }
    };

    public static Map GetMapsBy(SceneType mainBaseScene, GameObject player)
    {
        Map map = new Map();
        map.HeightOfCell = 64;
        map.WidthOfCell = 64;
        map.Player = player;
        List<GameObject> cells = new List<GameObject>(mainBaseMap.GetLength(0) * mainBaseMap.GetLength(1));

        if (mainBaseScene == SceneType.MainBaseScene)
        {
            for (int y = 0; y < mainBaseMap.GetLength(0); y++)
            {
                for (int x = 0; x < mainBaseMap.GetLength(1); x++)
                {
                    GameObject cell = new GameObject();

                    if (mainBaseMap[y, x] == 1)
                    {
                        cell.AddComponent(new BoxCollider(map.WidthOfCell, map.WidthOfCell));
                    }

                    cell.Transform.Position = new Vector(x * map.WidthOfCell, y * map.HeightOfCell);
                    cell.AddComponent(new SpriteComponent((TileType)mainBaseMap[y, x]));
                    cell.AddComponent(new Cell(x, y, Convert.ToBoolean(mainBaseMap[y, x])));
                    cells.Add(cell);
                }
            }
        }
        
        ItemObject o = new ItemObject(7 * map.WidthOfCell, 1 * map.HeightOfCell, 40, 64, Key.D,
            () => { }, "Oткрыть терминал");
        o.AddComponent(new SpriteComponent(TileType.ItemTerminalTile));
        cells.Add(o);

        map.CellsOfMap = cells;


        return map;
    }
}