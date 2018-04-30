using System;
using System.Threading;

namespace Fenix.CronNET
{
    /// <summary>
	/// Reprezentuje pracovn� �lohu
	/// </summary>
    public class CronJob : ICronJob
    {
        /// <summary>
        /// Instance pl�nova�e �loh
        /// </summary>
        private readonly ICronSchedule _cronSchedule;
        /// <summary>
        /// Deleg�t typu ThreadStart
        /// </summary>
        private readonly ThreadStart _threadStart;
        /// <summary>
        /// Instance b��c�ho vl�kna
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// Inicializuje novou instance t��dy CronJob
        /// </summary>
        private CronJob() { }

        /// <summary>
        /// Inicializuje novou instanci t��dy CronJob
        /// </summary>
        /// <param name="schedule">Pl�nova�</param>
        /// <param name="threadStart"></param>
        public CronJob(string schedule, ThreadStart threadStart)
        {
            _cronSchedule = new CronSchedule(schedule);
            _threadStart = threadStart;
            _thread = new Thread(threadStart);
        }

        /// <summary>
        /// Synchroniza�n� objekt
        /// </summary>
        private readonly object _lock = new object();

		/// <summary>
		/// Spust� �lohu
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
		/// P�eru�� zpracov�n� spu�t�n� �lohy
		/// </summary>
        public void Abort()
        {
          _thread.Abort();  
        }
    }
}
