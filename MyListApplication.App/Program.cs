using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyListApplication.App
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> myList = new MyList<int>();

            myList.Add(32);
            myList.Add(16);
            myList.Add(8);
            myList.Add(132);
            myList.Add(55);
            myList.Add(17);

            myList.DisplayList();

            myList.Clear();

            try
            {
                Console.WriteLine("{0} {1}", myList[0], myList[1]);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }

            myList.Add(32); //0
            myList.Add(16); //1
            myList.Add(8);  //2
            myList.Add(132);//3
            myList.Add(55); //4
            myList.Add(17); //5

            Console.WriteLine("Count = {0}",myList.Count);

            //sterg numarul 8 => Count = 5
            myList.RemoveAt(2);

            Console.WriteLine("Count = {0}", myList.Count);
            myList.DisplayList();

            Console.WriteLine("Lista contine numarul 16 : {0}", myList.Contains(16).ToString());
            Console.WriteLine("Lista contine numarul 14 : {0}", myList.Contains(14).ToString());

            MyList<int> sortedList = myList.FindAll((x) => x > 20 ? true : false);
            sortedList.DisplayList();

            Console.ReadKey();

        }
    }
}
