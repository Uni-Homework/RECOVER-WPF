using System.Windows;
using System.Windows.Media;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.SpaceStation;

public class SpaceStationPrefab : GameObject
{
    private const int TILE_SIZE = 64; // Size of each tile in pixels
    private char[,] _tileMap;
    private List<GameObject> _wallTiles;

    public SpaceStationPrefab(string matrix, Vector position)
    {
        Transform.Position = position;
        Transform.Origin = new Point(0.5, 0.5);

        // Parse the matrix string into a 2D array
        string[] rows = matrix.Split('\n');
        int height = rows.Length;
        int width = rows[0].Length;
        _tileMap = new char[width, height];
        _wallTiles = new List<GameObject>();

        // Store the tile map and create wall tiles
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                _tileMap[x, y] = rows[y][x];
                CreateWallTile(x, y, _tileMap[x, y]);
            }
        }

    }

    private void CreateWallTile(int x, int y, char tile)
    {
        var wallTile = new GameObject();
        wallTile.Transform.Position = new Vector(x * TILE_SIZE, y * TILE_SIZE);
        wallTile.Transform.Origin = new Point(0.5, 0.5);

        string[] wallIds = ["WallTl", "WallT", "WallTr", "WallL", "WallR", "WallBl", "WallB", "WallBr"];
        string[] floorIds = ["FloorTl", "FloorT", "FloorTr", "FloorL", "Floor", "FloorR", "FloorBl", "FloorB", "FloorBr"];
        
        string resId = char.IsLower(tile) ? floorIds[tile-'a'] : wallIds[tile-'A'];
        
        // Add sprite component
        var sprite = new SpriteComponent((ImageSource)App.Current.Resources[resId]);
        wallTile.AddComponent(sprite);

        // Add physical collider
        wallTile.AddComponent(new BoxCollider(TILE_SIZE, TILE_SIZE));

        _wallTiles.Add(wallTile);
    }

    public IEnumerable<GameObject> WallTiles => _wallTiles;
}