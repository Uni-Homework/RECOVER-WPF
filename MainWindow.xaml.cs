// TODO later make a Scene class, learn pipelines
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static RECOVER.Scripts.Engine;

namespace RECOVER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GameObject> gameObjects = new();
        private DateTime lastFrameTime;

        public MainWindow()
        {
            InitializeComponent();
            Start();
        }

        private void Start()
        {
            var player = new GameObject();
            player.Transform.Position = new Vector(200, 200);
            player.AddComponent(new RigidBody { IsKinematic = false });
            player.AddComponent(new PlayerController());
            gameObjects.Add(player);

            lastFrameTime = DateTime.Now;
            CompositionTarget.Rendering += GameLoop;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            DateTime currentFrameTime = DateTime.Now;
            double deltaTime = (currentFrameTime - lastFrameTime).TotalSeconds;

            UpdateGameObjects(deltaTime);
            Render();

            lastFrameTime = currentFrameTime;
        }

        private void UpdateGameObjects(double deltaTime)
        {
            foreach (var go in gameObjects)
                go.Update(deltaTime);
        }

        private void Render()
        {
            GameCanvas.Children.Clear();
            foreach (var go in gameObjects)
            {
                var ellipse = new Ellipse
                {
                    Width = 20,
                    Height = 20,
                    Fill = Brushes.White
                };
                Canvas.SetLeft(ellipse, go.Transform.Position.X);
                Canvas.SetTop(ellipse, go.Transform.Position.Y);
                GameCanvas.Children.Add(ellipse);
            }
        }
    }
}