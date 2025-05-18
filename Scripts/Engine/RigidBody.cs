using System.Windows;
using RECOVER.Inner;

namespace RECOVER.Scripts.Engine;

public class RigidBody : Component
{
    public bool IsKinematic { get; set; }
    public bool UseGravity { get; set; }

    public override void Update(double deltaTime)
    {
        if (!IsKinematic)
        {
            if (UseGravity)
                GameObject.Transform.Velocity += new Vector(0, 9.81) * deltaTime;

            ColliderMap.ColliderIterationGlobal(GameObject, deltaTime);
            GameObject.Transform.Position += GameObject.Transform.Velocity * deltaTime;
        }
    }
}