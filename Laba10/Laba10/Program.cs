using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Laba10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            First();
            Second();
            Third();
        }

        private static void Third()
        {
            /*3.Создайте объект наблюдаемой коллекции ObservableCollection<T>.
             Создайте произвольный метод и  зарегистрируйте  его на  событие  CollectionChange. 
             Напишите демонстрацию с добавлением и удалением элементов. 
             В качестве типа Tиспользуйте свой класс из таблицы.*/

            Console.ForegroundColor = ConsoleColor.Magenta;
            var myCollection = new ObservableCollection<WebResourse>();
            myCollection.CollectionChanged += SayChange;

            myCollection.Add(new WebResourse("T.by"));
            myCollection.Add(new WebResourse("A.by"));
            myCollection.Add(new WebResourse("C.by"));

            myCollection.RemoveAt(2);
        }

        private static void Second()
        {
            /*2.Создайте универсальную коллекцию в соответствии с вариантом задания и заполнить ее данными встроенного типа .Net(int, char,...).
             a  .Выведите коллекцию на консоль
             b.Удалите из коллекции n последовательных элементов
             c.Добавьте другие элементы(используйте  все  возможные  методы добавления для вашего типаколлекции).
              d.Создайте вторую  коллекцию(из таблицы  выберите  другой  тип коллекции)и заполните ее данными из первой коллекции.
              e.Выведите  вторую  коллекцию  на  консоль.  В  случае  не  совпадения количества  параметров(например, LinkedList<T>и Dictionary<Tkey, TValue>), при нехватке-генерируйте ключи, в случае избыточности –оставляйте TValue.
              f.Найдите во второй коллекции заданное значение*/

            Console.ForegroundColor = ConsoleColor.Green;

            var universalCollection = new ConcurrentDictionary<string, int>();
            var enotherCollection = new Dictionary<string, int>();

            universalCollection.TryAdd("A", 12);
            universalCollection.GetOrAdd("B", 12);
            universalCollection.TryAdd("C", 12);
            foreach (var keyValuePair in universalCollection) Console.WriteLine($"Key - {keyValuePair.Key} , Value - {keyValuePair.Value}");

            int tmp;
            universalCollection.TryRemove("A", out tmp);
            Console.WriteLine(tmp);

            foreach (var keyValuePair in universalCollection) enotherCollection.Add(keyValuePair.Key, keyValuePair.Value);
            foreach (var keyValuePair in enotherCollection) Console.WriteLine($"Key - {keyValuePair.Key} , Value - {keyValuePair.Value}");

            Console.WriteLine(enotherCollection.ContainsValue(12));
        }

        private static void First()
        {
            /*Создайте класс по варианту, определите внем свойства и методы,
             реализуйте указанный интерфейси другие при необходимости,
            соберите объекты класса  в коллекцию  
            (можно  сделать  специальных  класс  с  вложенной  коллекцией  и методами   ею   управляющими),  
             продемонстрируйте   работу      сней (добавление/удаление/поиск/вывод:*/

            Console.ForegroundColor = ConsoleColor.Blue;

            var myCollection = new MyCollection<WebResourse>();
            var enotherCollection = myCollection;
            var web = new WebResourse();
            var array = new WebResourse[5];


            myCollection.Add(new WebResourse("T.by"));
            myCollection.Add(new WebResourse("A.by"));
            myCollection.Add(new WebResourse("B.by"));
            myCollection.Show();
            myCollection.Insert(1, web);
            Console.WriteLine(myCollection.Contains(web));
            Console.WriteLine(myCollection.IndexOf(web));
            myCollection.Show();
            myCollection.Remove(web);
            myCollection.RemoveAt(0);
            Console.WriteLine(myCollection[0]);


            myCollection.CopyTo(array, 2);
            foreach (var i in array) Console.Write($"{i} ");
            Console.WriteLine();

            myCollection.Show();

            myCollection.Clear();
            myCollection.Show();

            Console.WriteLine(myCollection.Equals(enotherCollection));
        }
        
        private static void SayChange(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
                Console.WriteLine("|Add comlete|");
            else if (e.Action == NotifyCollectionChangedAction.Remove) Console.WriteLine("|Remove complete|");
        }
    }
}