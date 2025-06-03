using System.Windows.Input;
using RECOVER.Assets.Prefabs.Learning;
using RECOVER.Engine;
using RECOVER.Engine.WPFTools;

namespace RECOVER.Assets.Scenes.Learning;

public class LearningScene : Scene
{
    private Deque<LearningItem> _items;
    private LearningItem _selectedItem;
    private ICommand _nextCommand;
    private ICommand _backCommand;

    public LearningScene()
    {
        _items = new Deque<LearningItem>();
        NextCommand = new LambdaCommand<object, object>(_ => _items.InsertLast(SelectedItem = _items.TakeFirst()));
        BackCommand = new LambdaCommand<object, object>(_ => _items.InsertFirst(SelectedItem = _items.TakeLast()));
    }

    public LearningItem SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }

    public ICommand NextCommand
    {
        get => _nextCommand;
        private set => Set(ref _nextCommand, value);
    }

    public ICommand BackCommand
    {
        get => _backCommand;
        private set => Set(ref _backCommand, value);
    }
}