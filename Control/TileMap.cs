using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using RECOVER.Inner;
using RECOVER.Scripts;

namespace RECOVER.Control;

public class TileMap : Canvas
{
    public static readonly DependencyProperty ItemSourceProperty =
        DependencyProperty.Register("ItemSource", typeof(IEnumerable), typeof(TileMap),
            new PropertyMetadata(null, OnItemSourceChanged));

    public IEnumerable ItemSource
    {
        get { return (IEnumerable)GetValue(ItemSourceProperty); }
        set { SetValue(ItemSourceProperty, value); }
    }

    public static readonly DependencyProperty WidthOfCellProperty =
        DependencyProperty.Register("WidthOfCell", typeof(double), typeof(TileMap),
            new PropertyMetadata(64.0, OnWidthOfCellChanged));

    public double WidthOfCell
    {
        get { return (double)GetValue(WidthOfCellProperty); }
        set { SetValue(WidthOfCellProperty, value); }
    }

    public static readonly DependencyProperty HeightOfCellProperty =
        DependencyProperty.Register("HeightOfCell", typeof(double), typeof(TileMap),
            new PropertyMetadata(64.0, OnHeightOfCellChanged));

    public double HeightOfCell
    {
        get { return (double)GetValue(HeightOfCellProperty); }
        set { SetValue(HeightOfCellProperty, value); }
    }

    private static void OnItemSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var tileMap = (TileMap)d;
        tileMap.Children.Clear();
        tileMap.DrawTiles();
    }

    private static void OnWidthOfCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var tileMap = (TileMap)d;
        tileMap.Children.Clear();
        tileMap.DrawTiles();
    }

    private static void OnHeightOfCellChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var tileMap = (TileMap)d;
        tileMap.Children.Clear();
        tileMap.DrawTiles();
    }

    private void DrawTiles()
    {
        if (ItemSource == null) return;

        var items = ItemSource as List<GameObject>;
        if (items == null) return;

        foreach (GameObject cell in items)
        {
            var image = new Image
            {
                Width = WidthOfCell,
                Height = HeightOfCell,
                Source = cell.GetComponent<SpriteComponent>().Source,
                Stretch = Stretch.Fill
            };

            SetLeft(image, cell.Transform.Position.X);
            SetTop(image, cell.Transform.Position.Y);

            Children.Add(image);
        }
    }
}