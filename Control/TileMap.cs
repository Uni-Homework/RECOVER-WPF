using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
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
        GridLength gl = new GridLength(tileMap.WidthOfCell);

        Add<ColumnDefinition>(cells.Max(c => c.X), tileMap.ColumnDefinitions, cs => cs.Width = gl);
        Add<RowDefinition>(cells.Max(c => c.Y), tileMap.RowDefinitions, cs => cs.Height = gl);

        foreach (var c in cells)
        {
            Image image = new Image();
            image.Source = (ImageSource)App.Current.Resources[c.Type.ToString()];
            image.SetBinding(ColumnProperty, new Binding
            {
                Source = c,
                Path = new PropertyPath(nameof(c.X))
            });
            image.SetBinding(RowProperty, new Binding
            {
                Source = c,
                Path = new PropertyPath(nameof(c.Y))
            });
            tileMap.Children.Add(image);
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

    #region WidthOfCellDependencyProperty

    public static readonly DependencyProperty WidthOfCellDependencyProperty = DependencyProperty.Register(
        nameof(WidthOfCell),
        typeof(double), typeof(TileMap),
        new FrameworkPropertyMetadata(64.0, OnWidthOfCellChanged));

    static void OnWidthOfCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        TileMap tileMap = (TileMap)d;
        GridLength gl = new GridLength(tileMap.WidthOfCell);

        foreach (var column in tileMap.ColumnDefinitions)
        {
            column.Width = gl;
        }

        foreach (var column in tileMap.RowDefinitions)
        {
            column.Height = gl;
        }
    }

    public double WidthOfCell
    {
        get => (double)GetValue(WidthOfCellDependencyProperty);
        set => SetValue(WidthOfCellDependencyProperty, value);
    }

    #endregion

    public TileMap()
    {
        ShowGridLines = false;
    }
}