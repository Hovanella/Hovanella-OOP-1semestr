using System;
using Microsoft.VisualBasic;

namespace Laba8
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Second();
            Third();
            Fourth();*/
            Fifth();
        }

        private static void Fifth()
        {
            /*.TODO Добавьте   методы сохранения объектов обобщённого типа  CollectionType<T>в файли чтения из него( на выбор: текстовый | xml | json).*/
            
            var stringList = new List<double>();
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            stringList.Add(1.2);
            stringList.Add(2.3);
            stringList.Add(4.4);
            stringList.Show();
            var itemsFromfile = new double[]{};
            stringList.WriteToFile<string>();
            itemsFromfile= stringList.ReadFromFile<double>();
            foreach (double s in itemsFromfile)
            {
              Console.WriteLine(s);   
            }
            
        }

        private static void Fourth()
        {
            /*4.Определить пользовательский класс, который будет использоваться в качестве  параметра обобщения.  Для  пользовательского  типа  взять  класс  из лабораторной No5 «Наследование». */
            Console.ForegroundColor = ConsoleColor.Gray;
            var BenchList = new List<Bench>();
            BenchList.Add(new Bench());
            BenchList.Add(new Bench("A",300));
            BenchList.Add(new Bench("B",1000));
            BenchList.Show();
        }

        private static void Third()
        {
            /*Проверьте использование обобщения для стандартных типов данных (в качестве стандартных типов использовать целые, вещественные и т.д.).*/

            var stringList = new List<string>();
            var intList = new List<int>();
            var doubleList = new List<double>();

            Console.ForegroundColor = ConsoleColor.Magenta;
            stringList.Add("A");
            stringList.Add("B");
            stringList.Add("C");
            stringList.Delete("B");
            stringList.Show();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
          intList.Add(12);
          intList.Add(13);
          intList.Add(14);
          intList.Delete(14);
          intList.Show();
          
          Console.ForegroundColor = ConsoleColor.Green;
          doubleList.Add(1.2);
          doubleList.Add(2.2);
          doubleList.Add(3.2);
          doubleList.Delete(3.2);
          doubleList.Show();
            
        }

        private static void Second()
        {
            /*2.Возьмите  за  основу  лабораторную  No  4  «Перегрузка  операций»и сделайте  из  нееобобщенный тип  (класс)CollectionType<T>,  в  который вложите обобщённую коллекцию.
             Наследуйте в обобщенном классе интерфейс из  п.1. Реализуйтенеобходимые  методы(добавления,  удаления,  поиска  по предикату).
             Добавьте обработку исключений c finally.Наложите какое-либо ограничениена обобщение*/
            
            var list = new List<int>();
            try
            {
                list.Add(12);
                list.Add(13);
                list.Add(14);
                list.Show();
                list.Delete(13);
                list.Show();
                list.Delete(12);
                list.Show();
                list.Delete(14);
                list.Show();
                list.Delete(14);
            }
            catch (InvalidOperationException e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally");
            }
        }
    }
}