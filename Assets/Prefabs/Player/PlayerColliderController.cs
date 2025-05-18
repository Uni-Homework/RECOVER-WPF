using System.Windows;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

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

    public override void OnCollisionExit()
    {
    }

    public override void OnTriggerEnter()
    {
    }

    public override void OnTriggerStay()
    {
    }

    public override void OnTriggerExit()
    {
    }
}