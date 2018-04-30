using System.Runtime.InteropServices;

namespace Fenix.MultimediaTimer
{
    /// <summary>
    ///     Pøedstavuje informace o multimediálních schopnostech <see cref="MultimediaTimer" />.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TimerCaps
    {
        /// <summary>
        ///     Minimální povolená doba periody v milisekundách.
        /// </summary>
        public int periodMin;

        /// <summary>
        ///     Maximální povolená doba periody v milisekundách.
        /// </summary>
        public int periodMax;
    }
}