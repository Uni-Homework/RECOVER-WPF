using System.Windows.Input;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Player.PlayerResource;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;

public class PlayerResourceFiller<T> : ItemPrefab where T : IResourcePlayer
{
    public PlayerResourceFiller(double x, double y, double wight, double height, string description, ImageSource imageSource) : base(x, y,
        wight, height, Key.R, null, description)
    {
        PlayerResourceFillerComponent<T> fillerComponent = new PlayerResourceFillerComponent<T>();
        Action = fillerComponent.Replenish;
        AddComponent(fillerComponent);
        AddComponent(new SpriteComponent(imageSource));
    }
}