using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using static RECOVER.Scripts.Engine;




namespace RECOVER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new();
        List<GameObject> gameObjects = new();
        public MainWindow()
        {
            InitializeComponent();
            Start();
        }
        void Start()
        {
            var player = new GameObject();
            player.Transform.Position = new Vector(200, 200);
            player.AddComponent(new RigidBody { IsKinematic = false });
            player.AddComponent(new PlayerController());
            gameObjects.Add(player);

            timer.Interval = TimeSpan.FromMilliseconds(16);
            timer.Tick += GameLoop;
            timer.Start();
        }

        void GameLoop(object sender, EventArgs e)
        {
            double dt = 0.016;

            foreach (var go in gameObjects)
                go.Update(dt);

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