using System;

namespace Fenix.MultimediaTimer
{
    /// <summary>
    ///     V�jimka, kter� je vyvol�na, kdy� se �asova� nespust�.
    /// </summary>
    public class TimerStartException : ApplicationException
    {
        /// <summary>
        ///     Inicializuje novou instanci t��dy TimerStartException.
        /// </summary>
        /// <param name="message">
        ///     Chybov� zpr�va vysv�tluj�c� d�vod v�jimky.
        /// </param>
        public TimerStartException(string message) : base(message) { }
    }
}