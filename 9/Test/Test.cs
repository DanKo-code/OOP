using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

class Programm
{
    class Person
{
    public string Name { get; }
    public Person(string name) => Name = name;
}


// обработчик изменения коллекции
static void People_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
{
    switch (e.Action)
    {
        case NotifyCollectionChangedAction.Add: // если добавление
            if (e.NewItems?[0] is Person newPerson)
                Console.WriteLine($"Добавлен новый объект: {newPerson.Name}");
            break;
        case NotifyCollectionChangedAction.Remove: // если удаление
            if (e.OldItems?[0] is Person oldPerson)
                Console.WriteLine($"Удален объект: {oldPerson.Name}");
            break;
        case NotifyCollectionChangedAction.Replace: // если замена
            if ((e.NewItems?[0] is Person replacingPerson) &&
                (e.OldItems?[0] is Person replacedPerson))
                Console.WriteLine($"Объект {replacedPerson.Name} заменен объектом {replacingPerson.Name}");
            break;
    }
}

static void main()
{
        var people = new ObservableCollection<Person>()
{
    new Person("Tom"),
    new Person("Sam")
};
        // подписываемся на событие изменения коллекции
        people.CollectionChanged += People_CollectionChanged;

        people.Add(new Person("Bob"));  // добавляем новый элемент

        people.RemoveAt(1);                 // удаляем элемент
        people[0] = new Person("Eugene");   // заменяем элемент

        Console.WriteLine("\nСписок пользователей:");
        foreach (var person in people)
        {
            Console.WriteLine(person.Name);
        }
    }

}

