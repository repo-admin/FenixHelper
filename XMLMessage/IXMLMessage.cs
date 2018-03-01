using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// 
	/// </summary>
	public interface IXMLMessage
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		string ToXMLString();

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<string> Validate();
	}
}
