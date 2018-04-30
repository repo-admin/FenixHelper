using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

#region XML

/*
 
  <?xml version="1.0" encoding="utf-8" ?> 
<NewDataSet>
<xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
<xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:MainDataTable="CommunicationMessagesSentReception" msdata:UseCurrentLocale="true">
<xs:complexType>
<xs:choice minOccurs="1" maxOccurs="unbounded">
<xs:element name="CommunicationMessagesSentReception">
<xs:complexType name="Order">
<xs:sequence>
  <xs:element name="ID" type="xs:int" use="required" /> 
  <xs:element name="MessageID" type="xs:int" use="required" /> 
  <xs:element name="MessageTypeID" type="xs:int" use="required" /> 
  <xs:element name="MessageTypeDescription" type="xs:string" use="required" /> 
  <xs:element name="MessageDateOfShipment" type="xs:dateTime" use="required" /> 
  <xs:element name="HeliosOrderID" type="xs:int" minOccurs="0" /> 
  <xs:element name="ItemSupplierID" type="xs:int" use="required" /> 
  <xs:element name="ItemSupplierDescription" type="xs:string" use="required" /> 
  <xs:element name="ItemDateOfDelivery" type="xs:dateTime" use="required" /> 
<xs:complexType name="Items">
<xs:sequence>
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

namespace Fenix.XmlMessages
{
	/// <summary>
	/// Třída pro vytvoření XML message pro Reception R0	
	/// (objednávka recepce ze strany UPC)
	/// </summary>
	/// <remarks>
	/// <code>
	/// &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
    /// &lt;NewDataSet&gt;
    ///   &lt;xs:schema xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot; id=&quot;NewDataSet&quot;&gt;
    ///      &lt;xs:element name = &quot; NewDataSet&quot; msdata:IsDataSet=&quot;true&quot; msdata:MainDataTable=&quot;CommunicationMessagesSentReception&quot; msdata:UseCurrentLocale=&quot;true&quot;&gt;
    ///         &lt;xs:complexType&gt;
    ///            &lt;xs:choice minOccurs = &quot;1&quot; maxOccurs=&quot;unbounded&quot;&gt;
    ///               &lt;xs:element name = &quot; CommunicationMessagesSentReception&quot;&gt;
    ///                  &lt;xs:complexType name = &quot; Order&quot;&gt;
    ///                     &lt;xs:sequence&gt;
    ///                        &lt;xs:element name = &quot; ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; MessageID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; MessageTypeID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; MessageTypeDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; MessageDateOfShipment&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; HeliosOrderID&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemSupplierID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemSupplierDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemDateOfDelivery&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:complexType name = &quot; Items&quot;&gt;
    ///                           &lt;xs:sequence&gt;
    ///                              &lt;xs:element name = &quot; HeliosOrderRecordID&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemQuantity&quot; type=&quot;xs:decimal&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemUnitOfMeasureID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemUnitOfMeasure&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemQualityID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                              &lt;xs:element name = &quot; ItemQuality&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                           &lt;/xs:sequence&gt;
    ///                        &lt;/xs:complexType&gt;
    ///                     &lt;/xs:sequence&gt;
    ///                  &lt;/xs:complexType&gt;
    ///               &lt;/xs:element&gt;
    ///            &lt;/xs:choice&gt;
    ///         &lt;/xs:complexType&gt;
    ///      &lt;/xs:element&gt;
    ///   &lt;/xs:schema&gt;
    /// &lt;/NewDataSet&gt;
	/// </code>
	/// </remarks>
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
		[NotNullOrEmpty]
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
		[NotNullOrEmpty]
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
		[NotNullOrEmpty]
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
		[NotNullOrEmpty]
		public string ItemUnitOfMeasure { get; set; }
		
		/// <summary>
		/// ID kvality položky
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemQualityID { get; set; }
		
		/// <summary>
		/// popis kvality položky
		/// </summary>
		[NotNullOrEmpty]
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
