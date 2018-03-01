using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper.Validation;

#region XML

/*
 
  <?xml version="1.0" encoding="utf-8" ?> 
- <NewDataSet>
- <xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
- <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:MainDataTable="CommunicationMessagesSentReception" msdata:UseCurrentLocale="true">
- <xs:complexType>
- <xs:choice minOccurs="1" maxOccurs="unbounded">
- <xs:element name="CommunicationMessagesSentReception">
- <xs:complexType name="Order">
- <xs:sequence>
  <xs:element name="ID" type="xs:int" use="required" /> 
  <xs:element name="MessageID" type="xs:int" use="required" /> 
  <xs:element name="MessageTypeID" type="xs:int" use="required" /> 
  <xs:element name="MessageTypeDescription" type="xs:string" use="required" /> 
  <xs:element name="MessageDateOfShipment" type="xs:dateTime" use="required" /> 
  <xs:element name="HeliosOrderID" type="xs:int" minOccurs="0" /> 
  <xs:element name="ItemSupplierID" type="xs:int" use="required" /> 
  <xs:element name="ItemSupplierDescription" type="xs:string" use="required" /> 
  <xs:element name="ItemDateOfDelivery" type="xs:dateTime" use="required" /> 
- <xs:complexType name="Items">
- <xs:sequence>
  <xs:element name="HeliosOrderRecordID" type="xs:int" minOccurs="0" /> 
  <xs:element name="ItemID" type="xs:int" use="required" /> 
  <xs:element name="ItemDescription" type="xs:string" use="required" /> 
  <xs:element name="ItemQuantity" type="xs:decimal" use="required" /> 
  <xs:element name="ItemUnitOfMeasureID" type="xs:int" use="required" /> 
  <xs:element name="ItemUnitOfMeasure" type="xs:string" use="required" /> 
  <xs:element name="ItemQualityID" type="xs:int" use="required" /> 
  <xs:element name="ItemQuality" type="xs:string" use="required" /> 
  </xs:sequence>
  </xs:complexType>
  </xs:sequence>
  </xs:complexType>
  </xs:element>
  </xs:choice>
  </xs:complexType>
  </xs:element>
  </xs:schema>
  </NewDataSet>
 
 */

#endregion

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída pro vytvoření XML message pro Reception R0	
	/// (objednávka recepce ze strany UPC)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class R0Reception : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesSentReception")]
		public R0Header Header { get; set; }
		
		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public R0Reception()
		{
			this.Header = new R0Header();
		}

		#endregion

		/// <summary>
		/// vytvoří XML string serializací této třídy
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.URL_W3_ORG_SCHEMA, Encoding.UTF8);
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
	/// Hlavička
	/// </summary>
	public class R0Header
	{
		/// <summary>
		/// ID objednávky recepce
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
		/// datum odeslání zprávy
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfShipment { get; set; }

		/// <summary>
		/// číslo objednávky z Heliosu
		/// </summary>
		public int? HeliosOrderID { get; set; }

		/// <summary>
		/// ID dovavatele
		/// </summary>
		[IntMinMax(Min=1)]
		public int ItemSupplierID { get; set; }
				
		/// <summary>
		/// popis/mázev dodavatele
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemSupplierDescription { get; set; }

		/// <summary>
		/// datum, kdy je požadována recepce
		/// </summary>
		[XmlElement(DataType="date")]
		public DateTime ItemDateOfDelivery { get; set; }

		/// <summary>
		/// položky (požadované items)
		/// </summary>
		[XmlArrayItem("item", typeof(R0Items))]
		[XmlArray("items")]
		public List<R0Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public R0Header()
		{
			this.items = new List<R0Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(R0Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<R0Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (R0Items item in items)
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
	public class R0Items
	{
		/// <summary>
		/// ID záznamu položky z Heliosu
		/// </summary>
		public int? HeliosOrderRecordID { get; set; }		

		/// <summary>
		/// ID položky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemID { get; set; }

		/// <summary>
		/// popis/název položky
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemDescription { get; set; }

		/// <summary>
		/// množství
		/// </summary>		
		public decimal ItemQuantity { get; set; }

		/// <summary>
		/// ID měrné jednotky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemUnitOfMeasureID { get; set; }
		
		/// <summary>
		/// měrná jednotka
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemUnitOfMeasure { get; set; }
		
		/// <summary>
		/// ID kvality položky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemQualityID { get; set; }
		
		/// <summary>
		/// popis kvality položky
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ItemQuality { get; set; }

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(R0Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<R0Items>(data, out errors);

			return errors;
		}
	}
}
