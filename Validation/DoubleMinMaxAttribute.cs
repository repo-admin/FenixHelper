using System;

namespace Fenix.Validation
{
	/// <summary>
	/// Atribut, který specifikuje minimální a maximální hodnotu typu <see cref="Double"/>
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DoubleMinMaxAttribute : Attribute
	{
		/// <summary>
		/// Minimální hodnota
		/// </summary>
		public double Min { get; set; }

		/// <summary>
		/// Maximální hodnota
		/// </summary>
		public double Max { get; set; }

        /// <summary>
        /// Inicializuje novou instanci třídy DoubleMinMaxAttribute
        /// </summary>
        public DoubleMinMaxAttribute()
		{
			Min = double.MinValue;
			Max = double.MaxValue;
		}
	}
}
