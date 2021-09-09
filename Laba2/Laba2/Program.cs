using System;
using System.Linq;
using System.Text;
//BRUH
namespace Laba2
{
    internal static class Program
    {
        private static void Main()
        {
            //Types();
            // Strings();
            // Arrays();
            // Tuples();
            // Console.WriteLine(LocalFunction());
            // FunctionWithChecked();
            FunctionWithUnchecked();
            Console.ReadKey();
        }

        private static void Types()
        {
            //a
            var boolVar = false;
            byte byteVar = 1;
            sbyte sbyteVar = -1;
            var charVar = 'a';
            var decimalVar = decimal.MaxValue;
            var doubleVar = 1.32;
            var floatVar = 1.32f;
            int intVar = -123;
            uint uintVar = 123;
            var nintVar = nint.MinValue;
            var nuintVar = nuint.MinValue;
            var longVar = long.MaxValue;
            var ulongVar = ulong.MaxValue;
            var shortVar = short.MaxValue;
            var ushortVar = ushort.MaxValue;
            var stringVar = "AAA";
            object objectVar = null;

            Console.WriteLine(
                $"boolVar - {boolVar}\nbyteVar - {byteVar}\nsbyteVar -{sbyteVar}\ncharVar - {charVar}\ndecimalVar - {decimalVar}\ndoubleVar - {doubleVar}\nfloatVar - {floatVar}\nintVar - {intVar}\nuintVar - {uintVar}\nnintVar -{nintVar}\nnuintVAr - {nuintVar}\nlongVar - {longVar}\nulongVar - {ulongVar}\nshortVar - {shortVar}\nushortVar - {ushortVar}\nstringVar - {stringVar}\nobjectVar - {objectVar}");

            Console.WriteLine("-------------");

            boolVar = bool.Parse(Console.ReadLine());
            byteVar = byte.Parse(Console.ReadLine());
            sbyteVar = sbyte.Parse(Console.ReadLine());
            charVar = char.Parse(Console.ReadLine());
            decimalVar = decimal.Parse(Console.ReadLine());
            doubleVar = double.Parse(Console.ReadLine());
            floatVar = float.Parse(Console.ReadLine());
            intVar = int.Parse(Console.ReadLine());
            uintVar = uint.Parse(Console.ReadLine());
            nintVar = nint.Parse(Console.ReadLine());
            nuintVar = nuint.Parse(Console.ReadLine());
            longVar = long.Parse(Console.ReadLine());
            ulongVar = ulong.Parse(Console.ReadLine());
            shortVar = short.Parse(Console.ReadLine());
            ushortVar = ushort.Parse(Console.ReadLine());
            stringVar = Console.ReadLine();
            objectVar = Console.ReadLine();

            Console.WriteLine("-------------");
            Console.WriteLine(
                $"boolVar - {boolVar}\nbyteVar - {byteVar}\nsbyteVar -{sbyteVar}\ncharVar - {charVar}\ndecimalVar - {decimalVar}\ndoubleVar - {doubleVar}\nfloatVar - {floatVar}\nintVar - {intVar}\nuintVar - {uintVar}\nnintVar -{nintVar}\nnuintVAr - {nuintVar}\nlongVar - {longVar}\nulongVar - {ulongVar}\nshortVar - {shortVar}\nushortVar - {ushortVar}\nstringVar - {stringVar}\nobjectVar - {objectVar}");

            //b

            //Explicit Casting
            intVar = 'a';
            charVar = (char) intVar;
            shortVar = (short) ushortVar;
            longVar = intVar;
            doubleVar = floatVar;

            Console.WriteLine(
                $"intVar - {intVar}\ncharVar - {charVar}\nshortVar - {shortVar}\nlongVar - {longVar}\ndoubleVar - {doubleVar}\n----------\n");

            //Implicit Casting
            intVar = charVar;
            longVar = intVar;
            doubleVar = floatVar;
            decimalVar = intVar;
            floatVar = intVar;

            Console.WriteLine(
                $"intVar - {intVar}\nlongVar - {longVar}\nlongVar - {longVar}\ndoubleVar - {doubleVar}decimalVar - {decimalVar}\nfloatVar - {floatVar}\n----------\n");


            //c and d

            //Boxing and Unboxing(using Var)
            var intObj = new object();
            intObj = intVar;
            intObj = 15;
            intVar = (int) intObj;

            //e 

            //Nullable;
            int? intNullableVar = null;
            if (intNullableVar.HasValue)
                Console.WriteLine(intNullableVar.Value);
            else
                intNullableVar = 666;

            //f

            //Error with Var

            // var check = true;
            // check = 14;
        }

