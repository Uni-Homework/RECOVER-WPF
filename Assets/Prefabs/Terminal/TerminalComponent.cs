using RECOVER.Engine.Components;

namespace RECOVER.Assets.Prefabs.Terminal;

public class TerminalComponent : Component
{
    private bool _isShow;

    public bool IsShow
    {
        get => _isShow;
        private set => Set(ref _isShow, value);
    }

    public void OpenTerminal()
    {
        IsShow = true;
    }
}