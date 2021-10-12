using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Laba11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            First();
            Second();
            Third();
            Fourth();

        }

        private static void Fourth()
        {
            //5.Придумайте запрос с оператором Join
            
            var busList = new List<Bus>();
            busList.Add(new Bus("Petrov I.I.", "ABCD12", "501-K", "Mers", 1990, 20));
            busList.Add(new Bus("Ivanov A.A", "EEY11", "503-K", "Mers", 2000, 10));

            var personList = new List<Person>();
            personList.Add(new Person("Vasya","EEY11"));
            personList.Add(new Person("Vova","ABCD12"));

            var result = from p in personList
                join bus in busList on p.BusNumber equals bus.BusNumber
                select new { Name = p.Name, BusNumber = p.BusNumber, CarMileage = bus.CarMileage };

            foreach (var item in result)
            {
                Console.WriteLine(item.ToString());
            }

        }


        private static void Third()
        {
            /*4.Придумайте и напишите свой собственный запрос,в котором было бы  не  менее  5  операторов из  разных  категорий: условия,  проекций, упорядочивания, группировки, агрегирования, кванторов и разбиения*/
            
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("----------");
            var busList = new List<Bus>();
            busList.Add(new Bus("Petrov I.I.", "ABCD12", "501-K", "Mers", 1990, 20));
            busList.Add(new Bus("Ivanov A.A", "EEY11", "503-K", "Mers", 2000, 10));
            busList.Add(new Bus("Zvorikyn D.D.", "GKL25", "501-K", "Mers", 2010, 5));
            busList.Add(new Bus("Stalmahova N.A.", "AB654", "506-K", "Mers", 2000, 12));
            busList.Add(new Bus("Snezniy V.D.", "AB655", "505-K", "Mers", 2000, 212));
            busList.Add(new Bus("Shiman D.V.", "AB656", "506-K", "Mers", 2000, 132));
            busList.Add(new Bus("Artemov A.A", "AB657", "507-K", "Mers", 2000, 112));
            busList.Add(new Bus("Stalmahova N.A.", "AB658", "508-K", "Mers", 2000, 152));

            int a = busList.OrderBy(x => x.YearOfOpetationStart).Where(x=>x.CarMileage>100).Take(4).Skip(1).Sum(x=>x.YearOfOpetationStart);
            Console.WriteLine(a);

        }

        private static void First()
        {
            /*Задайте массив типа string, содержащий 12 месяцев (June, July, May,
                December, January ….). 
                Используя LINQ to Object напишите следующие запросы: 
             */
            string[] months =
                { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            /*запрос выбирающий последовательность месяцев с длиной строки равной n*/
            Console.ForegroundColor = ConsoleColor.Magenta;
            var n = 5;
            Console.WriteLine("Months length n symbol: ");
            foreach (string item in from m in months where m.Length == n select m) Console.WriteLine(item);

            /*запрос возвращающий только летние и зимние месяцы, */
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Summer and winter months:");
            foreach (string item in from m in months
                where Array.IndexOf(months, m) < 2 ||
                      Array.IndexOf(months, m) > 4 && Array.IndexOf(months, m) < 8 ||
                      Array.IndexOf(months, m) == 11
                select m
            ) Console.WriteLine(item);

            /*запрос вывода месяцев в алфавитном порядке,*/
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Months sorted alphabetly:");
            foreach (string item in from m in months orderby m select m) Console.WriteLine(item);

            /*запрос считающий месяцы содержащие букву «u» и длиной имени не менее 4-х*/
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Months contains letter 'u' and length not less than 4:");
            foreach (string item in from m in months where m.Contains('u') && m.Length >= 4 select m) Console.WriteLine(item);
        }

        private static void Second()
        {
            /*2. Создайте коллекцию List<T> и параметризируйте ее типом (классом)
            из лабораторной №3 (при необходимости реализуйте нужные интерфейсы).
                TODO Заполните ее минимум 8 элементами.
                Если в задании указано свойство, которым ваш класс не обладает, то его
            нужно расширить, чтобы класс соответствовал условию. 
            Один из запросов реализуйте используя язык LINQ и используя методы расширения LINQ.*/
            /*3.На основе LINQсформируйте следующие запросыпо вариантам. При необходимости добавьте в класс T(тип параметра) свойства.*/
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("----------");
            var busList = new List<Bus>();
            busList.Add(new Bus("Petrov I.I.", "ABCD12", "501-K", "Mers", 1990, 20));
            busList.Add(new Bus("Ivanov A.A", "EEY11", "503-K", "Mers", 2000, 10));
            busList.Add(new Bus("Zvorikyn D.D.", "GKL25", "501-K", "Mers", 2010, 5));
            busList.Add(new Bus("Stalmahova N.A.", "AB654", "506-K", "Mers", 2000, 12));
           busList.Add(new Bus("Snezniy V.D.", "AB655", "505-K", "Mers", 2000, 212));
           busList.Add(new Bus("Shiman D.V.", "AB656", "506-K", "Mers", 2000, 132));
            busList.Add(new Bus("Artemov A.A", "AB657", "507-K", "Mers", 2000, 112));
            busList.Add(new Bus("Stalmahova N.A.", "AB658", "508-K", "Mers", 2000, 152));
            
            // список автобусов для заданного номера маршрута;
            // список автобусов, которые эксплуатируются больше заданного срока;
            // минимальный  по пробегу автобус
            // последние два автобуса максимальные по пробегу
            // упорядоченный список автобусов по номеру
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("A list of buses according to route number:");
            foreach (var bus in busList.Where(b => b.RouteNumber == "501-K"))
            {
                Console.WriteLine(bus.BusNumber);
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("A list of buses with car mileage more than 15 years:");
            foreach (var bus in busList.Where(b=>b.CarMileage>15))
            {
                Console.WriteLine(bus.BusNumber);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("A bus with the min car mileage:");
            Console.WriteLine(busList.Single(i => i.CarMileage==busList.Min(b=>b.CarMileage)).BusNumber);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Two buses with the max car mileage:");
            Console.WriteLine(busList.OrderByDescending(i=>i.CarMileage).ToList()[0].BusNumber);
            Console.WriteLine(busList.OrderByDescending(i=>i.CarMileage).ToList()[1].BusNumber);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("A list of buses ordered by bus number:");
            foreach (var bus in busList.OrderBy(b=>b.BusNumber))
            {
                Console.WriteLine(bus.BusNumber);
            }

            Console.WriteLine();
            



        }
    }
}