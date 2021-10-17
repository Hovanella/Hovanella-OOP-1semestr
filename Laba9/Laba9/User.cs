using System;

namespace Laba9
{
    public static class User
    {
        public static event Action<string> OnUpgrade;
        public static event Action OnStartWork;
        public static event Action OnEndWork;

        public static void StartWorkWithSoftware(Software software)
        {
            OnStartWork += software.StartWork;
            OnEndWork += software.EndWork;

            OnStartWork?.Invoke();
        }

        public static void EndWorkWithSoftware(Software software)
        {
            if (software.IsWorking == false)
                throw new ArgumentException("The software is not working now");

            OnEndWork?.Invoke();

            OnStartWork -= software.StartWork;
            OnEndWork -= software.EndWork;
        }

        public static void Upgrade(Software software, string newVersion)
        {
            OnUpgrade += software.ChangeVersion;

            OnUpgrade?.Invoke(newVersion);

            OnUpgrade -= software.ChangeVersion;
        }
    }
}