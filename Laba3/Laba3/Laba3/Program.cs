using System;

namespace Laba3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Задание 1)
            // Определить класс, указанный в варианте, содержащий:
            // Не  менее  трехконструкторов(с  параметрамии  без,  а  также  с параметрами по умолчанию);статический конструктор(конструктор типа);
            // определите закрытый конструктор; предложите варианты его вызова;
            // поле -только для чтения(например, для каждого экземпляра сделайте поле только для чтенияID-равнонекоторому уникальному номеру (хэшу)  вычисляемому  автоматически  на  основе  инициализаторов объекта);поле-константу;
            // свойства(get,  set) –для всех полекласса(поля класса должны быть закрытыми);Для одного из свойств ограните доступ по set
            // водном из методовклассадля работы с аргументами используйтеref -и out-параметры.создайте в классе статическое поле, хранящее количество созданных объектов  (инкрементируется  в  конструкторе)  и статический методвывода информации о классе.
            // сделайте касс partial
            // переопределяете методыкласса Object: Equals, для сравнения объектов,GetHashCode; для  алгоритма  вычисления хэша  руководствуйтесь стандартными  рекомендациями,    ToString –вывода  строки –информации об объекте
            Console.ForegroundColor = ConsoleColor.Cyan;
            SecondTask();
            ThirdTask();
        }

        private static void SecondTask()
        {
            // 2)Создайте  несколько  объектов  вашего  типа.  Выполните  вызов конструкторов,  свойств,  методов,  сравнение  объекты, проверьте  тип созданного объекта и т.п.

            var bus1 = new Bus();
            var bus2 = new Bus("Petrov I.I.", "ABCD12", "501-K", "Mers", 1990, 15);
            Console.WriteLine($"Are bus1 and bus2 equal? - {bus1.Equals(bus2)}");
            Console.WriteLine($"Type of bus1 - {bus1.GetType()}");
            bus1.ShowClassInfo();

            Console.WriteLine("Ref and Out Parametres :");
            int carMileage = bus1.CarMileage;
            Bus.IncreaseCarMileage(ref carMileage);
            bus1.CarMileage = carMileage;
            Console.WriteLine(bus1.CarMileage);

            Bus.ChangeBrand(out string brand, "asda");
            bus1.BusBrand = brand;
            Console.WriteLine(bus1.BusBrand);   
        }

        private static void ThirdTask()
        {
            /*Создайте  массив  объектов  вашего  типа.И  выполните      задание, выделенное курсивом в таблице*/
            var Buses = new Bus[4];
            Buses[0] = new Bus("Petrov I.I.", "ABCD12", "501-K", "Mers", 1990, 20);
            Buses[1] = new Bus("Ivanov A.A", "EEY11", "503-K", "Mers", 2000, 10);
            Buses[2] = new Bus("Zvorikyn D.D.", "GKL25", "501-K", "Mers", 2010, 5);
            Buses[3] = new Bus("Anreyeva E.I.", "AB654", "506-K", "Mers", 2000, 12);

            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var bus in Buses)
                if (bus.RouteNumber == "501-K")
                    Console.WriteLine(bus.BusNumber);

            Console.ForegroundColor = ConsoleColor.Yellow;
            foreach (var bus in Buses)
                if (DateTime.Now.Year - bus.GetYearOfOperationStart() > 12)
                    Console.WriteLine(bus.BusNumber);
        }

        private static void FourthTask()
        {
            //4)Создайте и выведите анонимный тип
            var driver = new { Name = "Ivanov", Surname = "Ivan" };
            Console.WriteLine($"Name: {driver.Name}\n" +
                              $"Surname: {driver.Surname}\n");
        }
    }
}

