using System;
using System.IO;

namespace Laba13
{
    public class HTAFileInfo
    {
        public static event Action<string> OnUpdate;

        public static void ShowFullPath(string path)
        {
            var currentFile = new FileInfo(path);

            Console.WriteLine($"Full path to the {currentFile.Name} - {currentFile.FullName}");
            OnUpdate($"Full path to the {currentFile.Name} - {currentFile.FullName}");
        }

        public static void ShowFileInfo(string path)
        {
            var currentFile = new FileInfo(path);

            Console.WriteLine($"[\nFile name: {currentFile.Name}\nSize: {currentFile.Length} bytes\nРасширение: {currentFile.Extension}\n]");

            OnUpdate($"[\nFile name: {currentFile.Name}\nSize: {currentFile.Length} bytes\nFile extension: {currentFile.Extension}\n]\n");
        }

        public static void ShowFileDates(string path)
        {
            var currentFile = new FileInfo(path);
            Console.WriteLine(
                $"File {currentFile.Name} : date of creation - {currentFile.CreationTime}, date of last edit - {currentFile.LastWriteTime}");
            OnUpdate($"File {currentFile.Name} : date of creation - {currentFile.CreationTime}, date of last edit - {currentFile.LastWriteTime}");
        }
    }
}