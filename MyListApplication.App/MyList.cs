using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListApplication.App
{
    public class MyList<T> : IEnumerable<T>
    {
        private T[] items;

        public MyList()
        {
            items = new T[0];
        }

        public int Count 
        {
            get
            {
                return items.Count();
            }
        }

        public void Add(T item)
        {
            var newItems = new T[this.Count + 1];
            Array.Copy(items, newItems, items.Count());
            newItems[items.Count()] = item;
            items = newItems;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("index", "Index must pe bigger than one and smaller than Count");
                }
                else
                {
                    return items[index];
                }
            }
            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("index", "Index must pe bigger than one and smaller than Count");
                }
                else
                {
                    items[index] = value;
                }
            }
        }

        public void Clear()
        {
            items = new T[0];
        }

        public bool Contains (T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (item.Equals(items[i]))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            var newItems = new T[this.Count - 1];
            Array.Copy(items, 0, newItems, 0, index);
            Array.Copy(items, index + 1, newItems, index, Count - index - 1);
            items = newItems;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MyList<T> FindAll(Func<T, bool> match)
        {
            MyList<T> resultList = new MyList<T>();
            foreach ( T listItem in this.items )
            {
                if (match(listItem))
                    resultList.Add(listItem);
            }
            return resultList;
        }

        public void DisplayList()
        {
            foreach (T listItem in this.items)
            {
                Console.Write("{0} ", listItem);
            }
            Console.WriteLine();
        }
    }
}
