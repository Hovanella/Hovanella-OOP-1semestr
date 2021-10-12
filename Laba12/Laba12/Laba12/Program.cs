using System;
using System.IO;

namespace Laba12
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            File.WriteAllText("Reflection.txt",String.Empty);
            
            Reflector.WriteAssemblyName("Laba12.Reflector");
            Reflector.WriteIsAnyPublicConstruction("Laba12.Reflector");
            Reflector.WritePublicMethods("Laba12.Reflector");
            Reflector.WritePublicMethods("Laba12.Reflector"); 
            Reflector.WriteMethodsWithUserParametr("Laba12.Reflector","CurrentClassName");
            Reflector.Invoke("Laba12.Sum","Summa");
          
            
            // TODO Продемонстрируйте работу «Рефлектора» для исследования типов на созданныхвами классах не менее двух (предыдущие лабораторные работы) и стандартных классах .Net.
        }
    }
}