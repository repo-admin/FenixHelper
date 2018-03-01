using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixHelper.Validation
{
	/// <summary>
	/// 
	/// </summary>
	[AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
	public sealed class DoubleMinMaxAttribute : Attribute
	{
		/// <summary>
		/// 
		/// </summary>
		public double Min { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public double Max { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DoubleMinMaxAttribute()
		{
			Min = double.MinValue;
			Max = double.MaxValue;
		}
	}
}
