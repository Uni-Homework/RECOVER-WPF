using System.Windows;
using System.Windows.Input;
using RECOVER.Assets.Prefabs.Terminal;

namespace RECOVER.Assets.Scenes.Terminal;

public partial class TerminalView : Window
{
    private TerminalComponent dataContext;

    public TerminalView(TerminalComponent dataContext)
    {
        DataContext = this.dataContext = dataContext;
        InitializeComponent();
        CommandLine.Focus();
    }

    private void ClickEnter(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            dataContext.DoCommand();
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Enter:
                HistoryScroll.ScrollToEnd();
                e.Handled = true;
                break;
            case Key.Tab:
                Close();
                break;
        }

        base.OnKeyDown(e);
    }
}