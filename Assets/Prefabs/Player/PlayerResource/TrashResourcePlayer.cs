using System.Windows.Media;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public class TrashResourcePlayer : Component, IResourcePlayer
{
    private double _current;
    private double _max = 50;

    public double Max
    {
        get => _max;
        private set => Set(ref _max, value);
    }

    public double Min { get; } = 0;
    public string Name { get; } = "Мусор";

    public double Current
    {
        get => _current;
        set
        {
            Set(ref _current, value);
            
            // In fact, it compares the current value with the max value.
            if (Math.Abs(_current - Max) < 0.0001)
            {
                var player = (PlayerPrefab)GameObject;
                player.Win();
            }
            if (_current > _max)
            {
                Max = Max + Max / 2;
            }
        }
    }

    public ImageSource ImageSource { get; }
}