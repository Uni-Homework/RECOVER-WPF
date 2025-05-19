using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Terminal;

public class TerminalPrefab : ItemPrefab
{
    public TerminalPrefab(double x, double y) :
        base(x, y, 30, 50, Key.T, null, "Открыть терминал")
    {
        Transform.Origin = new Point(0.5, 1);
        TerminalComponent component = new TerminalComponent();
        Action = component.OpenTerminal;
        AddComponent(component);
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["ItemTerminalTile"]));
    }
}