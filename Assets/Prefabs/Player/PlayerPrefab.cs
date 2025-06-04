using System.Windows;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Player.PlayerResource;
using RECOVER.Assets.Scenes;
using RECOVER.Engine;
using RECOVER.Engine.Components;
using RECOVER.Engine.Models;
using RECOVER.Engine.Serialization;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerPrefab : GameObject
{
    TrashResourcePlayer trashResourceComponent;
    private string _nickname;

    public PlayerPrefab(Vector position, string nickname) : base()
    {
        _nickname = nickname;
        
        Transform.Position = position;
        Transform.Origin = new Point(0.5, 0.5);
        
        trashResourceComponent = new TrashResourcePlayer();

        // Initialize components properly using AddComponent
        var rigidBody = new RigidBody { IsKinematic = false };

        AddComponent(rigidBody);
        AddComponent(new PlayerController());
        AddComponent(new BoxCollider(40, 40));
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["PlayerMen"]));
        AddComponent(new PlayerColliderController());
        AddComponent(new Camera());
        AddComponent(new DetectedItemsComponent());
        AddComponent(new PlayerResourceViewer());
        AddComponent(new EnergyResourcePlayer());
        AddComponent(new WaterResourcePlayer());
        AddComponent(trashResourceComponent);
    }

    /// <summary>
    /// Fires on player's death.
    /// </summary>
    public void Die()
    {
        LeaderboardSerializer.AddEntry(_nickname, (int) trashResourceComponent.Current);
        App.SetScene(SceneType.GameOver);
    }

    /// <summary>
    /// Fires on player's victory.
    /// </summary>
    public void Win()
    {
        LeaderboardSerializer.AddEntry(_nickname, (int) trashResourceComponent.Current);
        App.SetScene(SceneType.GameOver, true);
    }
}