using RECOVER.Assets.Prefabs.Player.PlayerResource;

namespace RECOVER.Assets.Prefabs.Item.PlayerResourceEnricher;

public class TrashPlayerResourceFillerComponent : PlayerResourceFillerComponent<TrashResourcePlayer>
{
    public override void Replenish()
    {
        ResourceRecipients.ForEach(rr => rr.Current = rr.Current + 1);
    }
}