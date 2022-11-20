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
        static void Main(string[] args)
        {
            Furniture chair = new Furniture("chair");
            Furniture table = new Furniture("table");

            MyCollection <Furniture> store = new MyCollection<Furniture>();
            store.Add(chair);
            store.Add(table);

            store.Remove(table);

            int index = store.Find(chair);

            store.PrintMyCollection();

            /////////////////////////////////////////////////////////////////////////////////

            ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add('a');
            arrayList.Add(1.23);
            arrayList.Add("nikita");

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