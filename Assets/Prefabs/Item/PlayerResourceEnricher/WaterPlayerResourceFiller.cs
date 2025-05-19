using System.Windows.Media;
using RECOVER.Assets.Prefabs.Player.PlayerResource;

namespace RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;

public class WaterPlayerResourceFiller : PlayerResourceFiller<WaterResourcePlayer>
{
    public WaterPlayerResourceFiller(double x, double y) : 
        base(x, y, 23, 64, "Выпить", (ImageSource)App.Current.Resources["CoolerTile"])
    {
    }
}