using System;
using System.Diagnostics;
using Laba7.Exceptions;

namespace Laba7
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            MainTask();
            Dop();
        }
        private static void Dop()
        {
            /*1.  Создайте  класс Logger,  который  будет  заниматься  логгированием различных  событий  и  исключений.  Логгер  должен  уметь  логгировать ошибки/исключения, предупреждения и просто какую-то информацию.
             Логгер  должен  записывать  лог  в  виде:  время,  тип_записи_лога: дополнительное сообщение. 27.10.2019 02:36, INFO: Test log message.*/
            try
            {
                new Bench("A", 20000000);
            }
            catch (CostExeption e)
            {
                Logger.LogErrorinFile(e);
                Logger.LogErrorinConsole(e);
            }
        }

        private static void MainTask()
        {
            /*Дополнить предыдущую лабораторную работу No 6. Создать иерархию классов исключений (собственных)–3 типа и более.Сделать  наследование  пользовательских  типов  исключений  от стандартных классов .Net(например,Exception,IndexOutofRange).https://docs.microsoft.com/en-us/dotnet/api/system.exception?view=netframework-4.8
             Сгенерировать и обработать как минимум пять различных исключительных ситуацийна основе своих и стандартных исключений. Например, не позволять при инициализации объектов передавать неверные данные, обрабатывать ошибкипри работе с памятью и ошибки работы с файлами, деление на ноль, неверный индекс, нулевой указатель и т. д.
             В конце поставить универсальный обработчик catch.Обработку  исключений  вынести  в main.  При  обработке  выводить специфическую  информацию  о  месте,  диагностикуи  причине  исключения. 
             Последним должен быть блок, который отлавливает все исключения(finally).
             Добавьте кодв одной из функций макрос Assert. Объяснитечто он проверяет, как будет выполняться программа в случае не выполнения условия. Объясните назначение Assert*/
            
            
            try
            {
                new Bench("A", 20000000);
            }
            catch (CostExeption e)
            {
                Console.WriteLine($"{e.Message}, Cost - {e.Cost}");
               
            }

            try
            {
                new Bench("Bars", 1000);
            }
            catch (InventoryException e)
            {
                Console.WriteLine($"{e.Message}");
            }
            
            try
            {
                new TennisBall("ball", 6668);
            }
            catch (BallException e)
            {
                Console.WriteLine($"{e.Message} , type - {e.ErrorClass}");
            }

            try
            { 
                new Ball().SayHelloWorld();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                new Gym(0, 5, new Ball());
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);

            }
            finally
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Finally");
            }
            
           // Debug.Assert(false);
            
        }
        
        /*4.TODO  Добавьте в классы из л.р. 6 логгер так, чтобы его возможно было быстро заменить  во  время  выполнения  другим  и  вместо  простого  вывода  на  консоль сообщения об ошибке, используйте свой логгер.*/

    }
}