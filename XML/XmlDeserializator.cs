using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FenixHelper
{
	/// <summary>
	/// 
	/// </summary>
	public class XmlDeserializator
	{


		/// <summary>
		/// Removes all namespaces  BLBE !!!!
		/// </summary>
		/// <param name="root"></param>
		/// <returns></returns>
		public static XElement stripNS(XElement root)
		{
			return new XElement(
				root.Name.LocalName,
				root.HasElements ?
					root.Elements().Select(el => stripNS(el)) :
					(object)root.Value
			);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xmlString"></param>
		/// <param name="classObject"></param>
		/// <param name="removeNamespaces"></param>
		/// <returns></returns>
		public static T CreateObject<T>(T classObject, string xmlString, bool removeNamespaces)
		{
			string xmlInputString = xmlString;

			if (removeNamespaces)
			{
				var xml = XElement.Parse(xmlString);
				XElement xElement = stripNS(xml);
				xmlInputString = xElement.ToString();
			}

			XmlSerializer oXmlSerializer = new XmlSerializer(classObject.GetType());
			classObject = (T)oXmlSerializer.Deserialize(new StringReader(xmlInputString));

			return classObject;
		}
	}
}
