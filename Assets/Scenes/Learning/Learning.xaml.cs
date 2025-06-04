using System.Windows.Input;
using RECOVER.Assets.Scenes.CommonScene;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.Learning;

public partial class Learning : SceneView
{
    private LearningScene _learningScene;
    private const double ScrollAmount = 10;


    public Learning()
    {
        InitializeComponent();
        DataContext = _learningScene = new LearningScene();
    }

    public override Scene Scene => _learningScene;

    protected override void OnKeyDown(KeyEventArgs e)
    {
        switch (e.Key)
        {
            case Key.Up:
                MainText.ScrollToVerticalOffset(MainText.VerticalOffset - ScrollAmount);
                e.Handled = true;
                break;
            case Key.Down:
                MainText.ScrollToVerticalOffset(MainText.VerticalOffset + ScrollAmount);
                e.Handled = true;
                break;
        }

        base.OnKeyDown(e);
    }
}