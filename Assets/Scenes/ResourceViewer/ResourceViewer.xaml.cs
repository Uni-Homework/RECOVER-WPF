using System.Windows;
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

    public IEnumerable<IResourcePlayer> ResourcePlayers => _resourcePlayers;
}