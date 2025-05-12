using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace RECOVER.Scripts.Engine;

public class SpriteRender : Component
{
    public void Render(Canvas gameCanvas)
    {
        var ellipse = new Ellipse
        {
            Width = 20,
            Height = 20,
            Fill = Brushes.White
        };
        Canvas.SetLeft(ellipse, this.GameObject.Transform.Position.X);
        Canvas.SetTop(ellipse, this.GameObject.Transform.Position.Y);
        gameCanvas.Children.Add(ellipse);
    }
}