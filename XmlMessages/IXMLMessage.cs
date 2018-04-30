using System.Collections.Generic;

namespace Fenix.XmlMessages
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
