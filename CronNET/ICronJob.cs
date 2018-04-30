using System;

namespace Fenix.CronNET {
    /// <summary>
    /// Definice rozhran� pro CronJob
    /// </summary>
    public interface ICronJob
    {
        /// <summary>
        /// Spust� �lohu
        /// </summary>
        /// <param name="dateTime"></param>
        void Execute(DateTime dateTime);

        /// <summary>
        /// P�eru�� zpracov�n� spu�t�n� �lohy
        /// </summary>
        void Abort();
    }
}