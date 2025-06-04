using System.Windows.Media;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Prefabs.Learning;

public class LearningItem(string title, string text, ImageSource imageSource = null) : DeafNotificationObject
{
    private ImageSource _imageSource = imageSource;
    private string _title = title;
    private string _text = text;

    public LearningItem(string title, string text, string resourceKey)
        : this(title, text, (ImageSource)App.Current.Resources[resourceKey])
    {
    }

    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    public ImageSource ImageSource
    {
        get => _imageSource;
        set => Set(ref _imageSource, value);
    }

    public string Text
    {
        get => _text;
        set => Set(ref _text, value);
    }
}