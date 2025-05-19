using System.Windows.Media;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public class Energy : Component, IResourcePlayer
{
    private double _current = 50;
    private const double MAX_STEP = 10;
    private const double MIN_STEP = 0;
    private const double DELTA_STEP = 10;

    private double step = 0;

    public double Max { get; } = 100;
    public double Min { get; } = 0;
    public string Name { get; } = "Энергия";

    public double Current
    {
        get => _current;
        set => Set(ref _current, value);
    }

    public ImageSource ImageSource { get; } = null;

    public override void Update(double deltaTime)
    {
        step += deltaTime;

        if (MAX_STEP < step)
        {
            step = MIN_STEP;
            _current -= DELTA_STEP;
        }
    }
}