using System.Windows.Media;
using RECOVER.Engine;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public class EnergyResourcePlayer : CommonResourcePlayer
{
    public EnergyResourcePlayer() : base(50, 20, 0, 10)
    {
    }

    public override double Max { get; } = 100;
    public override double Min { get; } = 0;
    public override string Name { get; } = "Энергия";
    public override ImageSource ImageSource { get; } = null;

    public override double Current
    {
        get => base.Current;
        set
        {
            if (Current <= Min)
            {
                var player = (PlayerPrefab)GameObject;
                player.Die();
            }
            base.Current = value;
        }
    }
}