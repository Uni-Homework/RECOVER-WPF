using System.Windows;
using System.Windows.Media;
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
        Transform.Origin = new Point(0.5, 0.5);

        SpriteComponent sprite = new SpriteComponent((ImageSource)App.Current.Resources["FloorMainBaseTile"]);
        AddComponent(sprite);
        AddComponent(new BoxCollider(sprite.GetRectangle().Width, sprite.GetRectangle().Height));
    }
}