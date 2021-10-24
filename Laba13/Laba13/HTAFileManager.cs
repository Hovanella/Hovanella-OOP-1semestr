using System;
using System.IO;
using System.IO.Compression;
using System.Linq;

namespace Laba13
{
    public class HTAFileManager
    {
        public static event Action<string> OnUpdate;

        public static void InspectDrive(string driveName)
        {
            Directory.CreateDirectory(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect");

            var currentDrive = DriveInfo.GetDrives().Single(x => x.Name == driveName);
            OnUpdate($"File manager has inspected {currentDrive.Name}");

            File.Create(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAdirinfo.txt").Close();

            using (var streamWriter = new StreamWriter(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAdirinfo.txt"))
            {
                streamWriter.WriteLine("|Directories| [");
                foreach (var directoryInfo in currentDrive.RootDirectory.GetDirectories()) streamWriter.WriteLine(directoryInfo.Name);
                streamWriter.WriteLine("]");

                streamWriter.WriteLine("|Files| [");
                foreach (var fileInfo in currentDrive.RootDirectory.GetFiles()) streamWriter.WriteLine(fileInfo.Name);
                streamWriter.WriteLine("]");
            }

            File.Copy(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAdirinfo.txt",
                @"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAdirinfoCopy.txt", true);
            File.Delete(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAdirinfo.txt");
        }

        public static void CopyFiles(string path, string extension)
        {
            OnUpdate($"File manager has copied {extension} files from {path}");

            var directory = new DirectoryInfo(path);
            Directory.CreateDirectory(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAFiles");

            foreach (var file in directory.GetFiles())
                if (file.Extension == extension)
                    file.CopyTo($@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAFiles\{file.Name}", true);
            Directory.Delete(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAFiles\", true);
            Directory.Move(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAFiles\",
                @"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\HTAInspect\HTAFiles\");
        }

        public static void Archive(string pathFrom, string pathTo)
        {
            OnUpdate($"File manager has archived files from {pathFrom} and unarchived");

            Directory.Delete(@"d:\Образование\3Semester\OOP\OOP1Semestr\Laba13\Laba13\UnarchiveTest\", true);

            if (!File.Exists($@"{pathFrom}.zip"))
                ZipFile.CreateFromDirectory(pathFrom, $@"{pathFrom}.zip");

            ZipFile.ExtractToDirectory($@"{pathFrom}.zip", pathTo);
        }
    }
}