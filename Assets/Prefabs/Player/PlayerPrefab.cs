using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
using RECOVER.Engine;
using RECOVER.Scripts;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerPrefab : GameObject
{
    public PlayerPrefab(Vector position)
    {
        Transform.Position = position;
        Components.Add(new RigidBody { IsKinematic = false });
        Components.Add(new PlayerController());
        Components.Add(new BoxCollider(20, 20));
        Components.Add(new PlayerColliderController());

        SpriteComponent sprite = new SpriteComponent(30, 30);
        sprite.Image = new BitmapImage(new Uri("Assets/Resources/Player/Spacesuit.png", UriKind.Relative));
        Components.Add(sprite);
    }
}