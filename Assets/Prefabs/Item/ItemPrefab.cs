using System.Windows;
using System.Windows.Input;
using RECOVER.Engine;
using RECOVER.Engine.Components;
using Vector = System.Windows.Vector;

namespace RECOVER.Assets.Prefabs.Item;

public class ItemPrefab : GameObject
{
    private Key _activationKey;
    private string _description;
    private Action _action;

    public ItemPrefab(double x, double y, double wight, double height, Key activationKey, Action action,
        string description)
    {
        Transform.Origin = new Point(0.5, 0.5);
        ActivationKey = activationKey;
        Action = action;
        Description = description;
        Transform.Position = new Vector(x, y);
        AddComponent(new BoxCollider(wight, height));
        AddComponent(new BoxCollider(wight + 20, height + 20)
        {
            IsTrigger = true
        });
    }

    public Key ActivationKey
    {
        get => _activationKey;
        set => Set(ref _activationKey, value);
    }

    public Action Action
    {
        get => _action;
        set => Set(ref _action, value);
    }

    public string Description
    {
        get => _description;
        set { Set(ref _description, value); }
    }
}