        private static void Strings()
        {
            //a

            var stringFirstVar = "I ";
            var stringSecondVar = "Love ";
            var stringThirdVar = "OOP";
            var stringFourthVar = "My house is here";

            Console.WriteLine($"{stringFirstVar == stringSecondVar}");

            //b

            Console.WriteLine($"{string.Concat(stringFirstVar, stringSecondVar, stringThirdVar)} - concatenation");

            Console.WriteLine($"{string.Copy(stringSecondVar)} - copying");

            Console.WriteLine($"{stringSecondVar.Substring(0, 3)} - substring");

            string[] Words = stringFourthVar.Split(new[] {' '});
            foreach (string word in Words) Console.Write($"{word} | ");

            Console.WriteLine($"\nInsert:{stringFirstVar.Insert(2, stringSecondVar)}");
            Console.WriteLine($"Remove:{stringFourthVar.Remove(0, 9)}");
            
            //TODO интерполяцию забыл,но я её постоянно использую по коду,так что норм

            //c

            var stringEmptyVar = string.Empty;
            string stringNullVar = null;
            var stringWhiteSpaceVar = "    ";

            Console.WriteLine($"{string.IsNullOrEmpty(stringEmptyVar)}");
            Console.WriteLine($"{string.IsNullOrEmpty(stringNullVar)}");
            Console.WriteLine($"{string.IsNullOrWhiteSpace(stringEmptyVar)}");
            Console.WriteLine($"{string.IsNullOrWhiteSpace(stringNullVar)}");
            Console.WriteLine($"{string.IsNullOrWhiteSpace(stringWhiteSpaceVar)}");

            //d
            var stringBuilderVar = new StringBuilder(" travels 123 fastest who travels");
            stringBuilderVar.Append(" alone ");
            stringBuilderVar.Insert(0, "He");
            stringBuilderVar.Remove(11, 4);
            Console.WriteLine(stringBuilderVar);
        }

        private static void Arrays()
        {
            //a

            var arr = new int[3, 3]
            {
                {1, 2, 3},
                {5, 6, 7},
                {9, 10, 11}
            };
            Console.WriteLine("double array: ");
            for (var i = 0; i < arr.GetLength(0); i++)
            {
                for (var j = 0; j < arr.GetLength(1); j++) Console.Write($"{arr[i, j]}  ");
                Console.WriteLine();
            }

            //b
            var stringArr = new[] {"AAA", "BBB", "CCC"};
            foreach (string item in stringArr) Console.Write($"{item} | ");

            Console.WriteLine($"\n Length of array - {stringArr.Length}");


            Console.Write("Input number elem for replace: ");
            int number = int.Parse(Console.ReadLine());
            if (number >= stringArr.Length)
                throw new ArgumentOutOfRangeException();

            Console.Write("Input new elem of array: ");
            string newElem = Console.ReadLine();

            for (var i = 0; i < stringArr.Length; i++)
                if (i == number)
                    stringArr[i] = newElem;
            foreach (string item in stringArr) Console.Write($"{item} | ");
            
            Console.WriteLine();
            //c
            int[][] arr2 = new int[3][];
            arr2[0] = new int[2];
            arr2[1] = new int[3];
            arr2[2] = new int[4];
            
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    arr2[i][j] = int.Parse(Console.ReadLine());
                }
                Console.WriteLine();
            }
            
            for (int i = 0; i < arr2.Length; i++)
            {
                for (int j = 0; j < arr2[i].Length; j++)
                {
                    Console.Write($"{arr2[i][j]} ");
                }
                Console.WriteLine();
            }
            
            //d 

            var arrayVar = new int[] {1, 2, 3, 4};
            var stringVar = "absc";

        }

        private static void Tuples()
        {
            //a
            (int, string, char, string, ulong) tupleFirstVar = (-7, "BBBB", 't', "AAAA", 66666);
            (int, string, char, string, ulong) tupleSecondVar = (-3, "BBBB", 't', "AAAA", 66666);
            
            //b
            Console.WriteLine(tupleFirstVar);
            Console.WriteLine(tupleFirstVar.Item1);
            Console.WriteLine(tupleFirstVar.Item3);
            Console.WriteLine(tupleFirstVar.Item4);
            
            //c
            int intVar = tupleFirstVar.Item1;
            string stringFirstVar = tupleFirstVar.Item2;
            char charVar = tupleFirstVar.Item3;
            string stringSecondVar = tupleFirstVar.Item4;
            ulong ulongVar = tupleFirstVar.Item5;

            (intVar, stringFirstVar, charVar, stringSecondVar, ulongVar) = tupleFirstVar;
            
            //TODO Продемонстрируйте использование переменной ( _ ). (доступно начиная с C#7.3) 
            
            //d 
            Console.WriteLine($"{tupleFirstVar==tupleSecondVar}");
        }
        
        private static (int, int, int, char) LocalFunction()
        {
            int[] arrVar = new int[] { 5,3,12,42,-23 };
            string strVar = "ABCD";
            int maxArrayElement = arrVar.Max();
            int minArrayElement = arrVar.Min();
            int arrayElementsSum = arrVar.Sum();
            char firstStringChar = strVar[0];
            return  (maxArrayElement,minArrayElement,arrayElementsSum,firstStringChar); 
        }

        private static void FunctionWithChecked()
        {
            checked
            {
                int intVar = int.MaxValue;
                intVar++;
                Console.WriteLine(intVar);
            }
        }
        
        private static void FunctionWithUnchecked()
        {
            unchecked
            {
                int intVar = int.MaxValue;
                intVar++;
                Console.WriteLine(intVar);
            }
        }
        
    }
}