using System.Windows;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

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