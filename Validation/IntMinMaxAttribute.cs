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
	public sealed class IntMinMaxAttribute : Attribute
	{
		/// <summary>
		/// 
		/// </summary>
		public int Min { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int Max { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public IntMinMaxAttribute()
		{
			Min = int.MinValue;
			Max = int.MaxValue;
		}
	}
}
