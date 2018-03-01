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
	/// Volby vytvoření požadovaného XML objektu
	/// </summary>
	public enum CreatorSettings
	{
		/// <summary>
		/// Žádný požadavek
		/// </summary>
		None = 1,

		/// <summary>
		/// Vytvoření deklarační části XML
		/// </summary>
		Declaration = 2,
	}

	/// <summary>
	/// Třída pro vytváření XML objektů serializací
	/// </summary>
	public class XmlCreator
	{
		/// <summary>
		/// Vytvoří string obsahující XML root element
		/// (bez jmenného prostoru xmlns)
		/// </summary>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static string CreateXMLRootNode(String xml)
		{
			XDocument d = XDocument.Parse(xml);
			d.Root.Attributes().Where(x => x.Name == "xmlns").Remove();

			foreach (var elem in d.Descendants())
				elem.Name = elem.Name.LocalName;

			var xmlDocument = new XmlDocument();
			xmlDocument.Load(d.CreateReader());
						
			return d.ToString();
		}
		
		/// <summary>
		/// Ze zadané třídy vytvoří XML root element s požadovaným kódováním
		/// </summary>
		/// <param name="value">třída, ze které se vytvoří root element</param>
		/// <param name="encoding">kódování</param>
		/// <returns></returns>
		public static XmlDocument CreateXMLRootNode(Object value, Encoding encoding)
		{
			XmlDocument xmlDoc = new XmlDocument();
			var emptyNamepsaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
			var serializer = new XmlSerializer(value.GetType());
			var xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.Indent = true;
			xmlWriterSettings.Encoding = encoding;
			xmlWriterSettings.OmitXmlDeclaration = true;

			using (var stream = new StringWriter())
			using (var writer = XmlWriter.Create(stream, xmlWriterSettings))
			{
				serializer.Serialize(writer, value, emptyNamepsaces);
				xmlDoc.LoadXml(stream.ToString());
			}

			return xmlDoc;
		}

		/// <summary>
		/// Ze zadané třídy vytvoří string reprezentující XML dokument s požadovaným kódováním
		/// <para>(s formátováním pro snadné čtení)</para>
		/// </summary>
		/// <param name="value">třída, ze které se vytvoří string reprezentující XML dokument</param>
		/// <param name="rootNameSpaceName">výchozí jmenný prostor</param>
		/// <param name="encoding">kódování</param>
		/// <returns></returns>
		public static string CreateXmlString(Object value, string rootNameSpaceName, Encoding encoding)
		{
			return CreateXmlString(value, rootNameSpaceName, encoding, CreatorSettings.Declaration);
		}

		/// <summary>
		/// Ze zadané třídy vytvoří string reprezentující XML dokument s požadovaným kódováním
		/// <para>(s formátováním pro snadné čtení)</para>
		/// </summary>
		/// <param name="value">třída, ze které se vytvoří string reprezentující XML dokument</param>
		/// <param name="rootNameSpaceName">výchozí jmenný prostor</param>
		/// <param name="encoding">kódování</param>
		/// <param name="setting">volby vytvoření</param>
		/// <returns></returns>
		public static string CreateXmlString(Object value, string rootNameSpaceName, Encoding encoding, CreatorSettings setting)
		{
			string xmlString;

			XmlDocument xmlDoc = new XmlDocument();
			XmlSerializer serializer = new XmlSerializer(value.GetType(), rootNameSpaceName);

			using (MemoryStream xmlStream = new MemoryStream())
			{
				XmlTextWriter stream = new XmlTextWriter(xmlStream, encoding);
				using (Stream baseStream = stream.BaseStream)
				{
					stream.Formatting = Formatting.Indented;
					stream.IndentChar = '\t';
					stream.Indentation = 1;

					XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
					ns.Add(String.Empty, rootNameSpaceName);

					serializer.Serialize(stream, value, ns);

					xmlStream.Position = 0;
					xmlDoc.Load(xmlStream);

					xmlString = xmlDoc.InnerXml;
				}
			}

			XDocument xd = XDocument.Parse(xmlString);
			if ((setting & CreatorSettings.Declaration) == CreatorSettings.Declaration)
			{
				xmlString = String.Format("{0}{1}{2}", xd.Declaration.ToString(), Environment.NewLine, xd.Root.ToString());
			}
			else
			{
				xmlString = String.Format("{0}", xd.Root.ToString());
			}

			return xmlString;
		}
	}
}
