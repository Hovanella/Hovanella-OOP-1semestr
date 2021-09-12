using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Laba16
{
    class Program
    {
        static void Main(string[] args)
        {
            Task6();
            Console.ReadKey();
        }

        static void Task1()
        {
            /*1. Используя TPL создайте длительную по времени задачу (на основе
           Task) на выбор:
           Задача: решетом эратосфена посчитать кол-во простых чисел от 1 до enumerationBorder
           */
            Task<uint> task = new Task<uint>(() => CountQuantityOfSimpleNumbers(1000));
            Console.WriteLine($"Task #{task.Id} status - {task.Status}");

            Stopwatch stopwatch = new Stopwatch();
            task.Start();
            stopwatch.Start();
            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Task #{task.Id} status - {task.Status}");
            Console.WriteLine($"Task - Method has been working for {stopwatch.ElapsedMilliseconds} ms ");
            Console.WriteLine($"Quantity of simple numbers from 1 to 1000 is {task.Result}");

            stopwatch.Restart();
            CountQuantityOfSimpleNumbers(1000);
            stopwatch.Stop();
            Console.WriteLine($"Main Thread Method has been working for {stopwatch.ElapsedMilliseconds} ms \n");
        }

        static void Task2()
        {
            /*2. Реализуйте второй вариант этой же задачи с токеном отмены
            CancellationToken и отмените задачу.*/
            var cancellationToken = new CancellationTokenSource();

            Task second = Task.Factory.StartNew(CountQuantityOfSimpleNumbersWithCancellingToken, cancellationToken.Token, cancellationToken.Token);
            try
            {
                cancellationToken.Cancel();
                second.Wait();
            }
            catch (AggregateException e)
            {
                if (second.IsCanceled)
                    Console.WriteLine($"{second.Id} task is canceled\n");
            }
        }

        static void Task3()
        {
            /*3. Создайте три задачи с возвратом результата и используйте их для
               выполнения четвертой задачи. Например, расчет по формуле.*/
            Task<int> hundreds = new Task<int>(() => new Random().Next(1, 9) * 100);
            Task<int> dozens = new Task<int>(() => new Random().Next(0, 9) * 10);
            Task<int> units = new Task<int>(() => new Random().Next(0, 9));

            hundreds.Start();
            dozens.Start();
            units.Start();
            units.Wait();
            hundreds.Wait();
            dozens.Wait();

            Task<int> threeDigitNumber = new Task<int>(() => { return hundreds.Result + dozens.Result + units.Result; });
            threeDigitNumber.Start();
            Console.WriteLine($"A three-digit number has been created - {threeDigitNumber.Result}\n");
        }

        static void Task4()
        {
            /*4. Создайте задачу продолжения (continuation task) в двух вариантах:
            1) C ContinueWith - планировка на основе завершения множества
            предшествующих задач
            2) На основе объекта ожидания и методов GetAwaiter(),GetResult();*/

            var sum = new Task<int>(() => 1 + 10 + 100);
            var showSum = sum.ContinueWith(sum => Console.WriteLine(sum.Result));
            sum.Start();


            //TODO в этом куске не уверен 
            var difference = new Task<int>(() => 111 - 100 - 10 - 1);
            var awaiterCountFor = difference.GetAwaiter();
            awaiterCountFor.OnCompleted(() =>
            {
                awaiterCountFor.GetResult();
                Console.WriteLine($"Result is {difference.Result}\n");
            });
            difference.Start();
        }

        static void Task5()
        {
            /*5. Используя Класс Parallel распараллельте вычисления циклов For(),
          ForEach(). Например,на выбор:  обработку (преобразования) последовательности,
          генерация нескольких массивов по 1000000 элементов, быстрая сортировка
          последовательности, обработка текстов  (удаление, замена). 
          Оцените производительность по сравнению с обычными циклами*/


            //TODO задания не слишком понятные,плюс непонятно,что с ForEach делать
            int[] array1 = new int[1000000];
            int[] array2 = new int[1000000];
            int[] array3 = new int[1000000];

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            Parallel.For(0, 1000000, CreatingArrayElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel For {stopwatch.ElapsedMilliseconds} ms");

            stopwatch.Restart();
            for (int i = 0; i < 1000000; i++)
            {
                array1[i] = i;
                array2[i] = i;
                array3[i] = i;
            }

            stopwatch.Stop();
            Console.WriteLine($"Native For {stopwatch.ElapsedMilliseconds} ms");


            stopwatch.Restart();
            Parallel.ForEach(array1, CreatingArrayElements);
            stopwatch.Stop();
            Console.WriteLine($"Parallel ForEach {stopwatch.ElapsedMilliseconds} ms");

            void CreatingArrayElements(int x)
            {
                array1[x] = x;
                array2[x] = x;
                array3[x] = x;
            }
        }

        static void Task6()
        {
            /*6. Используя Parallel.Invoke() распараллельте выполнение блока
            операторов.*/
            int maxCount = 1000;
            int count = 0;
            Parallel.Invoke
            (
                () =>
                {
                    while (count < maxCount)
                    {
                        count++;
                        Console.WriteLine($"1 : {count}");
                    }
                },
                () =>
                {
                    while (count < maxCount)
                    {
                        count++;
                        Console.WriteLine($"2 : {count}");
                    }
                },
                () =>
                {
                    while (count < maxCount)
                    {
                        count++;
                        Console.WriteLine($"3 : {count}");
                    }
                },
                () =>
                {
                    while (count < maxCount)
                    {
                        count++;
                        Console.WriteLine($"4 : {count}");
                    }
                },
                () =>
                {
                    while (count < maxCount)
                    {
                        count++;
                        Console.WriteLine($"5 : {count}");
                    }
                }
            );
        }

        static void Task7()
        {
            /*Есть 5 поставщиков бытовой техники, они завозят уникальные товары
            на склад (каждый по одному) и 10 покупателей – покупают все подряд,
            если товара нет - уходят. В вашей задаче: cпрос превышает
            предложение. Изначально склад пустой. У каждого поставщика своя
            скорость завоза товара. Каждый раз при изменении состоянии склада
            выводите наименования товаров на складе.*/
        }

        static uint CountQuantityOfSimpleNumbers(uint enumerationBorder)
        {
            var numbers = new List<uint>();
            for (var i = 2u; i < enumerationBorder; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                for (var j = 2u; j < enumerationBorder; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return (uint) numbers.Count;
        }

        static uint CountQuantityOfSimpleNumbersWithCancellingToken(object obj)
        {
            var numbers = new List<uint>();
            var token = (CancellationToken) obj;
            for (var i = 2u; i < 1000; i++)
            {
                numbers.Add(i);
            }

            for (var i = 0; i < numbers.Count; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Cancellation Request");
                    token.ThrowIfCancellationRequested();
                    return 0;
                }

                for (var j = 2u; j < 1000; j++)
                {
                    numbers.Remove(numbers[i] * j);
                }
            }

            return (uint) numbers.Count;
        }

        //TODO 7 и 8 задания не сделаны,остальные более менее
    }
}