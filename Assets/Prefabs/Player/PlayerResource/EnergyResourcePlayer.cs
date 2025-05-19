using System.Windows.Media;

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
}