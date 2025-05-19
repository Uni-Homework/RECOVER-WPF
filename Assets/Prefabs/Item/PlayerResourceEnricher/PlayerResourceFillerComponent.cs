using RECOVER.Assets.Prefabs.Player.PlayerResource;
using RECOVER.Engine;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;

public class PlayerResourceFillerComponent<T> : ColliderReaction where T : IResourcePlayer
{
    private List<T> _resourceRecipients;

    public PlayerResourceFillerComponent()
    {
        _resourceRecipients = new List<T>();
    }

    public override void OnTriggerEnter(GameObject other)
    {
        _resourceRecipients.AddRange(other.Components.OfType<T>());
    }

    public override void OnTriggerExit(GameObject other)
    {
        foreach (var resourcePlayer in other.Components.OfType<T>())
        {
            _resourceRecipients.Remove(resourcePlayer);
        }
    }

    public void Replenish()
    {
        _resourceRecipients.ForEach(rr => rr.Current = rr.Max);
    }
}