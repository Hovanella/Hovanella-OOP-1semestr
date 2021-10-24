using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Laba13
{
    /*2.Создать класс XXXDiskInfoc методами для вывода информации оa.свободном месте на дискеb.Файловой системеc.Для каждого существующего диска  -имя, объем, доступный объем, метка тома.d.Продемонстрируйте работу класса*/
    public static class HTADiskInfo
    {
        public static event Action<string> OnUpdate;

        public static void ShowFreeSpace(string driveName)
        {
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            Console.WriteLine($"Free space on the disk {currentDrive.Name} - {currentDrive.AvailableFreeSpace} bytes ");
            OnUpdate($"Free space on the disk {currentDrive.Name} - {currentDrive.AvailableFreeSpace} bytes ");
        }

        public static void ShowFileSystemInfo(string driveName)
        {
            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            Console.WriteLine($"File system type and drive format of  {driveName} : {currentDrive.DriveType}, {currentDrive.DriveFormat}");
            OnUpdate($"File system type and drive format of  {driveName} : {currentDrive.DriveType}, {currentDrive.DriveFormat}");
        }

        public static void ShowAllDrivesInfo()
        {
            var message = new StringBuilder("All drives information : \n");
            Console.WriteLine("[");
            message.AppendFormat("[\n");
            foreach (var currentDrive in DriveInfo.GetDrives())
            {
                if (currentDrive.IsReady == false)
                    continue;

                Console.WriteLine(
                    $"Name - {currentDrive.Name},Total size - {currentDrive.TotalSize},Free space - {currentDrive.AvailableFreeSpace} , Volume label - {currentDrive.VolumeLabel}");

                message.AppendFormat(
                    $"Name - {currentDrive.Name},Total size - {currentDrive.TotalSize},Free space - {currentDrive.AvailableFreeSpace} , Volume label - {currentDrive.VolumeLabel}]\n");
            }

            Console.WriteLine("]");
            message.AppendFormat("]\n");
            OnUpdate(message.ToString());
        }
    }
}