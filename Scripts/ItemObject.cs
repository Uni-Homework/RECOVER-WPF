using System.Windows;
using System.Windows.Input;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

public class ItemObject : GameObject
{
    private Key _activationKey;
    private string description;
    private Action _action;

    public ItemObject(double x, double y, double wight, double height, Key activationKey, Action action,
        string description)
    {
        ActivationKey = activationKey;
        Action = action;
        Description = description;
        Transform.Position = new Vector(x, y);
        AddComponent(new BoxCollider(wight, height));
        AddComponent(new BoxCollider(wight + 10, height + 10)
        {
            Origin = new Vector(-0.1, -0.1),
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
        get => description;
        set { Set(ref description, value); }
    }
}