using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

namespace Fenix.XmlMessages
{
	/// <summary>
	/// Třída pro vytvoření XML message pro Refurbished Order RF0	
	/// (objednávka naskladnění repasovaného zboží ze strany UPC)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class RF0Refurbished : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// Hlavička zprávy
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesRefurbishedOrder")]
		public RF0Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public RF0Refurbished()
		{
			this.Header = new RF0Header();
		}

		#endregion

		/// <summary>
		/// vytvoří XML string serializací této třídy
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate()
		{
			return this.Header.Validate(this.Header);
		}
	}

	/// <summary>
	/// Hlavička objednávky
	/// </summary>
	public class RF0Header
	{
		/// <summary>
		/// ID této objednávky
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
		[NotNullOrEmpty]
		public string MessageTypeDescription { get; set; }

		/// <summary>
		/// datum odeslání zprávy
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfShipment { get; set; }

		/// <summary>
		/// ID zákazníka
		/// </summary>
		[IntMinMax(Min = 1)]
		public int CustomerID { get; set; }

		/// <summary>
		/// popis/název zákazníka
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerDescription { get; set; }

		/// <summary>
		/// datum, ????????????????
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime DateOfDelivery { get; set; }

		/// <summary>
		/// položky objednávky (požadované items, nebo kits)
		/// </summary>
		[XmlArrayItem("itemOrKit", typeof(RF0Items))]
		[XmlArray("itemsOrKits")]
		public List<RF0Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public RF0Header()
		{
			this.items = new List<RF0Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(RF0Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<RF0Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (RF0Items item in items)
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
	/// Položky objednávky
	/// </summary>
	public class RF0Items
	{
		/// <summary>
		/// příznak, zda položka je item, nebo kit
		/// 0 .. item	1 .. KIT
		/// </summary>		
		public int ItemVerKit { get; set; }

		/// <summary>
		/// ID položky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitID { get; set; }

		/// <summary>
		/// popis/název položky
		/// </summary>
		[NotNullOrEmpty]
		public string ItemOrKitDescription { get; set; }

		/// <summary>
		/// množství
		/// </summary>		
		public decimal ItemOrKitQuantity { get; set; }

		/// <summary>
		/// ID měrné jednotky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitUnitOfMeasureID { get; set; }

		/// <summary>
		/// měrná jednotka
		/// </summary>
		[NotNullOrEmpty]
		public string ItemOrKitUnitOfMeasure { get; set; }

		/// <summary>
		/// ID kvality položky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitQualityID { get; set; }

		/// <summary>
		/// popis kvality položky
		/// </summary>
		[NotNullOrEmpty]
		public string ItemOrKitQuality { get; set; }

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(RF0Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<RF0Items>(data, out errors);

			return errors;
		}
	}
}
