using System.Threading;

namespace Fenix.CronNET {
    /// <summary>
    /// Definice rozhran� pro CronDaemon
    /// </summary>
    public interface ICronDaemon
    {
        /// <summary>
        /// P�id�n� jobu
        /// </summary>
        /// <param name="schedule"></param>
        /// <param name="action"></param>
        void AddJob(string schedule, ThreadStart action);

        /// <summary>
        /// Spu�t�n� jobu
        /// </summary>
        void Start();

        /// <summary>
        /// Zastaven� jobu
        /// </summary>
        void Stop();
    }
}