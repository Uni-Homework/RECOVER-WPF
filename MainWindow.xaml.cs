using System.Windows;
using System.Windows.Media;

namespace RECOVER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DateTime lastFrameTime;

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            lastFrameTime = DateTime.Now;
            App.CurrentScene.Start();
            CompositionTarget.Rendering += GameLoop;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            DateTime currentFrameTime = DateTime.Now;
            double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

            App.CurrentScene.Update(deltaTime);
            App.CurrentScene.Render(GameCanvas);

            lastFrameTime = currentFrameTime;
        }
    }
}