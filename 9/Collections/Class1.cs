using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab10
{
    public class Furniture
    {
        public string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public Furniture(string name)
        {
            Name = name;
        }
        public override string ToString()
        {
            return $"Мебель {_name}";
        }
    }

    public class MyCollection<T> : IList<T>
    {
        ArrayList list = new ArrayList();

        public T this[int index] { get => (T)list[index]; set { list[index] = value; } }

        public int Count => list.Count;

        public bool IsReadOnly => list.IsReadOnly;

        public void Add(T item)
        {
            list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            int index = list.IndexOf(item);

            if (index != -1)
            {
                list.Remove(list[index]);
                return true;
            }
            else return false;
        }

        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Find(T item)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(item)) return i;
            }
            return -1;
        }
        public void PrintMyCollection()
        {
            foreach (Furniture item in list) { Console.WriteLine(item); }
        }

    }

}

