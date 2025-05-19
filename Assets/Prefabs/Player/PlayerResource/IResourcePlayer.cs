using System.Windows.Media;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public interface IResourcePlayer
{
    public double Max { get; }
    public double Min { get; }
    public string Name { get; }
    public double Current { get; }
    public ImageSource ImageSource { get; }
}