using RECOVER.Assets.Scenes.CommonScene;
using RECOVER.Engine;

namespace RECOVER.Assets.Scenes.Learning;

public partial class Learning : SceneView
{
    private LearningScene _learningScene;

    public Learning()
    {
        InitializeComponent();
        DataContext = _learningScene = new LearningScene();
    }

    public override Scene Scene => _learningScene;
}