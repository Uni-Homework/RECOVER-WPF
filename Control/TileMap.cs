using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using RECOVER.Scripts.Model;

namespace RECOVER.Control;

public class TileMap : Grid
{
    #region ItemSourceDependencyProperty

    public static readonly DependencyProperty ItemSourceDependencyProperty = DependencyProperty.Register(
        nameof(ItemSource),
        typeof(IList<Cell>), typeof(TileMap),
        new FrameworkPropertyMetadata(null, OnItemSourceChanged));

    static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TileMap tileMap = (TileMap)d;
        IList<Cell> cells = (IList<Cell>)e.NewValue;

        tileMap.Children.Clear();
        GridLength gl = new GridLength(64);

        Add<ColumnDefinition>(cells.Max(c => c.X), tileMap.ColumnDefinitions, cs => cs.Width = gl);
        Add<RowDefinition>(cells.Max(c => c.Y), tileMap.RowDefinitions, cs => cs.Height = gl);
        
        foreach (var c in cells)
        {
            Button text = new Button();
            text.SetBinding(ColumnProperty, new Binding
            {
                Source = c, // элемент-источник
                Path = new PropertyPath(nameof(c.X))
            });
            text.SetBinding(RowProperty, new Binding
            {
                Source = c, // элемент-источник
                Path = new PropertyPath(nameof(c.Y))
            });
            text.SetBinding(ContentControl.ContentProperty, new Binding
            {
                Source = c, // элемент-источник
                Path = new PropertyPath(nameof(c.Type))
            });
            tileMap.Children.Add(text);
        }
    }

    private static void Add<T>(int max, IList definitions, Action<T> action)
    {
        while (definitions.Count < max)
        {
            T inst = (T)Activator.CreateInstance(typeof(T));
            definitions.Add(inst);
            action.Invoke(inst);
        }

        while (definitions.Count > max)
        {
            definitions.RemoveAt(definitions.Count - 1);
        }
    }

    public IList<Cell> ItemSource
    {
        get => (IList<Cell>)GetValue(ItemSourceDependencyProperty);
        set => SetValue(ItemSourceDependencyProperty, value);
    }

    #endregion
}