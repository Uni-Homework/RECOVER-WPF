using System.Collections.ObjectModel;
using RECOVER.Assets.Prefabs.Item;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class DetectedItemsComponent : ColliderReaction
{
    private ObservableCollection<ItemPrefab> _surroundingItems;

    public DetectedItemsComponent()
    {
        _surroundingItems = new ObservableCollection<ItemPrefab>();
    }

    public ObservableCollection<ItemPrefab> SurroundingItems
    {
        get => _surroundingItems;
        private set => Set(ref _surroundingItems, value);
    }

    public override void OnTriggerEnter(GameObject gameObject)
    {
        if (gameObject is ItemPrefab itemObject)
        {
            _surroundingItems.Add(itemObject);
        }
    }

    public override void OnTriggerExit(GameObject gameObject)
    {
        if (gameObject is ItemPrefab itemObject)
        {
            _surroundingItems.Remove(itemObject);
        }
    }
}