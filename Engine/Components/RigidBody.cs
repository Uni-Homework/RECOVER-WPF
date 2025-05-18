using System.Windows;

namespace RECOVER.Engine.Components;

public class RigidBody : Component
{
    public bool IsKinematic { get; set; }
    public bool UseGravity { get; set; }

    public override void Update(double deltaTime)
    {
        base.Update(deltaTime);
        if (!IsKinematic)
        {
            if (UseGravity)
                GameObject.Transform.Velocity += new Vector(0, 9.81) * deltaTime;

            GameObject.Transform.Position += GameObject.Transform.Velocity * deltaTime;
        }
    }
}