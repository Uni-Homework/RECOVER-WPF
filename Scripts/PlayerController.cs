using System.Windows;
using System.Windows.Input;
using RECOVER.Scripts.Engine;

namespace RECOVER.Scripts;

public class PlayerController : Component
{
    public override void Update(double deltaTime)
    {
        Vector input = new Vector();
        if (Keyboard.IsKeyDown(Key.W)) input.Y -= 1;
        if (Keyboard.IsKeyDown(Key.S)) input.Y += 1;
        if (Keyboard.IsKeyDown(Key.A)) input.X -= 1;
        if (Keyboard.IsKeyDown(Key.D)) input.X += 1;

        GameObject.Transform.Velocity += input * 50 * deltaTime;
    }
}