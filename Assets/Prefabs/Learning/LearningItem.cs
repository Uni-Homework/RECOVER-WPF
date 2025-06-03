using System.Windows.Media;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Prefabs.Learning;

public class LearningItem : DeafNotificationObject
{
    private ImageSource _imageSource;
    private string _text;

    public LearningItem(ImageSource imageSource, string text)
    {
        ImageSource = imageSource;
        Text = text;
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