using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab10;
using System.Xml.Linq;

namespace Lab10
{
    class Collections
    {


        //class Week
        //{
        //    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
        //                 "Friday", "Saturday", "Sunday" };
        //    public IEnumerator GetEnumerator() => days.GetEnumerator();
        //}

        //class WeekEnumerator : IEnumerator
        //{
        //    string[] days;
        //    int position = -1;
        //    public WeekEnumerator(string[] days) => this.days = days;
        //    public object Current
        //    {
        //        get
        //        {
        //            if (position == -1 || position >= days.Length)
        //                throw new ArgumentException();
        //            return days[position];
        //        }
        //    }
        //    public bool MoveNext()
        //    {
        //        if (position < days.Length - 1)
        //        {
        //            position++;
        //            return true;
        //        }
        //        else
        //            return false;
        //    }
        //    public void Reset() => position = -1;
        //}

        //class Week
        //{
        //    string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday",
        //                    "Friday", "Saturday", "Sunday" };
        //    public IEnumerator GetEnumerator() => new WeekEnumerator(days);
        //}

        static void Main(string[] args)
        {
            //Week week = new Week();
            //foreach (var day in week)
            //{
            //    Console.WriteLine(day);
            //}

            /////////////////////////////////////////////////////////////////////

            //string[] people = { "Tom", "Sam", "Bob" };

            //IEnumerator peopleEnumerator = people.GetEnumerator(); // получаем IEnumerator
            //while (peopleEnumerator.MoveNext())   // пока не будет возвращено false
            //{
            //    string item = (string)peopleEnumerator.Current; // получаем элемент на текущей позиции
            //    Console.WriteLine(item);
            //}
            //peopleEnumerator.Reset(); // сбрасываем указатель в начало массива

            Furniture chair = new Furniture("chair");
            Furniture table = new Furniture("table");

            MyCollection <Furniture> store = new MyCollection<Furniture>();
            store.Add(chair);
            store.Add(table);
            //store.Add(table);
            //store.Add(table);

            store.Remove(table);

            int index = store.Find(chair);

            store.PrintMyCollection();

            /////////////////////////////////////////////////////////////////////////////////

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add('a');
            arrayList.Add(1.23);
            arrayList.Add("nikita");
            //arrayList.IndexOf("nikita");

            arrayList.RemoveRange(1, 2);

            arrayList.AddRange(new Dictionary<int, string>() { { 1, "first" }, { 2, "second" } });
            arrayList.InsertRange(1 ,new[] { 'a', 'b', 'c' });

            Dictionary<int, string> dictionary = new Dictionary<int, string>();

            for (int i = 0; i < arrayList.Count; i++)
            {
                dictionary.TryAdd(i, arrayList[i].ToString());
                Console.WriteLine(dictionary[i]);
            }

            ObservableCollection<Furniture> obsFurniture = new ObservableCollection<Furniture>() { chair, table };

            obsFurniture.CollectionChanged += ObsFurnitureChanged;
            Furniture bed = new Furniture("bed");
            obsFurniture.Add(bed);
            obsFurniture.Remove(table);
            Console.ReadKey();

        }

        private static void ObsFurnitureChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Console.WriteLine($"Элемент {e.NewItems[0] as Furniture} был добавлен");
                        break;
                    };
                case NotifyCollectionChangedAction.Remove:
                    {
                        Console.WriteLine($"Элемент {e.OldItems[0] as Furniture} был удален");
                        break;
                    }
            }
        }
    }
}