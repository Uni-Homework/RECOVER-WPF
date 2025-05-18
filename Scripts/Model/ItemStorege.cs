using System.Collections.ObjectModel;
using System.Windows.Input;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts.Model;

public class ItemActivator : ColliderReaction
{
    private ObservableCollection<ItemObject> _surroundingItems;

    public ItemActivator()
    {
        _surroundingItems = new ObservableCollection<ItemObject>();
    }

    public ObservableCollection<ItemObject> SurroundingItems
    {
        get => _surroundingItems;
        set => Set(ref _surroundingItems, value);
    }

    public override void OnTriggerEnter(GameObject gameObject)
    {
        if (gameObject is ItemObject itemObject)
        {
            this.GameObject.GetComponent<ItemActivator>().Add(itemObject);
        }
    }

    public override void OnTriggerExit(GameObject gameObject)
    {
        if (gameObject is ItemObject itemObject)
        {
            this.GameObject.GetComponent<ItemActivator>().Remove(itemObject);
        }
    }
    
    public void Add(ItemObject itemObject)
    {
        _surroundingItems.Add(itemObject);
    }

    public void Remove(ItemObject itemObject)
    {
        _surroundingItems.Remove(itemObject);
    }

    public override void Update(double deltaTime)
    {
        foreach (var surroundingItem in _surroundingItems)
        {
            if (Keyboard.GetKeyStates(surroundingItem.ActivationKey) == KeyStates.Down)
            {
                surroundingItem.Action.Invoke();
            }
        }
    }
}