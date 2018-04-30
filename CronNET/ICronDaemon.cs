using System.Threading;

namespace Fenix.CronNET {
    /// <summary>
    /// Definice rozhraní pro CronDaemon
    /// </summary>
    public interface ICronDaemon
    {
        /// <summary>
        /// Pøidání jobu
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="action"></param>
        void AddJob(string schedule, ThreadStart action);

        /// <summary>
        /// Spuštìní jobu
        /// </summary>
        void Start();

        /// <summary>
        /// Zastavení jobu
        /// </summary>
        void Stop();
    }
}