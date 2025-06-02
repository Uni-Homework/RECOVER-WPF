using System.Windows.Media;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public abstract class CommonResourcePlayer : Component, IResourcePlayer
{
    private double _current = 50;
    private readonly double MAX_STEP;
    private readonly double MIN_STEP;
    private readonly double DELTA_STEP;
    private double step = 0;

    public CommonResourcePlayer(double current, double maxStep, double minStep, double deltaStep)
    {
        _current = current;
        MAX_STEP = maxStep;
        MIN_STEP = minStep;
        DELTA_STEP = deltaStep;
    }

    public abstract double Max { get; }
    public abstract double Min { get; }
    public abstract string Name { get; }

    public virtual double Current
    {
        get => _current;
        set => Set(ref _current, value);
    }

    public abstract ImageSource ImageSource { get; }

    public override void Update(double deltaTime)
    {
        step += deltaTime;

        if (MAX_STEP < step)
        {
            step = MIN_STEP;
            Current -= DELTA_STEP;
        }
    }
}