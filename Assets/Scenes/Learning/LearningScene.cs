﻿using System.Windows.Input;
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
    private ICommand _backMainScreenCommand;

    public LearningScene()
    {
        _items = new Deque<LearningItem>([
            new LearningItem("Управление",
                "Управление персонажем происходит в главном окне игры.\n" +
                "За перемещение отвечают клавиши W, A, S, D - вперёд, влево, назад, вправо соответственно.\n" +
                "За поворот персонажа отвечают клавиши Q, E - влево, вправо соответственно.\n",
                "LearningAboutControl"),
            new LearningItem("Цель игры",
                "В игре вам необходимо собрать весь мусор до момента, пока у вас не закончатся все ресурсы (энергия, вода).\n" +
                "Если ваши ресурсы закончатся - вы проиграете. Если вы соберете весь мусор - вы выиграете.\n" +
                "Количество собранного мусора и оставшихся ресурсов можно посмотреть в окне ресурсов, нажав на Tab.\n" +
                "В окне отраженно минимальное, максимальное количества, а также справа - текущее количество ресурсов.\n",
                "LearningAboutResources"),
            new LearningItem("Взаимодействие с миром ",
                "Если с объектом можно взаимодействовать, то в левом верхнем углу будет отображено сообщение " +
                "в котором указана клавиша для активации объекта и краткое описание выполнения объекта.",
                "LearningAboutTargetOfObject"),
            new LearningItem("Восполнители ресурсов",
                "Если у вас заканчиваются ресурсы, вы можете воспользоваться специальными устройствами для их восполнения.",
                "LearningAboutFillerResources"),
            new LearningItem("Терминал",
                "На базе существует терминал. Чтобы получить информацию о его возможностях, используйте команду 'help'.",
                "LearningAboutTerminal")
        ]);
        NextCommand = new LambdaCommand<object, object>(_ => _items.InsertLast(SelectedItem = _items.TakeFirst()));
        BackCommand = new LambdaCommand<object, object>(_ => _items.InsertFirst(SelectedItem = _items.TakeLast()));
        BackMainScreenCommand = new LambdaCommand<object, object>(_ => App.SetScene(SceneType.MainMenu));
        SelectedItem = _items.PeekFirst();
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

    public ICommand BackMainScreenCommand
    {
        get => _backMainScreenCommand;
        private set => Set(ref _backMainScreenCommand, value);
    }
}