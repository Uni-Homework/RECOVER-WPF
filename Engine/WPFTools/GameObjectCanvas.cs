using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using RECOVER.Engine.Components;

namespace RECOVER.Engine.WPFTools;

public class GameObjectCanvas : Canvas
{
    #region ItemsSourceProperty

    public static readonly DependencyProperty ItemsSourceProperty = DependencyProperty.Register(
        nameof(ItemsSource),
        typeof(IEnumerable<GameObject>), typeof(GameObjectCanvas),
        new FrameworkPropertyMetadata(null, OnItemsSourceChanged));

    private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        GameObjectCanvas battleMapControl = (GameObjectCanvas)d;
        battleMapControl.ShowItems();
    }

    private void ShowItems()
    {
        foreach (var go in ItemsSource)
        {
            SpriteComponent component = go.GetComponent<SpriteComponent>();
            if (component != null)
            {
                Rectangle rectangle = component.GetRectangle();
                rectangle.SetBinding(LeftProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Position.X")
                });
                rectangle.SetBinding(TopProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Position.Y")
                });
                rectangle.SetBinding(RenderTransformOriginProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Origin")
                });
                rectangle.RenderTransform = new RotateTransform(0);
                BindingOperations.SetBinding(rectangle.RenderTransform, RotateTransform.AngleProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Rotation")
                });

                Children.Add(rectangle);
            }

#if DEBUG
            var collider = go.GetComponent<BoxCollider>();
            if (collider != null)
            {
                Rectangle rect = new Rectangle();
                rect.Stroke = Brushes.Red;
                rect.Fill = Brushes.Transparent;

                rect.SetBinding(WidthProperty, new Binding()
                {
                    Source = collider,
                    Path = new PropertyPath("Bounds.Width")
                });
                rect.SetBinding(HeightProperty, new Binding()
                {
                    Source = collider,
                    Path = new PropertyPath("Bounds.Height")
                });
                rect.SetBinding(LeftProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Position.X")
                });
                rect.SetBinding(TopProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Position.Y")
                });
                rect.RenderTransform = new RotateTransform(0);
                BindingOperations.SetBinding(rect.RenderTransform, RotateTransform.AngleProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Rotation")
                });
                rect.SetBinding(RenderTransformOriginProperty, new Binding()
                {
                    Source = go,
                    Path = new PropertyPath("Transform.Origin")
                });


                Children.Add(rect);
            }
#endif
        }
    }

    public IEnumerable<GameObject> ItemsSource
    {
        get => (IEnumerable<GameObject>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    #endregion
}