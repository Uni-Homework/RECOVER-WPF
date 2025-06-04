using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Assets.Prefabs.Player;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Terminal;

public class TerminalPrefab : ItemPrefab
{
    public GameObject Player { get; private set; }
    
    public TerminalPrefab(double x, double y, PlayerPrefab player) :
        base(x, y, 30, 50, Key.T, null, "Открыть терминал")
    {
        Player = player;
        Transform.Origin = new Point(0.5, 1);
        TerminalComponent component = new TerminalComponent(player);
        Action = component.OpenTerminal;
        AddComponent(component);
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["ItemTerminalTile"]));
    }
}