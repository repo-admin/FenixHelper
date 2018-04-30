using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Timers;
using Fenix.MultimediaTimer;

namespace Fenix.CronNET
{
    /// <summary>
	/// 
	/// </summary>
    public class CronDaemon : ICronDaemon
    {
        [DllImport("winmm.dll", EntryPoint = "timeGetTime")]
        private static extern uint MM_GetTime();

		private readonly MultimediaTimer.MultimediaTimer timer = new MultimediaTimer.MultimediaTimer();

        private readonly List<ICronJob> cron_jobs = new List<ICronJob>();
        private DateTime _last = DateTime.Now;
        private DateTime start;
        private uint first = 0;

		/// <summary>
		/// ctor
		/// </summary>
        public CronDaemon()
        {
            timer.Mode = TimerMode.Periodic;
            timer.Period = 60000;
            timer.Tick += new EventHandler(timer_Tick);
        }

		/// <summary>
		/// Pøidání jobu
		/// </summary>
		/// <param name="schedule"></param>
		/// <param name="action"></param>
        public void AddJob(string schedule, ThreadStart action)
        {
            var cj = new CronJob(schedule, action);
            cron_jobs.Add(cj);
        }

		/// <summary>
		/// Start
		/// </summary>
        public void Start()
        {
            do
            {
                start = DateTime.Now;
            } while (start.Second != 0);

            first = MM_GetTime();

            timer.Start();
        }

		/// <summary>
		/// Stop
		/// </summary>
        public void Stop()
        {
            timer.Stop();

			foreach (CronJob job in cron_jobs)
			{ 
				job.Abort(); 
			}
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            uint last = MM_GetTime();
            if (last - first >= 60000)
            {
				foreach (ICronJob job in cron_jobs)
				{ 
					job.Execute(DateTime.Now); 
				}
            }
        }
        
        private void timer_elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Minute != _last.Minute)
            {
                _last = DateTime.Now;
				foreach (ICronJob job in cron_jobs)
				{ 
					job.Execute(DateTime.Now); 
				}
            }
        }
    }
}
