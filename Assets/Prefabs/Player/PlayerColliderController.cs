using System.Windows;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerColliderController : ColliderReaction
{
    public override void OnCollisionEnter(GameObject gameObject)
    {
        GameObject.Transform.Velocity = new Vector();
    }

    public override void OnCollisionStay(GameObject collider)
    {
        GameObject.Transform.Velocity = new Vector();
    }
}