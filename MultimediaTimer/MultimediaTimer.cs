#region License

/* Copyright (c) 2006 Leslie Sanford
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy 
 * of this software and associated documentation files (the "Software"), to 
 * deal in the Software without restriction, including without limitation the 
 * rights to use, copy, modify, merge, publish, distribute, sublicense, and/or 
 * sell copies of the Software, and to permit persons to whom the Software is 
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in 
 * all copies or substantial portions of the Software. 
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR 
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, 
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE 
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER 
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, 
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN 
 * THE SOFTWARE.
 */

#endregion

#region Contact

/*
 * Leslie Sanford
 * Email: jabberdabber@hotmail.com
 */

#endregion

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Fenix.MultimediaTimer
{
    /// <summary>
    ///     Represents the Windows multimedia timer.
    /// </summary>
    public sealed class MultimediaTimer : IComponent
    {
        #region IDisposable Members

        /// <summary>
        ///     Uvol�uje prost�edky dr�en� �asova�em
        /// </summary>
        public void Dispose()
        {
            #region Guard

            if (_disposed)
                return;

            #endregion

            if (IsRunning)
                Stop();

            _disposed = true;

            OnDisposed(EventArgs.Empty);
        }

        #endregion

        #region MultimediaTimer Members

        #region Delegates

        /// <summary>
        ///     P�edstavuje metodu, kter� je vol�na syst�mem Windows p�i ud�losti �asova�e.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="msg"></param>
        /// <param name="user"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public delegate void TimeProc(int id, int msg, int user, int param1, int param2);

        // Represents methods that raise events.
        private delegate void EventRaiser(EventArgs e);

        #endregion

        #region Win32 Multimedia MultimediaTimer Functions

        /// <summary>
        ///     Z�sk� mo�nosti �asova�e
        /// </summary>
        /// <param name="caps"></param>
        /// <param name="sizeOfTimerCaps"></param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeGetDevCaps(ref TimerCaps caps, int sizeOfTimerCaps);

        /// <summary>
        ///     Vytvo�� a spust� �asova�.
        /// </summary>
        /// <param name="delay"></param>
        /// <param name="resolution"></param>
        /// <param name="proc"></param>
        /// <param name="user"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeSetEvent(int delay, int resolution,
            TimeProc proc, int user, int mode);

        /// <summary>
        ///     Zastav� a zni�� �asova�.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DllImport("winmm.dll")]
        private static extern int timeKillEvent(int id);

        // Indicates that the operation was successful.
        private const int TimerNoerror = 0;

        #endregion

        #region Fields

        /// <summary>
        ///     Identifik�tor instance �asova�e
        /// </summary>
        private int _timerId;

        /// <summary>
        ///     M�d �asova�e
        /// </summary>
        private volatile TimerMode _mode;

        /// <summary>
        ///     �asov� obdob� mezi ud�lostmi �asova�e v milisekund�ch.
        /// </summary>
        private volatile int _period;

        /// <summary>
        ///     Rozli�en� �asova�e v milisekund�ch
        /// </summary>
        private volatile int _resolution;

        /// <summary>
        ///     Vol�no syst�mem Windows, kdy� nastane periodick� ud�lost �asova�e.
        /// </summary>
        private TimeProc _timeProcPeriodic;

        /// <summary>
        ///     Vol�no syst�mem Windows, kdy� dojde k ud�losti s jednou �asovanou ud�lost�.
        /// </summary>
        private TimeProc _timeProcOneShot;

        /// <summary>
        ///     P�edstavuje metodu, kter� vyvol� ud�lost Tick.
        /// </summary>
        private EventRaiser _tickRaiser;

        /// <summary>
        ///     Indikuje, zda je �asova� spu�t�n.
        /// </summary>
        private bool _running;

        /// <summary>
        ///     Indikuje, zda byl �asova� uvoln�n z pam�ti.
        /// </summary>
        private volatile bool _disposed;

        /// <summary>
        ///     Synchroniza�n� objekt
        /// </summary>
        private ISynchronizeInvoke _synchronizingObject;

        /// <summary>
        ///     Instance <see cref="ISite" />
        /// </summary>
        private ISite _site;

        /// <summary>
        ///     Mo�nosti �asova�e
        /// </summary>
        private static readonly TimerCaps _caps;

        #endregion

        #region Events

        /// <summary>
        ///     Ud�lost, kter� se vyskytne se p�i spu�t�n� �asova�e
        /// </summary>
        public event EventHandler Started;

        /// <summary>
        ///     Ud�lost, kter� se vyskytne se p�i zastaven� �asova�e
        /// </summary>
        public event EventHandler Stopped;

        /// <summary>
        ///     Ud�lost, kter� se vyskytne se po uplynut� periody �asova�e
        /// </summary>
        public event EventHandler Tick;

        #endregion

        #region Construction

        /// <summary>
        ///     Statick� konstruktor t��dy
        /// </summary>
        static MultimediaTimer()
        {
            // Get multimedia timer capabilities.
            timeGetDevCaps(ref _caps, Marshal.SizeOf(_caps));
        }

        /// <summary>
        ///     Inicializuje novou instanci t��dy <see cref="MultimediaTimer" /> se zadan�m <see cref="IContainer" />.
        /// </summary>
        /// <param name="container">Instance <see cref="IContainer" /></param>
        public MultimediaTimer(IContainer container)
        {
            // Required for Windows.Forms Class Composition Designer support
            container.Add(this);

            Initialize();
        }

        /// <summary>
        ///     Inicializuje novou instanci t��dy <see cref="MultimediaTimer" />
        /// </summary>
        public MultimediaTimer()
        {
            Initialize();
        }

        /// <summary>
        ///     Destructor
        /// </summary>
        ~MultimediaTimer()
        {
            if (IsRunning)
                timeKillEvent(_timerId);
        }

        /// <summary>
        ///     Inicializujte �asova� s v�choz�mi hodnotami
        /// </summary>
        private void Initialize()
        {
            _mode = TimerMode.Periodic;
            _period = Capabilities.periodMin;
            _resolution = 1;

            _running = false;

            _timeProcPeriodic = TimerPeriodicEventCallback;
            _timeProcOneShot = TimerOneShotEventCallback;
            _tickRaiser = OnTick;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Startuje �asova�
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     �asova� byl ji� uvoln�n z pam�ti
        /// </exception>
        /// <exception cref="TimerStartException">  Start �asova�e se nezda�il  </exception>
        public void Start()
        {
            #region Require

            if (_disposed)
                throw new ObjectDisposedException("MultimediaTimer");

            #endregion

            #region Guard

            if (IsRunning)
                return;

            #endregion

            // If the periodic event callback should be used.
            if (Mode == TimerMode.Periodic)
                _timerId = timeSetEvent(Period, Resolution, _timeProcPeriodic, 0, (int) Mode);
            // Else the one shot event callback should be used.
            else
                _timerId = timeSetEvent(Period, Resolution, _timeProcOneShot, 0, (int) Mode);

            // If the timer was created successfully.
            if (_timerId != 0)
            {
                _running = true;

                if (SynchronizingObject != null && SynchronizingObject.InvokeRequired)
                    SynchronizingObject.BeginInvoke(
                        new EventRaiser(OnStarted),
                        new object[] {EventArgs.Empty});
                else
                    OnStarted(EventArgs.Empty);
            }
            else
                throw new TimerStartException("Unable to start multimedia MultimediaTimer.");
        }

        /// <summary>
        ///     Starts the timer.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     The timer has already been disposed.
        /// </exception>
        /// <exception cref="TimerStartException">
        ///     The timer failed to start.
        /// </exception>
        public void Start(TimeProc timerCallback)
        {
            #region Require

            if (_disposed)
                throw new ObjectDisposedException("MultimediaTimer");

            #endregion

            #region Guard

            if (IsRunning)
                return;

            #endregion

            // If the periodic event callback should be used.
            if (Mode == TimerMode.Periodic)
                _timerId = timeSetEvent(Period, Resolution, timerCallback, 0, (int) Mode);
            // Else the one shot event callback should be used.
            else
                _timerId = timeSetEvent(Period, Resolution, timerCallback, 0, (int) Mode);

            // If the timer was created successfully.
            if (_timerId != 0)
            {
                _running = true;

                if (SynchronizingObject != null && SynchronizingObject.InvokeRequired)
                    SynchronizingObject.BeginInvoke(
                        new EventRaiser(OnStarted),
                        new object[] {EventArgs.Empty});
                else
                    OnStarted(EventArgs.Empty);
            }
            else
                throw new TimerStartException("Unable to start multimedia MultimediaTimer.");
        }

        /// <summary>
        ///     Stops timer.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     If the timer has already been disposed.
        /// </exception>
        public void Stop()
        {
            #region Require

            if (_disposed)
                throw new ObjectDisposedException("MultimediaTimer");

            #endregion

            #region Guard

            if (!_running)
                return;

            #endregion

            // Stop and destroy timer.
            var result = timeKillEvent(_timerId);

            Debug.Assert(result == TimerNoerror);

            _running = false;

            if (SynchronizingObject != null && SynchronizingObject.InvokeRequired)
                SynchronizingObject.BeginInvoke(
                    new EventRaiser(OnStopped),
                    new object[] {EventArgs.Empty});
            else
                OnStopped(EventArgs.Empty);
        }

        #region Callbacks

        // Callback method called by the Win32 multimedia timer when a timer
        // periodic event occurs.
        private void TimerPeriodicEventCallback(int id, int msg, int user, int param1, int param2)
        {
            if (_synchronizingObject != null)
                _synchronizingObject.BeginInvoke(_tickRaiser, new object[] {EventArgs.Empty});
            else
                OnTick(EventArgs.Empty);
        }

        // Callback method called by the Win32 multimedia timer when a timer
        // one shot event occurs.
        private void TimerOneShotEventCallback(int id, int msg, int user, int param1, int param2)
        {
            if (_synchronizingObject != null)
            {
                _synchronizingObject.BeginInvoke(_tickRaiser, new object[] {EventArgs.Empty});
                Stop();
            }
            else
            {
                OnTick(EventArgs.Empty);
                Stop();
            }
        }

        #endregion

        #region Event Raiser Methods

        // Raises the Disposed event.
        private void OnDisposed(EventArgs e)
        {
            var handler = Disposed;

            if (handler != null)
                handler(this, e);
        }

        // Raises the Started event.
        private void OnStarted(EventArgs e)
        {
            var handler = Started;

            if (handler != null)
                handler(this, e);
        }

        // Raises the Stopped event.
        private void OnStopped(EventArgs e)
        {
            var handler = Stopped;

            if (handler != null)
                handler(this, e);
        }

        // Raises the Tick event.
        private void OnTick(EventArgs e)
        {
            var handler = Tick;

            if (handler != null)
                handler(this, e);
        }

        #endregion

        #endregion

        #region Properties

        /// <summary>
        ///     Z�sk� nebo nastav� objekt, kter� se pou��v� pro vol�n� obsluhy synchronizace ud�lost�
        /// </summary>
        public ISynchronizeInvoke SynchronizingObject
        {
            get
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                return _synchronizingObject;
            }
            set
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                _synchronizingObject = value;
            }
        }

        /// <summary>
        ///     Gets or sets the time between Tick events.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     If the timer has already been disposed.
        /// </exception>
        public int Period
        {
            get
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                return _period;
            }
            set
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");
                if (value < Capabilities.periodMin || value > Capabilities.periodMax)
                    throw new ArgumentOutOfRangeException("Period", value,
                        "Multimedia MultimediaTimer period out of range.");

                #endregion

                _period = value;

                if (IsRunning)
                {
                    Stop();
                    Start();
                }
            }
        }

        /// <summary>
        ///     Gets or sets the timer resolution.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     If the timer has already been disposed.
        /// </exception>
        /// <remarks>
        ///     The resolution is in milliseconds. The resolution increases
        ///     with smaller values; a resolution of 0 indicates periodic events
        ///     should occur with the greatest possible accuracy. To reduce system
        ///     overhead, however, you should use the maximum value appropriate
        ///     for your application.
        /// </remarks>
        public int Resolution
        {
            get
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                return _resolution;
            }
            set
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");
                if (value < 0)
                    throw new ArgumentOutOfRangeException("Resolution", value,
                        "Multimedia timer resolution out of range.");

                #endregion

                _resolution = value;

                if (IsRunning)
                {
                    Stop();
                    Start();
                }
            }
        }

        /// <summary>
        ///     Gets the timer mode.
        /// </summary>
        /// <exception cref="ObjectDisposedException">
        ///     If the timer has already been disposed.
        /// </exception>
        public TimerMode Mode
        {
            get
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                return _mode;
            }
            set
            {
                #region Require

                if (_disposed)
                    throw new ObjectDisposedException("MultimediaTimer");

                #endregion

                _mode = value;

                if (IsRunning)
                {
                    Stop();
                    Start();
                }
            }
        }

        /// <summary>
        ///     Gets a value indicating whether the MultimediaTimer is running.
        /// </summary>
        public bool IsRunning => _running;

        /// <summary>
        ///     Gets the timer capabilities.
        /// </summary>
        public static TimerCaps Capabilities => _caps;

        #endregion

        #endregion

        #region IComponent Members

        /// <summary>
        ///     <see cref="EventHandler" />, kter� indikuje, �e �asova� byl uvoln�n z pam�ti
        /// </summary>
        public event EventHandler Disposed;

        /// <summary>
        ///     Vrac� instanci <see cref="ISite" />
        /// </summary>
        public ISite Site
        {
            get => _site;
            set => _site = value;
        }

        #endregion
    }
}