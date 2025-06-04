using System.Windows;
using System.Windows.Input;
using RECOVER.Assets.Prefabs.Terminal;

namespace RECOVER.Assets.Scenes.Terminal;

public partial class TerminalView : Window
{
    private TerminalComponent dataContext;
    private const double ScrollAmount = 20;

    public TerminalView(TerminalComponent dataContext)
    {
        DataContext = this.dataContext = dataContext;
        InitializeComponent();
        CommandLine.Focus();
    }

    private void ClickEnter(object sender, KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Enter:
                dataContext.DoCommand();
                HistoryScroll.ScrollToEnd();
                e.Handled = true;
                break;
            case Key.Up:
                HistoryScroll.ScrollToVerticalOffset(HistoryScroll.VerticalOffset - ScrollAmount);
                e.Handled = true;
                break;
            case Key.Down:
                HistoryScroll.ScrollToVerticalOffset(HistoryScroll.VerticalOffset + ScrollAmount);
                e.Handled = true;
                break;
        }
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        if (e.Key == Key.Tab) Close();
        base.OnKeyDown(e);
    }
}