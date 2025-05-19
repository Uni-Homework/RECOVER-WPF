using System.Windows;
using System.Windows.Media;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerPrefab : GameObject
{
    public PlayerPrefab(Vector position) : base()
    {
        Transform.Position = position;
        Transform.Origin = new Point(0.5, 0.5);

        // Initialize components properly using AddComponent
        var rigidBody = new RigidBody { IsKinematic = false };
        AddComponent(rigidBody);

        AddComponent(new PlayerController());
        AddComponent(new BoxCollider(40, 40));
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["PlayerMen"]));
        AddComponent(new PlayerColliderController());
        AddComponent(new Camera());
    }
}