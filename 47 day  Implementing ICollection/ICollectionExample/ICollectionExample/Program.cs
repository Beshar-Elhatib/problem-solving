using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICollectionExample
{
    using System;
    using System.Collections;
    using System.ComponentModel;

    //does not implement members of ICollection<T> interface ها الخطاء الي بواجهو اذا ماعرفت الميثودات الازمة 
    public class TestCollection<T> : ICollection<T>

    {
        ArrayList list =new ArrayList ();

        public int Count => list.Count;
        public void Add(T item) { list.Add(item);  }

        public bool IsReadOnly => false;


        public void Clear()
        {
            list.Clear (); 
        }

        public bool Contains(T item)
        {
           return list.Contains(item) ? true: false; 
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < list.Count; i++)
            {
                array[arrayIndex + i] = (T)list[i];
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach(T item in list)
            {
                yield return item;
            }
        }

        public bool Remove(T item)
        {
            int index = list.IndexOf(item); 
            if(index==-1)
                return false;
            else
            {
                list.RemoveAt(index);
                return true;
            }

        }

        void ICollection<T>.Add(T item)
        {
            list.Add(item);
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    public class SimpleCollection<T> : ICollection<T>
    {
        private List<T> items = new List<T>();


        public int Count => items.Count;


        public bool IsReadOnly => false;


        public void Add(T item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }


        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }


        public bool Remove(T item)
        {
            return items.Remove(item);
        }


        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SimpleCollection<string> shoppingCart = new SimpleCollection<string>();
            shoppingCart.Add("Apple");
            shoppingCart.Add("Banana");
            shoppingCart.Add("Carrot");
            TestCollection<string > testCollection = new TestCollection<string>(); 
            testCollection.Add("Test1");
            testCollection.Add("Test2");
            foreach(var item in testCollection)
            {
                Console .WriteLine (item);
            }
            Console.WriteLine(testCollection.Count);
            Console.WriteLine(testCollection.Remove("Test2"));
            Console.WriteLine(testCollection.Count);

            Console.WriteLine($"Items in cart: {shoppingCart.Count}");

            if (shoppingCart.Contains("Banana"))
            {
                shoppingCart.Remove("Banana");
                Console.WriteLine("Banana removed from the cart.");
            }


            Console.WriteLine("Final items in the cart:");
            foreach (var item in shoppingCart)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();

        }
    }
}
