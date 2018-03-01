using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper.Validation;

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída pro vytvoření XML message pro Kit K1	
	/// (potvrzení kittingu ze strany ND)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class K1Kit : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesKittingConfirmation")]
		public K1Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public K1Kit()
		{
			this.Header = new K1Header();
		}

		#endregion

		/// <summary>
		/// Vytvoří XML string serializací této třídy
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.URL_W3_ORG_SCHEMA, Encoding.UTF8);
		}

		/// <summary>
		/// Validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate()
		{
			return this.Header.Validate(this.Header);
		}
	}

	/// <summary>
	/// Hlavička 
	/// </summary>
	public class K1Header
	{
		/// <summary>
		/// ID kitu
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// unikátní číslo zprávy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageID { get; set; }

		/// <summary>
		/// typ zprávy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageTypeID { get; set; }

		/// <summary>
		/// popis typu zprávy
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string MessageTypeDescription { get; set; }

		/// <summary>
		/// datum, kdy byl kittng objednán (datum odeslání K0)  
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfReceipt { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int KitOrderID { get; set; }

		/// <summary>
		/// číslo objednávky z Heliosu
		/// </summary>
		public int? HeliosOrderID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int KitID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string KitDescription { get; set; }

		/// <summary>
		/// objednané množství
		/// </summary>		
		public decimal KitQuantity { get; set; }

		/// <summary>
		/// ID měrné jednotky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int KitUnitOfMeasureID { get; set; }

		/// <summary>
		/// měrná jednotka
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string KitUnitOfMeasure { get; set; }

		/// <summary>
		/// ID kvality kitu
		/// </summary>
		[IntMinMax(Min = 1)]
		public int KitQualityID { get; set; }

		/// <summary>
		/// popis kvality kitu
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string KitQuality { get; set; }

		/// <summary>
		/// sériová čísla
		/// </summary>
		[XmlArray("ItemSNs")]
		public List<K1ItemSN> ItemSNs { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public K1Header()
		{	
			this.ItemSNs = new List<K1ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(K1Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<K1Header>(data, out errors);

			return errors;
		}
	}
		
	/// <summary>
	/// Sériová čísla items v kitu
	/// </summary>	
	[XmlType(TypeName = "ItemSN")]
	public class K1ItemSN
	{
		/// <summary>
		/// 1. sériové číslo
		/// </summary>
		[XmlAttribute("SN1")]
		public string SerialNumber1 { get; set; }

		/// <summary>
		/// 2. sériové číslo
		/// </summary>
		[XmlAttribute("SN2")]
		public string SerialNumber2 { get; set; }
	}
}
