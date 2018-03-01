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
	/// Třída pro vytvoření XML message pro Kit K2	
	/// (schválení expedice - ze strany UPC)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class K2Kit
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesKittingApproval")]
		public K2Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public K2Kit()
		{
			this.Header = new K2Header();
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
	public class K2Header
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
		/// ??????
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfShipment { get; set; }

		/// <summary>
		/// ??????
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime? RequiredReleaseDate { get; set; }

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
		public List<K2ItemSN> ItemSNs { get; set; }
		
		/// <summary>
		/// ctor
		/// </summary>
		public K2Header()
		{
			this.ItemSNs = new List<K2ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(K2Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<K2Header>(data, out errors);

			return errors;
		}
	}

	/// <summary>
	/// Sériová čísla kitu
	/// </summary>	
	[XmlType(TypeName = "ItemSN")]
	public class K2ItemSN
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
