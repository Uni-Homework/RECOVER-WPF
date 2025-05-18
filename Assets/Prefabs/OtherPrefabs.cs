using System.Windows;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs;

public class DebugBoxPrefab : GameObject
{
    /// <summary>
    /// A box with tile sprite to demonstrate collision physics.
    /// </summary>
    /// <param name="position"></param>
    public DebugBoxPrefab(Vector position)
    {
        Transform.Position = position;

        SpriteComponent sprite = new SpriteComponent(new Uri("pack://application:,,,/Assets/Resources/Tile/floor.png"));
        AddComponent(sprite);
        AddComponent(new BoxCollider(sprite.GetRectangle().Width, sprite.GetRectangle().Height));
    }
}