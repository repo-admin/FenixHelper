using System.Runtime.InteropServices;

namespace Fenix.MultimediaTimer
{
    /// <summary>
    ///     P�edstavuje informace o multimedi�ln�ch schopnostech <see cref="MultimediaTimer" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimerCaps
    {
        /// <summary>
        ///     Minim�ln� povolen� doba periody v milisekund�ch.
        /// </summary>
        public int periodMin;

        /// <summary>
        ///     Maxim�ln� povolen� doba periody v milisekund�ch.
        /// </summary>
        public int periodMax;
    }
}