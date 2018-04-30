using System;

namespace Fenix.MultimediaTimer
{
    /// <summary>
    ///     Výjimka, která je vyvolána, když se èasovaè nespustí.
    /// </summary>
    public class TimerStartException : ApplicationException
    {
        /// <summary>
        ///     Inicializuje novou instanci tøídy TimerStartException.
        /// </summary>
        /// <param name="message">
        ///     Chybová zpráva vysvìtlující dùvod výjimky.
        /// </param>
        public TimerStartException(string message) : base(message) { }
    }
}