using System.Windows.Media;
using RECOVER.Assets.Prefabs.Player.PlayerResource;

namespace RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;

public class EnergyPlayerResourceFiller : PlayerResourceFiller<EnergyResourcePlayer>
{
    public EnergyPlayerResourceFiller(double x, double y) : 
        base(x, y, 64, 64, "Подзарядить", (ImageSource)App.Current.Resources["EnetgyPlayerResourceEnricherTile"])
    {
        
    }
}