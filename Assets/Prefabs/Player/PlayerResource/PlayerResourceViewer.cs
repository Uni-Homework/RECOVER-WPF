using System.Windows;
using RECOVER.Assets.Scenes.ResourceViewer;
using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Player.PlayerResource;

public class PlayerResourceViewer : Component
{
    private List<IResourcePlayer> _resourcePlayers;
    private bool _isShow;

    public override void Start()
    {
        _resourcePlayers = GameObject.Components.OfType<IResourcePlayer>().ToList();
        base.Start();
    }

    public void OpenResourceViewer()
    {
        if (_isShow)
        {
            return;
        }

        _isShow = true;
        ResourceViewer viewer = new ResourceViewer(_resourcePlayers);
        viewer.Closed += ViewerOnClosed;
        viewer.Show();
    }

    private void ViewerOnClosed(object sender, EventArgs e)
    {
        (sender as Window).Closed -= ViewerOnClosed;
        _isShow = false;
    }
}