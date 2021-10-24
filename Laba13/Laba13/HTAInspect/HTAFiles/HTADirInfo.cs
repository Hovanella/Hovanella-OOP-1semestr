using System;
using System.IO;

namespace Laba13
{
    public static class HTADirInfo
    {
        public static event Action<string> OnUpdate;

        public static void ShowNumberOfFiles(string path)
        {
            Console.WriteLine($"The number of files - {Directory.GetFiles(path).Length}");
            OnUpdate($"The number of files - {Directory.GetFiles(path).Length}");
        }

        public static void ShowCreationTime(string path)
        {
            Console.WriteLine($"Time of the directory creation - {Directory.GetCreationTime(path)}");
            OnUpdate($"Time of the directory creation - {Directory.GetCreationTime(path)}");
        }

        public static void ShowNumberOfSubdirectories(string path)
        {
            Console.WriteLine($"Number of subdirectories - {Directory.GetDirectories(path).Length}");
            OnUpdate($"Number of subdirectories - {Directory.GetDirectories(path).Length}");
        }

        public static void ShowParentDirectory(string path)
        {
            Console.WriteLine($"Parent Directory - {Directory.GetParent(path)}");
            OnUpdate($"Parent Directory - {Directory.GetParent(path)}");
        }
    }
}