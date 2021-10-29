using System;
using System.IO;

namespace Laba7.Exceptions
{
    public class Logger
    {
        public static void LogErrorinFile(Exception e)
        {
            using var stream = new StreamWriter(@"D:\Образование\3Semester\OOP\OOP1Semestr\Laba7\Laba7\Log.txt", true);
            stream.WriteLine($"Time: {DateTime.Now}");
            stream.WriteLine($"Info: {e.GetType()} - {e.Message}\n");
        }

        public static void LogErrorinConsole(Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"Time: {DateTime.Now}");
            Console.WriteLine($"Info: {e.GetType()} - {e.Message}");
        }
    }
}