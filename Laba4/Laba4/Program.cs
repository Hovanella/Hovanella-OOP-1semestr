using System;

namespace Laba4
{
    class Program
    {
        static void Main(string[] args)
        {
         
            // First();
            // Second();
            // Third();
            Fourth();
            Fifth();
        }

        static void First()
        {
            /*1)Создать заданный в варианте класс. Определить в классе необходимые методы,  конструкторы,  индексаторыи  заданные  перегруженные операции.  Написать  программу  тестирования,  в  которой  проверяется использование перегруженных операций.*/
            Console.ForegroundColor = ConsoleColor.Magenta;

            var myList = new List();
                
            myList.Show();
            
            myList.Add("A");
            myList.Add("B");
            myList.Add("C");
            myList.Show();
            
            myList.Remove("B");
            myList.Show();
            
            myList.Clear();
            myList.Show();

            Console.ForegroundColor = ConsoleColor.Red;
            
            var firstList = new List();
            firstList.Add("A");
            firstList.Add("B");
            firstList.Add("C");
            var secondList = new List();
            secondList.Add("D");
            secondList.Add("E");
            secondList.Add("F");

            Console.WriteLine($"First list and second list are equal ? - {firstList==myList}");

            Console.Write($"First list + second list: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            (firstList+secondList).Show();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"First list inversed : ");
            Console.ForegroundColor = ConsoleColor.Blue;
            (!firstList).Show();
            Console.ForegroundColor = ConsoleColor.Green;
            (firstList<secondList).Show();
            (firstList>secondList).Show();
            
        }
        static void Second()
        {
            // 2)Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его   
            var firstList = new List
            {
                ListOwner = new List.Owner("Tima", "BSTU")
            };
            Console.WriteLine(firstList.ListOwner.Name);
        }
        static void Third()
        {
            // 2)Добавьте в свой класс вложенный объект Owner, который содержит Id, имя и организацию создателя. Проинициализируйте его
            Console.ForegroundColor = ConsoleColor.Yellow;
            var newList = new List();
            Console.WriteLine(newList.ListDate.CreationDate);
        }
        static void Fourth()
        {
            // 4)Создайте статический класс StatisticOperation, содержащий 3 метода для работы  с  вашим  классом  (по  варианту  п.1): сумма, разница  между максимальным и минимальным, подсчет количества элементов
            Console.ForegroundColor = ConsoleColor.Blue;
            
            var myList = new List();
            myList.Add("AAA");
            myList.Add("BBB");
            myList.Add("CCC");
            Console.WriteLine(StatisticOperation.CountCapacity(myList));
            Console.WriteLine(StatisticOperation.FindTheLongestString(myList));
            
           
     

        }
        static void Fifth(){
            
            /*5)Добавьте к классу StatisticOperationметодырасширения для типаstringи  вашего типа из заданияNo1.См. задание по вариантам*/
            
            var myList = new List();
            myList.Add("AAA");
            myList.Add("BBB");
            myList.Add("CCC");
            
            myList.ShortenString(1);
            myList.Show();

            Console.WriteLine(myList.ConcatAllElements());
        }
    }
}