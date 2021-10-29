using System;

namespace Laba6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Second();
            Third(); 
            Fourth();
            FirstDop();
            SecondDop();
        }

        private static void First()
        {
            /*К предыдущей лабораторной работе (л.р. 5) добавьте  к существующим классам перечислениеи структуру.*/
        }

        private static void Second()
        {
            /*2)Один из классов сделайте partial и разместите его в разных файлах*/
            var ball = new Ball();
            ball.SaySomething();
        }

        private static void Third()
        {
            // 3)Определить класс-Контейнер(указан в вариантах жирным шрифтом) для хранения разных типов объектов (в пределах иерархии)  в виде списка или массива (использовать абстрактный тип данных). Класс-контейнер  должен  содержать  методы  get  и  set  для управления списком/массивом,  методы  для добавления  и  удаления  объектов  в список/массив, метод для вывода списка на консоль. 

            var firstItem = new Ball("A", 2000);
            var secondItem = new Ball("B", 1000);
            var thirdItem = new Ball("C", 3000);
            var fourthItem = new Mats("D", 500);
            var fifthItem = new Bars("E", 500);

            var gym = new Gym(10000, 5, firstItem, secondItem, thirdItem);
            gym.PrintInventoryList();
            gym.Delete(firstItem);
            gym.PrintInventoryList();
            gym.Add(fourthItem);
            gym.Add(fifthItem);
            gym.Add(firstItem);
            gym.PrintInventoryList();
        }

        private static void Fourth()
        {
            /*4)Определить    управляющий класс-Контроллер,  который  управляет объектом-Контейнером и реализовать в нем запросы по варианту. При необходимости  используйте  стандартные  интерфейсы  (IComparable, ICloneable,....)*/
            var firstItem = new Ball("A", 2000);
            var secondItem = new Ball("B", 1000);
            var thirdItem = new Ball("C", 3000);

            var gym = new Gym(10000, 5, firstItem, secondItem, thirdItem);
            var controller = new Controller();

            foreach (var item in controller.FindItemsByCostRange(gym, 1000, 2500)) Console.WriteLine(item.ToString());
        }

        private static void FirstDop()
        {
            /*1.  Добавьте  в  класс-контроллер  метод,  считывающий  построчно текстовый файл, в котором хранятся данные вашего класса и инициализирует таким образом коллекцию*/
            var gym = new Gym(10000, 5);
            var controller = new Controller();
            controller.CreateGymFromTextFile(gym);
            gym.PrintInventoryList();
        }

        private static void SecondDop()
        {
            /*2. Реализуйте еще один метод, который будет считывать данные из json файла и инициализировать коллекцию (https://www.newtonsoft.com/json).*/
            var controller = new Controller();
            var gym = new Gym();
            controller.CreateGymFromJSONFile(gym);
            gym.PrintInventoryList();
        }
    }
}