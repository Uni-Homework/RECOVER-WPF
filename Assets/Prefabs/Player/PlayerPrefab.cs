using System.Windows;
using System.Windows.Media.Imaging;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerPrefab : GameObject
{
    public PlayerPrefab(Vector position) : base()
    {
        Transform.Position = position;
        
        // Initialize components properly using AddComponent
        var rigidBody = new RigidBody { IsKinematic = false };
        AddComponent(rigidBody);
        
        AddComponent(new PlayerController());
        AddComponent(new BoxCollider(20, 20));
        AddComponent(new PlayerColliderController());

        // SpriteComponent sprite = new SpriteComponent(new Uri("pack://application:,,,/Assets/Resources/Player/Spacesuit.png", UriKind.Absolute));
        // AddComponent(sprite);
    }
}