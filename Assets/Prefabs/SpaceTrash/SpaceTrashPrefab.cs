using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.SpaceTrash;

public class SpaceTrashPrefab : ItemPrefab
{
    public SpaceTrashPrefab (double x, double y) :
        base(x, y, 50, 50, Key.F, null, "Собрать мусор")
    {
        AddComponent(new SpriteComponent((ImageSource)App.Current.Resources["Debris"]));
        Action = CollectTrash;
        
    }

    void CollectTrash()
    {
        foreach(var c in GetComponents<Collider>()) c.IsTrigger = true;
        GetComponent<SpriteComponent>().MakeInvisible();
        Transform.Position = new Vector(-9999, -9999);

        // todo increment score
    }
}