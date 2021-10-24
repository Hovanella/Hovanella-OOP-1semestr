using System;
using System.IO;
using System.Text;

namespace Laba13
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            HTADiskInfo.OnUpdate += HTALog.WriteInTXT;
            HTAFileInfo.OnUpdate += HTALog.WriteInTXT;
            HTADirInfo.OnUpdate += HTALog.WriteInTXT;
            HTAFileManager.OnUpdate += HTALog.WriteInTXT;

            HTADiskInfo.ShowFreeSpace(@"D:\");
            HTADiskInfo.ShowFileSystemInfo(@"C:\");
            HTADiskInfo.ShowAllDrivesInfo();

            HTAFileInfo.ShowFullPath(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt");
            HTAFileInfo.ShowFileInfo(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt");
            HTAFileInfo.ShowFileDates(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt");

            HTADirInfo.ShowCreationTime(@"d:\Образование\3Semester");
            HTADirInfo.ShowNumberOfFiles(@"d:\Образование\3Semester");
            HTADirInfo.ShowNumberOfSubdirectories(@"d:\Образование\3Semester");
            HTADirInfo.ShowParentDirectory(@"d:\Образование\3Semester");

            HTAFileManager.InspectDrive(@"D:\");
            HTAFileManager.CopyFiles(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\", ".cs");
            HTAFileManager.Archive(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Archivetest",
                @"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Unarchivetest");
            FindInfo();
        }

        public static void FindInfo()
        {
            //Немного шиткода и танцев с бубном ради странного функционала,но его люди обычно вообще не делают,так что я хоть попытался и оно працуе 
            var output = new StringBuilder();

            using (var stream = new StreamReader(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt"))
            {
                var textline = "";
                var isActual = false;
                while (stream.EndOfStream == false)
                {
                    isActual = false;
                    textline = stream.ReadLine();
                    if (textline != "" && DateTime.Parse(textline).Day == DateTime.Now.Day)
                    {
                        isActual = true;
                        textline += "\n";
                        output.AppendFormat(textline);
                    }

                    textline = stream.ReadLine();
                    while (textline != "------------------------------")
                    {
                        if (isActual)
                        {
                            textline += "\n";
                            output.AppendFormat(textline);
                        }

                        textline = stream.ReadLine();
                    }

                    if (isActual) output.AppendFormat("------------------------------\n");
                }
            }

            using (var stream = new StreamWriter(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\Log.txt"))
            {
                stream.WriteLine(output.ToString());
            }
        }
    }
}