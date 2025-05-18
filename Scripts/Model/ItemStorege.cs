using System.Collections.ObjectModel;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts.Model;

public class ItemActivator : Component
{
    private ObservableCollection<ItemObject> _surroundingItems;

    public ItemActivator()
    {
        _surroundingItems = new ObservableCollection<ItemObject>();
    }

    public void Add(ItemObject itemObject)
    {
        _surroundingItems.Add(itemObject);
    }

    public void Remove(ItemObject itemObject)
    {
        _surroundingItems.Remove(itemObject);
    }

    public ObservableCollection<ItemObject> SurroundingItems
    {
        get => _surroundingItems;
        set => Set(ref _surroundingItems, value);
    }
}