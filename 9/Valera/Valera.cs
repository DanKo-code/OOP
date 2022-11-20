//class MyList<T> : IList<T>
//{
//    class Node
//    {
//        public T Value { get; set; }
//        public Node Next { get; set; }
//    }

//    private Node Head, Tail;

//    private Node FindNode(T value)
//    {
//        for (Node node = Head; node != Tail; node = node.Next)
//            if (node.Next != null && Equals(node.Next.Value, value))
//                return node;
//        return null;
//    }

//    private IEnumerable<Node> GetAllNodex()
//    {
//        for (Node node = Head; node != null; node = node.Next)
//            yield return node;
//    }

//    public IEnumerator<T> GetEnumerator()
//    {
//        return GetAllNodex().Select(x => x.Value).GetEnumerator();
//    }

//    IEnumerator IEnumerable.GetEnumerator()
//    {
//        return GetEnumerator();
//    }

//    public void Add(T item)
//    {
//        var newNode = new Node() { Value = item };
//        if (Head == null)
//        {
//            Head = Tail = newNode;
//        }
//        else
//        {
//            Tail.Next = newNode;
//            Tail = newNode;
//        }
//        Count++;
//    }

//    public void Clear()
//    {
//        Head = Tail = null;
//        Count = 0;
//    }

//    public bool Contains(T item)
//    {
//        return Enumerable.Contains(this, item);
//    }

//    public void CopyTo(T[] array, int arrayIndex)
//    {
//        if (arrayIndex + Count > array.Length)
//            throw new IndexOutOfRangeException();
//        int i = arrayIndex;
//        foreach (T value in this)
//        {
//            array[i++] = value;
//        }
//    }

//    public bool Remove(T item)
//    {
//        var node = FindNode(item);
//        if (node == null)
//            return false;
//        node.Next = node.Next.Next;
//        Count--;
//        return true;
//    }

//    public int Count { get; private set; }

//    public bool IsReadOnly { get { return false; } }

//    public int IndexOf(T item)
//    {
//        int i = 0;
//        foreach (T value in this)
//        {
//            if (Equals(value, item))
//                return i;
//            i++;
//        }
//        return -1;
//    }

//    public void Insert(int index, T item)
//    {
//        throw new NotImplementedException();
//    }

//    public void RemoveAt(int index)
//    {
//        throw new NotImplementedException();
//    }

//    public T this[int index]
//    {
//        get { throw new NotImplementedException(); }
//        set { throw new NotImplementedException(); }
//    }
//}
