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
        GameObjectCanvas canvas = (GameObjectCanvas)d;
        canvas.ShowItems();
    }

    private void ShowItems()
    {
        _colliderRectangles.Clear();
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

    #region IsDebugSourceProperty

    public static readonly DependencyProperty IsDebugSourceProperty = DependencyProperty.Register(
        nameof(IsDebug),
        typeof(bool), typeof(GameObjectCanvas),
        new FrameworkPropertyMetadata(false, OnIsDebugChanged));

    private static void OnIsDebugChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        GameObjectCanvas canvas = (GameObjectCanvas)d;
        if ((bool)e.NewValue)
        {
            canvas._colliderRectangles.ForEach(r => canvas.Children.Add(r));
        }
        else
        {
            canvas._colliderRectangles.ForEach(r => canvas.Children.Remove(r));
        }
    }

    public bool IsDebug
    {
        get => (bool)GetValue(IsDebugSourceProperty);
        set => SetValue(IsDebugSourceProperty, value);
    }

    #endregion

    private List<Rectangle> _colliderRectangles;

    public GameObjectCanvas()
    {
        _colliderRectangles = new List<Rectangle>();
    }

    private void SetGameObject(GameObject go)
    {
        SetCamera(go);
        SetSprite(go);
        SetCollider(go);
    }

    private void SetCollider(GameObject go)
    {
        foreach (var collider in go.GetComponents<BoxCollider>())
        {
            Rectangle rect = new Rectangle();
            rect.Fill = Brushes.Transparent;
            
            rect.SetBinding(Rectangle.StrokeProperty, new Binding()
            {
                Source = collider,
                Path = new PropertyPath("IsTrigger"),
                Converter = ColorColliderConverter.Instance
            });

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

            rect.RenderTransform = new RotateTransform(0);

            rect.SetBinding(RenderTransformOriginProperty, new Binding()
            {
                Source = go,
                Path = new PropertyPath("Transform.Origin")
            });

            MultiBinding leftBinding = new MultiBinding()
            {
                Converter = OriginCorrectingConverter.Instance
            };

            leftBinding.Bindings.Add(new Binding("Transform.Position.X") { Source = go });
            leftBinding.Bindings.Add(new Binding("Transform.Origin.X") { Source = go });
            leftBinding.Bindings.Add(new Binding("Width") { Source = collider });

            rect.SetBinding(LeftProperty, leftBinding);

            MultiBinding topBinding = new MultiBinding()
            {
                Converter = OriginCorrectingConverter.Instance
            };
            topBinding.Bindings.Add(new Binding("Transform.Position.Y") { Source = go });
            topBinding.Bindings.Add(new Binding("Transform.Origin.Y") { Source = go });
            topBinding.Bindings.Add(new Binding("Height") { Source = collider });
            rect.SetBinding(TopProperty, topBinding);

            if (IsDebug)
            {
                Children.Add(rect);
            }
            _colliderRectangles.Add(rect);
        }
    }

    private void SetSprite(GameObject go)
    {
        SpriteComponent sprite = go.GetComponent<SpriteComponent>();
        if (sprite != null)
        {
            Rectangle rectangle = sprite.GetRectangle();

            rectangle.SetBinding(RenderTransformOriginProperty, new Binding()
            {
                Source = go,
                Path = new PropertyPath("Transform.Origin")
            });

            MultiBinding leftBinding = new MultiBinding()
            {
                Converter = OriginCorrectingConverter.Instance
            };

            leftBinding.Bindings.Add(new Binding("Transform.Position.X") { Source = go });
            leftBinding.Bindings.Add(new Binding("Transform.Origin.X") { Source = go });
            leftBinding.Bindings.Add(new Binding("Width") { Source = rectangle });

            rectangle.SetBinding(LeftProperty, leftBinding);

            MultiBinding topBinding = new MultiBinding()
            {
                Converter = OriginCorrectingConverter.Instance
            };
            topBinding.Bindings.Add(new Binding("Transform.Position.Y") { Source = go });
            topBinding.Bindings.Add(new Binding("Transform.Origin.Y") { Source = go });
            topBinding.Bindings.Add(new Binding("Height") { Source = rectangle });
            rectangle.SetBinding(TopProperty, topBinding);

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
        Collider collider = go.GetComponent<Collider>();
        if (camera != null && collider != null)
        {
            TransformGroup tgroup = new TransformGroup();

            TranslateTransform translateTransform = new TranslateTransform();
            BindingOperations.SetBinding(translateTransform, TranslateTransform.XProperty, new MultiBinding()
            {
                Converter = NegativeDoubleConvert.Instance,
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
                Converter = NegativeDoubleConvert.Instance,
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
                Converter = HalfConverter.Instance,
                Path = new PropertyPath("ActualWidth"),
                Source = Parent
            });
            BindingOperations.SetBinding(rotateTransform, RotateTransform.CenterYProperty, new Binding()
            {
                Converter = HalfConverter.Instance,
                Path = new PropertyPath("ActualHeight"),
                Source = Parent
            });

            BindingOperations.SetBinding(rotateTransform, RotateTransform.AngleProperty, new Binding()
            {
                Converter = NegateValueConverter.Instance,
                Path = new PropertyPath("Transform.Rotation"),
                Source = go
            });

            tgroup.Children.Add(translateTransform);
            tgroup.Children.Add(rotateTransform);

            RenderTransform = tgroup;
        }
    }
}