using System.Windows;
using System.Windows.Input;

namespace RECOVER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool _isNormalScreen;

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.F11)
            {
                _isNormalScreen = !_isNormalScreen;
                WindowStyle = _isNormalScreen ? WindowStyle.SingleBorderWindow : WindowStyle.None;
                WindowState = _isNormalScreen ? WindowState.Normal : WindowState.Maximized;
            }

            base.OnKeyDown(e);
        }
    }
}