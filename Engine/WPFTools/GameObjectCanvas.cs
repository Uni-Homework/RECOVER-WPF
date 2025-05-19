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
            SetGameObject(go);
        }
    }

    public IEnumerable<GameObject> ItemsSource
    {
        get => (IEnumerable<GameObject>)GetValue(ItemsSourceProperty);
        set => SetValue(ItemsSourceProperty, value);
    }

    #endregion

    private void SetGameObject(GameObject go)
    {
        SetCamera(go);
        SetSprite(go);
#if DEBUG
        SetCollider(go);
#endif
    }

    private void SetCollider(GameObject go)
    {
        var collider = go.GetComponent<BoxCollider>();
        if (collider != null)
        {
            Rectangle rect = new Rectangle();
            rect.Stroke = Brushes.Red;
            rect.Fill = Brushes.Transparent;

            rect.SetBinding(WidthProperty, new Binding()
            {
                Source = collider,
                Path = new PropertyPath("Width")
            });
            rect.SetBinding(HeightProperty, new Binding()
            {
                Source = collider,
                Path = new PropertyPath("Height")
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
    }

    private void SetSprite(GameObject go)
    {
        SpriteComponent sprite = go.GetComponent<SpriteComponent>();
        if (sprite != null)
        {
            Rectangle rectangle = sprite.GetRectangle();
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
    }

    private void SetCamera(GameObject go)
    {
        Camera camera = go.GetComponent<Camera>();
        if (camera != null)
        {
            TransformGroup tgroup = new TransformGroup();

            TranslateTransform translateTransform = new TranslateTransform();
            BindingOperations.SetBinding(translateTransform, TranslateTransform.XProperty, new MultiBinding()
            {
                Converter = new NegativeDoubleConvert(),
                Bindings =
                {
                    new Binding()
                    {
                        Path = new PropertyPath("Transform.Position.X"),
                        Source = go
                    },
                    new Binding()
                    {
                        Path = new PropertyPath("ActualWidth"),
                        Source = Parent
                    }
                }
            });
            BindingOperations.SetBinding(translateTransform, TranslateTransform.YProperty, new MultiBinding()
            {
                Converter = new NegativeDoubleConvert(),
                Bindings =
                {
                    new Binding
                    {
                        Path = new PropertyPath("Transform.Position.Y"),
                        Source = go
                    },
                    new Binding()
                    {
                        Path = new PropertyPath("ActualHeight"),
                        Source = Parent
                    }
                }
            });

            RotateTransform rotateTransform = new RotateTransform(0);
            BindingOperations.SetBinding(rotateTransform, RotateTransform.CenterXProperty, new Binding()
            {
                Converter = new HalfValueConverter(),
                Path = new PropertyPath("ActualWidth"),
                Source = Parent
            });
            BindingOperations.SetBinding(rotateTransform, RotateTransform.CenterYProperty, new Binding()
            {
                Converter = new HalfValueConverter(),
                Path = new PropertyPath("ActualHeight"),
                Source = Parent
            });
            BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding()
            {
                Converter = new NegateValueConverter(),
                Path = new PropertyPath("Transform.Rotation"),
                Source = go
            });

            tgroup.Children.Add(translateTransform);
            tgroup.Children.Add(rotateTransform);

            RenderTransform = tgroup;
        }
    }
}