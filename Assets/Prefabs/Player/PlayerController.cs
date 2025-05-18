using System.Windows;
using System.Windows.Input;
using RECOVER.Engine;

namespace RECOVER.Scripts;

public class PlayerController : Component
{
    private float rotationSpeed = 180f; // degrees per second
    private float moveSpeed = 1f;
    private bool rotateLeft, rotateRight;
    
    public override void Update(double deltaTime)
    {
        // Get input
        Vector input = new Vector();
        if (Keyboard.IsKeyDown(Key.W)) input.Y -= 1;
        if (Keyboard.IsKeyDown(Key.S)) input.Y += 1;
        if (Keyboard.IsKeyDown(Key.A)) input.X -= 1;
        if (Keyboard.IsKeyDown(Key.D)) input.X += 1;
        
        if (Keyboard.IsKeyDown(Key.E)) rotateRight = true;
        if (Keyboard.IsKeyDown(Key.Q)) rotateLeft = true;
        if (Keyboard.IsKeyUp(Key.E)) rotateRight = false;
        if (Keyboard.IsKeyUp(Key.Q)) rotateLeft = false;
        
        // Apply rotation
        if (rotateLeft)
            GameObject.Transform.Rotation -= (float)(rotationSpeed * deltaTime);
        if (rotateRight)
            GameObject.Transform.Rotation += (float)(rotationSpeed * deltaTime);

        // Apply movement relative to rotation
        double angle = GameObject.Transform.Rotation * (float)Math.PI / 180f;
        Vector rotatedInput = new Vector(
            input.X * (float)Math.Cos(angle) - input.Y * (float)Math.Sin(angle),
            input.X * (float)Math.Sin(angle) + input.Y * (float)Math.Cos(angle)
        );
        
        GameObject.Transform.Velocity += rotatedInput * moveSpeed;
    }
}