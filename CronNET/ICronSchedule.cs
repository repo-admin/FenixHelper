using System;

namespace Fenix.CronNET {
    /// <summary>
    /// Definice rozhraní pro CronSchedule
    /// </summary>
    public interface ICronSchedule
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        bool IsValid(string expression);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        bool IsTime(DateTime dateTime);
    }
}