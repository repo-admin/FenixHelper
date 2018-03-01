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
	/// Třída pro vytvoření XML message pro Kit K0	
	/// (objednávka kittingu ze strany UPC)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class K0Kit : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesSentKit")]
		public K0Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public K0Kit()
		{
			this.Header = new K0Header();
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
	public class K0Header
	{
		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// unikátní číslo zprávy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageID { get; set; }

		/// <summary>
		/// ID typu zprávy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageTypeID { get; set; }

		/// <summary>
		/// popis typu zprávy
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string MessageTypeDescription { get; set; }

		/// <summary>
		/// datum odeslání kittingu
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfShipment { get; set; }

		/// <summary>
		/// číslo objednávky z Heliosu
		/// </summary>
		public int? HeliosOrderID { get; set; }

		/// <summary>
		/// datum, kdy je požadován kitting
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime KitDateOfDelivery { get; set; }

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
		/// ctor
		/// </summary>
		public K0Header()
		{
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(K0Header data)
		{
			List<string> errors = new List<string>();
			Validation.Validation.ValidateAllProperties<K0Header>(data, out errors);

			return errors;
		}
	}
}
