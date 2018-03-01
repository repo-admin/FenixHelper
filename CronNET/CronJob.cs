using System;
using System.Threading;

namespace UPC.CronNET
{
	/// <summary>
	/// Rozhraní pro CronJob
	/// </summary>
    public interface ICronJob
    {
		/// <summary>
		/// Spustí úlohu
		/// </summary>
		/// <param name="date_time"></param>
        void Execute(DateTime date_time);

		/// <summary>
		/// Pøeruší zpracování spuštìné úlohy
		/// </summary>
        void Abort();
    }

	/// <summary>
	/// 
	/// </summary>
    public class CronJob : ICronJob
    {
        private readonly ICronSchedule _cron_schedule = new CronSchedule();
        private readonly ThreadStart _thread_start;
        private Thread _thread;

		/// <summary>
		/// ctor
		/// </summary>
		/// <param name="schedule"></param>
		/// <param name="thread_start"></param>
        public CronJob(string schedule, ThreadStart thread_start)
        {
            _cron_schedule = new CronSchedule(schedule);
            _thread_start = thread_start;
            _thread = new Thread(thread_start);
        }

        private object _lock = new object();

		/// <summary>
		/// Spustí úlohu
		/// </summary>
		/// <param name="date_time"></param>
        public void Execute(DateTime date_time)
        {
            lock (_lock)
            {
                if (!_cron_schedule.IsTime(date_time))
                    return;

                if (_thread.ThreadState == ThreadState.Running)
                    return;
				                                
                _thread = new Thread(_thread_start);
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
