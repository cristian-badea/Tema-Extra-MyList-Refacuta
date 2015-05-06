using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListApplication.App
{
    class MyListEnumerator<T> : IEnumerator<T>
    {
        private MyList<T> myList;
        private int currentIndex;
        private T currentListElement;

        public MyListEnumerator(MyList<T> myList)
        {
            this.myList = myList;
            currentIndex = -1;
            currentListElement = default(T);
        }

        public bool MoveNext()
        {
            currentIndex++;
            if (currentIndex > myList.Count)
            {
                return false;
            }
            else
            {
                currentListElement = myList[currentIndex];
                return true;
            }
        }

        public void Reset()
        {
            currentIndex = -1;
            currentListElement = default(T);
        }

        public T Current
        {
            get
            {
                return currentListElement;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        void IDisposable.Dispose() { }
    }
}
