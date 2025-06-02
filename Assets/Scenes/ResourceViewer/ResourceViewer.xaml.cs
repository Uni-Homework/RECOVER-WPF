using System.Windows;
using System.Windows.Input;
using RECOVER.Assets.Prefabs.Player.PlayerResource;

namespace RECOVER.Assets.Scenes.ResourceViewer;

public partial class ResourceViewer : Window
{
    private IEnumerable<IResourcePlayer> _resourcePlayers;

    public ResourceViewer(IEnumerable<IResourcePlayer> resources)
    {
        _resourcePlayers = resources;
        InitializeComponent();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.Tab)
        {
            Close();
        }
    }

    public IEnumerable<IResourcePlayer> ResourcePlayers => _resourcePlayers;
}