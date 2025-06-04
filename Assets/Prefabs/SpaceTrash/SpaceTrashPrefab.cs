using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.SpaceTrash;

public class SpaceTrashPrefab : ItemPrefab
{
    private TrashPlayerResourceFillerComponent _fillerComponent;

    public SpaceTrashPrefab(double x, double y) :
        base(x, y, 50, 50, Key.F, null, "Собрать мусор")
    {
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["Debris"]));
        AddComponent(_fillerComponent = new TrashPlayerResourceFillerComponent());
        Action = CollectTrash;
    }

    void CollectTrash()
    {
        foreach (var c in GetComponents<Collider>()) c.IsTrigger = true;
        GetComponent<SpriteComponent>().MakeInvisible();
        Transform.Position = new Vector(-9999, -9999);
        _fillerComponent.Replenish();
    }

    public bool Intersects(Point p)
    {
        var width = GetComponent<BoxCollider>().Width;
        var height = GetComponent<BoxCollider>().Height;
        bool c1, c2;
        c1 = c2 = false;
        if (Transform.Position.X <= p.X && p.X <=Transform.Position.X + width) c1 = true;
        if (Transform.Position.Y <= p.Y && p.Y <=Transform.Position.Y + height) c2 = true;
        return c1 && c2;
    }

    public bool Intersects(SpaceTrashPrefab p)
    {
        foreach (var point in p.GetComponent<BoxCollider>().GetBoundsPoints())
        {
            if (Intersects(point)) return true;
        }

        return false;
    }
}