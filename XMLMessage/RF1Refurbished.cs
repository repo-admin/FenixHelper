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
	/// Třída pro vytvoření XML message pro RefurbishedConfirmation RF1	
	/// (potvrzení naskladnění repasovaného zboží ze strany ND)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class RF1Refurbished : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// Hlavička zprávy
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesRefurbishedConfirmation")]
		public RF1Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public RF1Refurbished()
		{
			this.Header = new RF1Header();
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
	/// Hlavička potvrzení
	/// </summary>
	public class RF1Header
	{
		/// <summary>
		/// ID ?????  jaké
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
		/// ???????
		/// </summary>
		public int RefurbishedOrderID { get; set; }

		/// <summary>
		/// Odběratel ID
		/// </summary>
		[IntMinMax(Min = 1)]
		public int CustomerID { get; set; }

		/// <summary>
		/// Odběratel název
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string CustomerName { get; set; }

		/// <summary>
		/// datum odeslání požadavku na naskladnění repasovaného zboží
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime DateOfShipment { get; set; }

		/// <summary>
		/// položky objednávky (požadované items, nebo kits)
		/// </summary>
		[XmlArrayItem("itemOrKit", typeof(RF1Items))]
		[XmlArray("itemsOrKits")]
		public List<RF1Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public RF1Header()
		{
			this.items = new List<RF1Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(RF1Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<RF1Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (RF1Items item in items)
				{
					errors.AddRange(item.Validate(item));
				}
			}
			else
			{
				errors.Add("Item Count = [0]");
			}

			return errors;
		}
	}

	/// <summary>
	/// Položky 
	/// </summary>
	public class RF1Items
	{
		/// <summary>
		/// priznak, zda polozka je item, nebo kit
		/// 0 .. item	1 .. KIT
		/// </summary>		
		public int ItemVerKit { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemOrKitDescription { get; set; }

		/// <summary>
		/// objednané množství item/kitu
		/// </summary>		
		public decimal ItemOrKitQuantity { get; set; }

		/// <summary>
		/// ID měrné jednotky item/kitu
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitUnitOfMeasureID { get; set; }

		/// <summary>
		/// měrná jednotka item/kitu
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemOrKitUnitOfMeasure { get; set; }

		/// <summary>
		/// ID kvality item/kitu
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitQualityID { get; set; }

		/// <summary>
		/// popis kvality item/kitu
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemOrKitQuality { get; set; }

		/// <summary>
		/// ND příjemka
		/// </summary>
		public string NDReceipt { get; set; }

		/// <summary>
		/// sériová čísla
		/// </summary>
		[XmlArray("ItemOrKitSNs")]
		public List<RF1ItemSN> ItemSNs { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public RF1Items()
		{
			this.ItemSNs = new List<RF1ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(RF1Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<RF1Items>(data, out errors);

			return errors;
		}
	}

	/// <summary>
	/// Sériová čísla items v kitu
	/// </summary>	
	[XmlType(TypeName = "ItemOrKitSNs")]
	public class RF1ItemSN
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
