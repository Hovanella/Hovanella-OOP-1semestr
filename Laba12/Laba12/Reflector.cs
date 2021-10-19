using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Laba3;
using Laba6;

namespace Laba12
{
    public static class Reflector
    {
        private static StreamWriter fileForInfortmation=null;
        private static StreamReader fileForInvoke=null;

        private static readonly string fileForInfortmationPath = @"D:\Образование\3Semester\OOP\OOP1Semestr\Laba12\Laba12\Reflection.txt";
        private static readonly string fileForInvokePath = @"D:\Образование\3Semester\OOP\OOP1Semestr\Laba12\Laba12\Invoke.txt";


        //TODO проверить методы и добавить флаги,также вроде не работает метод WriteMethodsWithUserParametr
        public static void WriteAssemblyName(string currentClassName)
        {
            string assemblyName = GetAssemblyName(Type.GetType(currentClassName, true, true));
            OpenFile();
            fileForInfortmation.WriteLine($"Current Class is {currentClassName}. Current Class Assembly Name is {assemblyName}");
            CloseFile();
        }

        public static void WriteIsAnyPublicConstruction(string currentClassName)
        {
            bool isAnyPublicConstruction = IsAnyPublicConstruction(Type.GetType(currentClassName, true, false));
            OpenFile();
            fileForInfortmation.WriteLine($"Contains public Constructions : {isAnyPublicConstruction}");
            CloseFile();
        }

        public static void WritePublicMethods(string currentClassName)
        {
            IEnumerable<string> publicMethod = new List<string>(GetPublicMethods(Type.GetType(currentClassName, true, false)));

            OpenFile();
            fileForInfortmation.WriteLine("Public Methods List");
            foreach (string item in publicMethod) fileForInfortmation.WriteLine(item);
            CloseFile();
        }

        public static void WriteFieldsAndProperties(string currentClassName)
        {
            IEnumerable<string> FieldsAndProperties = new List<string>(GetFieldsAndProperties(Type.GetType(currentClassName, true, false)));
            OpenFile();
            fileForInfortmation.WriteLine("Fields And Properties List");
            foreach (string item in FieldsAndProperties) fileForInfortmation.WriteLine(item);
            CloseFile();
        }

        public static void WriteInterfaces(string currentClassName)
        {
            IEnumerable<string> interfaces = new List<string>(GetInterfaces(Type.GetType(currentClassName, true, false)));

            OpenFile();
            fileForInfortmation.WriteLine("Interfaces Methods List");
            foreach (string item in interfaces) fileForInfortmation.WriteLine(item);
            CloseFile();
        }

        public static void WriteMethodsWithUserParametr(string currentClassName, string parametr)
        {
            IEnumerable<string> methodsWithUserParametr =
                new List<string>(GetMethodsWithUserParametr(Type.GetType(currentClassName, true, false), parametr));
            OpenFile();
            fileForInfortmation.WriteLine($"Methods with user user parametr({parametr}):");
            foreach (string item in methodsWithUserParametr) fileForInfortmation.WriteLine(item);
            CloseFile();
        }
        
        
        // 2. Добавьте в Reflector обобщенный метод Create, который создает объект
        // переданного типа (на основе имеющихся публичных конструкторов) и возвращает
        // его пользователю.
        public static object Create(string currentClassName)
        {
            return Activator.CreateInstance(Type.GetType(currentClassName));
        }
        
        // TODO метод Invoke, который вызывает метод класса, при этом значения для его параметров необходимо
        // 1) прочитать из текстового файла(имя класса и имя метода передаются в качестве аргументов)
        // 2)сгенерировать, используя генератор значений для каждого типа.
        // Параметрами метода Invoke должны быть : объект, имя метода, массив параметров.
        public static void Invoke(string currentClassName, string currentMethodName)
        {
            {
                var classType = Type.GetType(currentClassName, false, true);
                object obj = Activator.CreateInstance(classType);
                var methodInfo = classType.GetMethod(currentMethodName);
                fileForInvoke = new StreamReader(fileForInvokePath);
                object result = methodInfo.Invoke(obj, new object[] {int.Parse(fileForInvoke.ReadLine()), int.Parse(fileForInvoke.ReadLine())});
                Console.WriteLine($"Invoke: {result}");
                fileForInvoke.Close();
            }
        }


        private static void OpenFile()
        {
            if (fileForInfortmationPath != null)
                fileForInfortmation = new StreamWriter(fileForInfortmationPath, true);
        }
        private static void CloseFile()
        {
            fileForInfortmation.WriteLine("-------------------------------------------------");
            fileForInfortmation?.Close();
        }
        
        //a. Определение имени сборки, в которой определен класс;
        private static string GetAssemblyName(Type CurrentClass)
        {
            return CurrentClass.Assembly.ToString();
        }

        //b. есть ли публичные конструкторы;
        private static bool IsAnyPublicConstruction(Type CurrentClass)  
        {
            foreach (var item in CurrentClass.GetConstructors(BindingFlags.Public))
                if (item.IsPublic)
                    return true;
            return false;
        }

        //c. извлекает все общедоступные публичные методы класс (возвращает IEnumerable<string>);
        private static IEnumerable<string>
            GetPublicMethods(Type CurrentClass)
        {
            //TODO вроде правильный вывод,но из-за типа Type есть дополнительные методы,неясно можно ли сделать правильнее
            var publicMethods = new List<string>();
            foreach (var item in CurrentClass.GetMethods(BindingFlags.Public| BindingFlags.Instance))
                if (item.IsPublic)
                    publicMethods.Add(item.ToString());
            return publicMethods;
        }

        //d. получает информацию о полях и свойствах класса (возвращает IEnumerable<string>);
        private static IEnumerable<string> GetFieldsAndProperties(Type CurrentClass)
        {
            return new List<string> {CurrentClass.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).ToString(), CurrentClass.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).ToString()};
        }

        //e. получает все реализованные классом интерфейсы (возвращает IEnumerable<string>);
        private static IEnumerable<string>
            GetInterfaces(Type CurrentClass)
        {
            var interfaces = new List<string>();
            foreach (var item in CurrentClass.GetInterfaces())
                if (item.IsPublic)
                    interfaces.Add(item.ToString());
            return interfaces;
        }

        //f. выводит по имени класса имена методов, которые содержат заданный (пользователем) тип параметра (имя класса передается в качестве аргумента);
        private static IEnumerable<string> GetMethodsWithUserParametr(Type CurrentClass, string userParametr)
        {
            var methodsWithUserParametr = new List<string>();
            var currentClassMethods = CurrentClass.GetMethods();
           
            
            foreach (var item in currentClassMethods)
            {
                var itemParameters = item.GetParameters();
                
                if (itemParameters.Length == 0)
                {
                    if(userParametr=="")
                        methodsWithUserParametr.Add(item.ToString());
                    continue;
                }
                
                if (itemParameters.Any(param => param.Name == userParametr))
                    methodsWithUserParametr.Add(item.ToString());
            }
                
            return methodsWithUserParametr;
        }
    }
}