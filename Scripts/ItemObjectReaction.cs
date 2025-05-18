using RECOVER.Scripts.Engine;
using RECOVER.Scripts.Model;

namespace RECOVER.Scripts;

public class ItemObjectReaction : ColliderReaction
{
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
}