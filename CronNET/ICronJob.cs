using System;

namespace Fenix.CronNET {
    /// <summary>
    /// Definice rozhraní pro CronJob
    /// </summary>
    public interface ICronJob
    {
        /// <summary>
        /// Spustí úlohu
        /// </summary>
        /// <param name="dateTime"></param>
        void Execute(DateTime dateTime);

        /// <summary>
        /// Pøeruší zpracování spuštìné úlohy
        /// </summary>
        void Abort();
    }
}