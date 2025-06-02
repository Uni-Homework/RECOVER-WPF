using System.Windows;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player;

public class PlayerController : Component
{
    private const float RotationSpeed = 180f; // degrees per second
    private const float MoveSpeed = 0.01f;
    private bool _rotateLeft;
    private bool _rotateRight;
    private Vector _input;

    public Vector Input
    {
        get => _input;
        set => Set(ref _input, value);
    }

    public bool RotateLeft
    {
        get => _rotateLeft;
        set { Set(ref _rotateLeft, value); }
    }

    public bool RotateRight
    {
        get => _rotateRight;
        set { Set(ref _rotateRight, value); }
    }

    public override void Update(double deltaTime)
    {
        if (_rotateLeft)
            GameObject.Transform.Rotation -= (float)(RotationSpeed * deltaTime);
        if (_rotateRight)
            GameObject.Transform.Rotation += (float)(RotationSpeed * deltaTime);

        double angle = GameObject.Transform.Rotation * (float)Math.PI / 180f;
        Vector rotatedInput = new Vector(
            Input.X * (float)Math.Cos(angle) - Input.Y * (float)Math.Sin(angle),
            Input.X * (float)Math.Sin(angle) + Input.Y * (float)Math.Cos(angle)
        );

        GameObject.Transform.Velocity += rotatedInput * MoveSpeed;
    }
}