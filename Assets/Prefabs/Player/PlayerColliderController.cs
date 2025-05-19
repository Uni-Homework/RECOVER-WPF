using System.Windows;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerColliderController : ColliderReaction
{
    public override void OnCollisionEnter()
    {
        GameObject.Transform.Velocity = new Vector();
    }

    public override void OnCollisionStay()
    {
        GameObject.Transform.Velocity = new Vector();
    }
}