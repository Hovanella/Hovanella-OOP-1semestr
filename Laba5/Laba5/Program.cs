using System;

namespace Laba5
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            
           First();
          Fourth();
           Fifth();
          Seventh();
          


        }

        private static void First()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            /*1) Определить иерархию и композицию классов (в соответствии с вариантом),реализовать классы.
             Если необходимо расширьте по своему усмотрению иерархию для выполнения всех пунктов л.р.
            Каждый класс должен иметь отражающее смысл название и
информативный состав. 
            При кодировании должны быть использованы соглашения об оформлении кода code convention.
            В одном из классов переопределите все методы, унаследованные от Object.*/

            var tennisBall = new TennisBall("Bobby");

            Console.WriteLine(tennisBall.Name);
            Console.WriteLine(tennisBall.Type);
            tennisBall.WriteItForTennis();
        }

        private static void Second()
        {
            /*2)В проекте долженбыть минимум один интерфейси абстрактный класс. Использовать виртуальные методы и переопределение*/
        }

        private static void Third()
        {
            //Сделайте один из классов sealed;
        }

        private static void Fourth()
        {
            // Добавьте  в  интерфейсы (интерфейс)иабстрактный  класс одноименные методы. Добавьте  в  интерфейсы (интерфейс) и абстрактный  класс одноименные методы. 
            
            IHelloWorld helloWorld = new Bench();
            Inventory helloWorld2 = new Bench();
            var helloWorld3 = new Bench();
            
            
            helloWorld.SayHelloWorld();
            helloWorld2.SayHelloWorld();
        }

        private static void Fifth()
        {
            /*5)Написать  демонстрационную  программу,  в  которой  создаются  объекты различных классов. Поработать с объектами через ссылки на абстрактные классы иинтерфейсы. В этом случае для идентификации типов объектов использовать операторы is или as*/


            TennisBall tennisBall = new TennisBall();

            Console.WriteLine($"Is tennisBall a Ball  - {tennisBall is Ball}");
            Ball ball = tennisBall;//Upcast is correct

            TennisBall FirstTennisBall = new TennisBall();
            TennisBall SecondTennisBall = new TennisBall();

            if (FirstTennisBall is TennisBall)
            {
                FirstTennisBall = tennisBall;
                Console.WriteLine("First downcast is correct");
            }

            if ((SecondTennisBall = ball as TennisBall) != null)
            {
                Console.WriteLine("Second downcast is correct");
            }


        }

        private static void Sixth()
        {
            /*6)Во  всех  классах  (иерархии)  переопределить  метод ToString(),  который выводит информацию о типе объекта и его текущих значениях.*/
        }

        private static void Seventh() {
        //7)Создайте  дополнительный  класс Printercполиморфным методом IAmPrinting( SomeAbstractClassorInterfacesomeobj).   Формальным параметром метода должна быть ссылка на абстрактный класс или наиболее общий интерфейсв  вашейиерархии  классов.  В  методе iIAmPrintingопределите  типобъекта  и вызовите ToString().    В  демонстрационной программе создайте массив, содержащий ссылки на разнотипные объектываших классов по иерархии, а также объект класса Printerи последовательно вызовитеего метод IAmPrintingсо всеми ссылками вкачестве аргументов.

        var bench = new Bench("King");
        var mats = new Mats("adsa");
        var bars = new Bars();
        var ball = new BasketballBall();

        var inventoryItems = new Inventory[4];
        var printer = new Printer();

        inventoryItems[0] = bench;
        inventoryItems[1] = mats;
        inventoryItems[2] = bars;
        inventoryItems[3] = ball;

        foreach (var item in inventoryItems)
        {
            printer.IAmPrinting(item);
        }


        }
        
        
    }
}