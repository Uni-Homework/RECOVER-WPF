using System.Windows;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

public class ItemObject : GameObject
{
    public ItemObject(double x, double y, double wight, double height, ItemObjectReaction reaction)
    {
        Transform.Position = new Vector(x, y);
        AddComponent(new BoxCollider(wight, height));
        AddComponent(reaction);
    }
}