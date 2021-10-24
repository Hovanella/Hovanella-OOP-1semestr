using System;
using System.IO;
using System.Reflection;
using Laba3;
using Laba6;
namespace Laba12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ClearFile();
            First();
            Second();
            Third();
        }

        private static void Third()
        {
            /*2. Добавьте в Reflector обобщенный метод Create, который создает объект
            переданного типа (на основе имеющихся публичных конструкторов) и возвращает
            его пользователю.*/
            var sum = Reflector.Create("Laba12.Sum");
            Console.WriteLine(sum is Sum);
        }

        private static void Second()
        {
            
            /*Продемонстрируйте работу «Рефлектора» для исследования типов на созданных
                вами классах не менее двух (предыдущие лабораторные работы) и стандартных
            классах .Net.*/  
            
            //Для рефлексии файлов других сборок нужно подключить эти сборки в проект,а затем подключить их namespace
            
            Reflector.WriteAssemblyName("Laba3.Bus, Laba3");
            Reflector.WriteIsAnyPublicConstruction("Laba3.Bus, Laba3");
            Reflector.WritePublicMethods("Laba3.Bus, Laba3"); 
            Reflector.WriteMethodsWithUserParametr("Laba3.Bus, Laba3","brand");
            
            Reflector.WriteAssemblyName("Laba6.Gym, Laba6");
            Reflector.WriteIsAnyPublicConstruction("Laba6.Gym, Laba6");
            Reflector.WritePublicMethods("Laba6.Gym, Laba6");
            Reflector.WritePublicMethods("Laba6.Gym, Laba6"); 
            Reflector.WriteMethodsWithUserParametr("Laba6.Gym, Laba6","item");
            
            Reflector.WriteAssemblyName("System.Object");
            Reflector.WriteIsAnyPublicConstruction("System.Object");
            Reflector.WritePublicMethods("System.Object"); 
            Reflector.WriteMethodsWithUserParametr("System.Object","");
            
            
        }

        private static void First()
        {
            /*1. Для изучения .NET Reflection API напишите статический класс Reflector,
                который собирает информацию и будет содержать методы выполняющие
                исследования класса (принимают в качестве параметра имя класса) и
                записывающие информацию в файл (формат тестовый, json или xml):
            a. Определение имени сборки, в которой определен класс;
            b. есть ли публичные конструкторы;
            c. извлекает все общедоступные публичные методы класса
                (возвращает IEnumerable<string>);
            d. получает информацию о полях и свойствах класса (возвращает
            IEnumerable<string>);
            e. получает все реализованные классом интерфейсы (возвращает
            IEnumerable<string>);
            f. выводит по имени класса имена методов, которые содержат
            заданный (пользователем) тип параметра (имя класса передается
                в качестве аргумента);
            g. метод Invoke, который вызывает метод класса, при этом значения
            для его параметров необходимо
             1) прочитать из текстового файла
                (имя класса и имя метода передаются в качестве аргументов) 
             2) сгенерировать, используя генератор значений для каждого типа.
           Пара     метрами метода Invoke должны быть : объект, имя метода,
                массив параметров.*/
            
            File.WriteAllText("Reflection.txt",String.Empty);
            
            Reflector.WriteAssemblyName("Laba12.Reflector");
            Reflector.WriteIsAnyPublicConstruction("Laba12.Reflector");
            Reflector.WritePublicMethods("Laba12.Reflector");
            Reflector.WriteMethodsWithUserParametr("Laba12.Reflector","currentClassName");
            Reflector.Invoke("Laba12.Sum","Summa");
            
            


        }

        static void ClearFile()
        {
            var fileForInfortmation = new StreamWriter(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba12\Laba12\Reflection.txt", false);
            
            fileForInfortmation.Close();
        }
    }
}
