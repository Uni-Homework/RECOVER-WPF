using System.Windows.Media;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public class WaterResourcePlayer : CommonResourcePlayer
{
    public WaterResourcePlayer() : base(7, 40, 0, 3)
    {
    }

    public override double Max { get; } = 7;
    public override double Min { get; } = 0;
    public override string Name { get; } = "Вода";
    public override ImageSource ImageSource { get; } = null;
    
    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
        if (Current <= 0)
        {
            var player = (PlayerPrefab)GameObject;
            player.Die();
        }
    }
}