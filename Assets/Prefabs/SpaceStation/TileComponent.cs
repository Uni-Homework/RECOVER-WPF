using System.Windows;
using System.Windows.Media;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.SpaceStation;

public class TileComponent : Component
{
    public bool IsWall { get; private set; }
    public ImageSource TileSprite { get; private set; }

    public TileComponent(bool isWall, ImageSource sprite)
    {
        IsWall = isWall;
        TileSprite = sprite;
    }

    public override void Start()
    {
        // Add sprite component
        var sprite = new SpriteComponent(TileSprite);
        GameObject.AddComponent(sprite);

        // Add collider if it's a wall
        if (IsWall)
        {
            var collider = new BoxCollider(sprite.GetRectangle().Width, sprite.GetRectangle().Height);
            GameObject.AddComponent(collider);
        }
    }
}