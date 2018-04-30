using System;
using System.Threading;

namespace Fenix.CronNET
{
    /// <summary>
	/// Reprezentuje pracovní úlohu
	/// </summary>
    public class CronJob : ICronJob
    {
        /// <summary>
        /// Instance plánovaèe úloh
        /// </summary>
        private readonly ICronSchedule _cronSchedule;
        /// <summary>
        /// Delegát typu ThreadStart
        /// </summary>
        private readonly ThreadStart _threadStart;
        /// <summary>
        /// Instance bìžícího vlákna
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// Inicializuje novou instance tøídy CronJob
        /// </summary>
        private CronJob() { }

        /// <summary>
        /// Inicializuje novou instanci tøídy CronJob
        /// </summary>
        /// <param name="schedule">Plánovaè</param>
        /// <param name="threadStart"></param>
        public CronJob(string schedule, ThreadStart threadStart)
        {
            _cronSchedule = new CronSchedule(schedule);
            _threadStart = threadStart;
            _thread = new Thread(threadStart);
        }

        /// <summary>
        /// Synchronizaèní objekt
        /// </summary>
        private readonly object _lock = new object();

		/// <summary>
		/// Spustí úlohu
		/// </summary>
		/// <param name="dateTime"></param>
        public void Execute(DateTime dateTime)
        {
            lock (_lock)
            {
                if (!_cronSchedule.IsTime(dateTime))
                    return;

                if (_thread.ThreadState == ThreadState.Running)
                    return;
				                                
                _thread = new Thread(_threadStart);
                _thread.Start();
            }
        }

		/// <summary>
		/// Pøeruší zpracování spuštìné úlohy
		/// </summary>
        public void Abort()
        {
          _thread.Abort();  
        }
    }
}
