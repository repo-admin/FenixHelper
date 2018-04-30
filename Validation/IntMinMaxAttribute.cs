using System;

namespace Fenix.Validation
{
    /// <summary>
    /// Atribut, který specifikuje minimální a maximální hodnotu typu <see cref="Int32"/>
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class IntMinMaxAttribute : Attribute
	{
        /// <summary>
        /// Minimální hodnota
        /// </summary>
        public int Min { get; set; }

        /// <summary>
        /// Maximální hodnota
        /// </summary>
        public int Max { get; set; }

        /// <summary>
        /// Inicializuje novou instanci třídy IntMinMaxAttribute
        /// </summary>
        public IntMinMaxAttribute()
		{
			Min = int.MinValue;
			Max = int.MaxValue;
		}
	}
}
