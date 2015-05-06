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
        private int numberOfItems;

        public MyList()
        {
            Initialize();
           
        }

        public int Count 
        {
            get
            {
                return numberOfItems;
            }
        }

        public void Add(T item)
        {
            if(Count == items.Count())  //nu mai avem loc in Array
            {
                var newItems = new T[Count * 2];
                Array.Copy(items, newItems, Count);
                items = newItems;
            }
            items[Count] = item;
            numberOfItems++;
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("index", "Index must pe bigger or equal with 0 and smaller than Count");
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
                    throw new ArgumentOutOfRangeException("index", "Index must pe bigger or equal with 0 and smaller than Count");
                }
                else
                {
                    items[index] = value;
                }
            }
        }

        public void Clear()
        {
            Initialize();
        }

        public bool Contains (T item)
        {
            if (item != null)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (item.Equals(items[i]))
                    {
                        return true;
                    }
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
            numberOfItems--;
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
            for (int i = 0; i < Count; i++)
            {
                Console.Write("{0} ", items[i]);
            }
            Console.WriteLine();
        }

        private void Initialize()
        {
            //dimensiunea default pt MyList = 2
            items = new T[2];
            numberOfItems = 0;
        }
    }
}
