namespace RECOVER.Assets.Prefabs.Learning;

public class Deque<T>
{
    private DequeImplItemNode _head;
    private DequeImplItemNode _tail;
    private DequeImplItemNode _emptyNode;
    private int _size;

    public Deque()
    {
        Clear();
    }

    public Deque(IEnumerable<T> array) : this()
    {
        this.ToAccept(array.ToArray());
    }

    public void InsertFirst(T item)
    {
        _head = new DequeImplItemNode(item, null, _head);
        _head.Next.Previous = _head;
        _size = _size + 1;
    }

    public void InsertLast(T item)
    {
        _tail = new DequeImplItemNode(item, _tail, null);
        _tail.Previous.Next = _tail;
        _size = _size + 1;
    }

    public T TakeFirst()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        T retItem = _head.Item;
        _head = _head.Next;
        _head.Previous = null;
        _size = _size - 1;

        return retItem;
    }

    public T TakeLast()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        T retItem = _tail.Item;
        _tail = _tail.Previous;
        _tail.Previous = null;
        _size = _size - 1;

        return retItem;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    public void Clear()
    {
        _emptyNode = _tail = _head = new DequeImplItemNode(null, null);
        _size = 0;
    }

    private void ToAccept(T[] array)
    {
        foreach (T item in array)
        {
            InsertLast(item);
        }
    }

    private class DequeImplItemNode
    {
        private readonly T _item;

        public DequeImplItemNode(T item, DequeImplItemNode previous, DequeImplItemNode next)
        {
            this._item = item;
            this.Next = next;
            this.Previous = previous;
        }

        public DequeImplItemNode(DequeImplItemNode previous, DequeImplItemNode next)
            : this(default, previous, next)
        {
        }

        public T Item => _item;

        public DequeImplItemNode Next { get; set; }

        public DequeImplItemNode Previous { get; set; }
    }
}