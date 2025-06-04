namespace RECOVER.Assets.Prefabs.Learning;

public class Deque<T>
{
    private DequeImplItemNode _head;
    private DequeImplItemNode _tail;
    private int _size;

    public Deque(IEnumerable<T> array)
    {
        ToAccept(array.ToArray());
    }

    public void InsertFirst(T item)
    {
        if (IsEmpty())
        {
            SetFirstElement(item);
        }
        else
        {
            _head = new DequeImplItemNode(item, null, _head);
            _head.Next.Previous = _head;
            _size = _size + 1;
        }
    }

    private void SetFirstElement(T item)
    {
        _head = _tail = new DequeImplItemNode(item);
        _size = _size + 1;
    }

    public void InsertLast(T item)
    {
        if (IsEmpty())
        {
            SetFirstElement(item);
        }
        else
        {
            _tail = new DequeImplItemNode(item, _tail, null);
            _tail.Previous.Next = _tail;
            _size = _size + 1;
        }
    }

    public T TakeFirst()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        T retItem = _head.Item;
        _size = _size - 1;

        if (IsEmpty()) return retItem;

        _head = _head.Next;
        _head.Previous = null;

        return retItem;
    }

    public T TakeLast()
    {
        if (IsEmpty())
        {
            throw new Exception();
        }

        T retItem = _tail.Item;
        _size = _size - 1;

        if (IsEmpty()) return retItem;
        
        _tail = _tail.Previous;
        _tail.Next = null;

        return retItem;
    }

    public T PeekFirst()
    {
        return _head.Item;
    }
    
    public T PeekLast()
    {
        return _head.Item;
    }

    public bool IsEmpty()
    {
        return _size == 0;
    }

    private void ToAccept(T[] array)
    {
        foreach (T item in array)
        {
            InsertLast(item);
        }
    }

    private class DequeImplItemNode(T item, DequeImplItemNode previous = null, DequeImplItemNode next = null)
    {
        public T Item => item;

        public DequeImplItemNode Next { get; set; } = next;

        public DequeImplItemNode Previous { get; set; } = previous;
    }
}