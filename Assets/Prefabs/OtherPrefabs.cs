using System.Windows;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs;

public class DebugBoxPrefab : GameObject
{
    public DebugBoxPrefab(Vector position)
    {
        Transform.Position = position;

        Component sprite = new SpriteComponent(new Uri("pack://application:,,,/Assets/Resources/Tile/floor.png"));
        AddComponent(sprite);
        AddComponent(new BoxCollider(5, 5));
    }
}