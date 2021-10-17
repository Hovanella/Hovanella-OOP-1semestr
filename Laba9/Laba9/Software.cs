using System;

namespace Laba9
{
    public class Software
    {
        public Software()
        {
        }

        public Software(string name)
        {
            Name = name;
        }

        public string Name { get; set; } = "Default";
        public string Version { get; set; } = "1.0";
        public bool IsWorking { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"{Name} has version {Version}. It is working now - {IsWorking}");
        }

        public void ChangeVersion(string newVersion)
        {
            Version = newVersion;
        }

        public void StartWork()
        {
            IsWorking = true;
        }

        public void EndWork()
        {
            IsWorking = false;
        }
    }
}