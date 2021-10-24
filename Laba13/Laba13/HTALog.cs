using System;
using System.IO;

namespace Laba13
{
    /*1.Создать класс XXXLog. Он должен отвечать за работу с текстовым файломxxxlogfile.txt.в который записываются все действия пользователя и соответственно методами записи в текстовый файл, чтения, поиска нужной информации.a.Используя данный класс выполните запись всех последующих действиях пользователя с указанием действия, детальной информации (имя файла, путь) и времени (дата/время)*/
    public static class HTALog
    {
        public static void WriteInTXT(string message)
        {
            using (var stream = new StreamWriter(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt", true))
            {
                stream.WriteLine($"{DateTime.Now.ToString()}\n{message}\n------------------------------");
            }
        }
    }
}