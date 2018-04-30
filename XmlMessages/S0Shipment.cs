using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

#region XML

/*
<?xml version="1.0" encoding="utf-8"?>
<NewDataSet>
  <xs:schema id="NewDataSet" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
    <xs:element name="NewDataSet" msdata:IsDataSet="true" msdata:MainDataTable="CommunicationMessagesSentShipment" msdata:UseCurrentLocale="true">
      <xs:complexType>
        <xs:choice use="required" maxOccurs="unbounded">
          <xs:element name="CommunicationMessagesSentShipment">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="ID" type="xs:int" use="required" />
                <xs:element name="MessageID" type="xs:int" use="required" />
                <xs:element name="MessageTypeID" type="xs:int" use="required" />
                <xs:element name="MessageTypeDescription" type="xs:string" use="required" />
                <xs:element name="MessageDateOfShipment" type="xs:dateTime" use="required" />
                <xs:element name="RequiredDateOfShipment" type="xs:dateTime" use="required" />
                <xs:element name="HeliosOrderID" type="xs:int" minOccurs="0" />
                <xs:element name="CustomerID" type="xs:int" use="required" />
                <xs:element name="CustomerName" type="xs:string" use="required" />
                <xs:element name="CustomerAddress1" type="xs:string" use="required" />
                <xs:element name="CustomerAddress2" type="xs:string" use="required" />
                <xs:element name="CustomerAddress3" type="xs:string" minOccurs="0" />
                <xs:element name="CustomerCity" type="xs:string" use="required" />
                <xs:element name="CustomerZipCode" type="xs:string" use="required" />
                <xs:element name="CustomerCountryISO" type="xs:string" use="required" />
                <xs:element name="ContactID" type="xs:int" use="required" />
                <xs:element name="ContactTitle" type="xs:string" use="required" />
                <xs:element name="ContactFirstName" type="xs:string" use="required" />
                <xs:element name="ContactLastName" type="xs:string" use="required" />
                <xs:element name="ContactPhoneNumber1" type="xs:string" use="required" />
                <xs:element name="ContactPhoneNumber2" type="xs:string" minOccurs="0" />
                <xs:element name="ContactFaxNumber" type="xs:string" minOccurs="0" />
                <xs:element name="ContactEmail" type="xs:string" minOccurs="0" />
                <xs:complexType name="itemsOrKits">
                  <xs:sequence>
                    <xs:complexType name="itemOrKit">
                      <xs:sequence>
                        <xs:element name="SingleOrMaster" type="xs:int" use="required" />
                        <xs:element name="HeliosOrderRecordID" type="xs:int" minOccurs="0" />
                        <xs:element name="ItemOrKitID" type="xs:int" use="required" />
                        <xs:element name="ItemOrKitDescription" type="xs:string" use="required" />
                        <xs:element name="ItemOrKitQuantity" type="xs:decimal" use="required" />
                        <xs:element name="ItemOrKitUnitOfMeasureID" type="xs:int" use="required" />
                        <xs:element name="ItemOrKitUnitOfMeasure" type="xs:string" use="required" />
                        <xs:element name="ItemOrKitQualityID" type="xs:int" use="required" />
                        <xs:element name="ItemOrKitQuality" type="xs:string" use="required" />
                        <xs:element name="ItemVerKit" type="xs:int" use="required" />
                        <xs:element name="IncotermID" type="xs:int" minOccurs="0" />
                        <xs:element name="IncotermDescription" type="xs:string" use="required" />
                      </xs:sequence>
                    </xs:complexType>
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
	/// Třída pro vytvoření XML message pro ShipmentOrder S0	
	/// (objednávka expedice/závozu ze strany UPC)
	/// </summary>
	/// <remarks>
	/// <code>
	/// &lt;? xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
    /// &lt;NewDataSet&gt;
    ///  &lt;xs:schema id = &quot; NewDataSet&quot; xmlns=&quot;&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot;&gt;
    ///    &lt;xs:element name = &quot; NewDataSet&quot; msdata:IsDataSet=&quot;true&quot; msdata:MainDataTable=&quot;CommunicationMessagesSentShipment&quot; msdata:UseCurrentLocale=&quot;true&quot;&gt;
    ///      &lt;xs:complexType&gt;
    ///        &lt;xs:choice use = &quot; required&quot; maxOccurs=&quot;unbounded&quot;&gt;
    ///          &lt;xs:element name = &quot; CommunicationMessagesSentShipment&quot;&gt;
    ///            &lt;xs:complexType&gt;
    ///              &lt;xs:sequence&gt;
    ///                &lt;xs:element name = &quot; ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageTypeID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageTypeDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageDateOfShipment&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; RequiredDateOfShipment&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; HeliosOrderID&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerName&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerAddress1&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerAddress2&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerAddress3&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerCity&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerZipCode&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; CustomerCountryISO&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactTitle&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactFirstName&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactLastName&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactPhoneNumber1&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactPhoneNumber2&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactFaxNumber&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element name = &quot; ContactEmail&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:complexType name = &quot; itemsOrKits&quot;&gt;
    ///                  &lt;xs:sequence&gt;
    ///                    &lt;xs:complexType name = &quot; itemOrKit&quot;&gt;
    ///                      &lt;xs:sequence&gt;
    ///                        &lt;xs:element name = &quot; SingleOrMaster&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; HeliosOrderRecordID&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitQuantity&quot; type=&quot;xs:decimal&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitUnitOfMeasureID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitUnitOfMeasure&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitQualityID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemOrKitQuality&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; ItemVerKit&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; IncotermID&quot; type=&quot;xs:int&quot; minOccurs=&quot;0&quot; /&gt;
    ///                        &lt;xs:element name = &quot; IncotermDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                      &lt;/xs:sequence&gt;
    ///                    &lt;/xs:complexType&gt;
    ///                  &lt;/xs:sequence&gt;
    ///                &lt;/xs:complexType&gt;
    ///              &lt;/xs:sequence&gt;
    ///            &lt;/xs:complexType&gt;
    ///          &lt;/xs:element&gt;
    ///        &lt;/xs:choice&gt;
    ///      &lt;/xs:complexType&gt;
    ///    &lt;/xs:element&gt;
    ///  &lt;/xs:schema&gt;
    /// &lt;/NewDataSet&gt;
	/// </code>
	/// </remarks>
	[XmlRoot("NewDataSet")]
	public class S0Shipment : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesSentShipment")]
		public S0Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public S0Shipment()
		{
			this.Header = new S0Header();
		}

		#endregion

		/// <summary>
		/// Vytvoří XML string serializací této třídy
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
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
	public class S0Header
	{
		/// <summary>
		/// ID item/kit
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
		/// datum odeslání požadavku na závoz/expedici
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime MessageDateOfShipment { get; set; }

		/// <summary>
		/// požadované datum závozu/expedice
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime RequiredDateOfShipment { get; set; }
		
		/// <summary>
		/// číslo objednávky z Heliosu
		/// </summary>
		public int? HeliosOrderID { get; set; }
		
		/// <summary>
		/// Odběratel ID
		/// </summary>
		[IntMinMax(Min = 1)]
		public int CustomerID { get; set; }

		/// <summary>
		/// Odběratel název
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerName { get; set; }

		/// <summary>
		/// Odběratel ulice 
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerAddress1 { get; set; }

		/// <summary>
		/// Odběratel ČP + ČO
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerAddress2 { get; set; }

		/// <summary>
		/// Odběratel rezerva
		/// </summary>		
		public string CustomerAddress3 { get; set; }

		/// <summary>
		/// Odběratel město
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerCity { get; set; }

		/// <summary>
		/// Odběratel PSČ
		/// </summary>		
		public string CustomerZipCode { get; set; }

		/// <summary>
		/// Odběratel Country ISO
		/// (3 písmenná zkratka státu dle ISO 3166-1 alpha-3)
		/// </summary>
		[NotNullOrEmpty]
		public string CustomerCountryISO { get; set; }
				
		/// <summary>
		/// Kontakt (odběratele) ID
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ContactID { get; set; }

		/// <summary>
		/// Kontakt (odběratele) oslovení
		/// 1 .. Pan  2 .. Paní
		/// </summary>
		[NotNullOrEmpty]
		public string ContactTitle { get; set; }

		/// <summary>
		/// Kontakt (odběratele) jméno
		/// </summary>
		[NotNullOrEmpty]
		public string ContactFirstName { get; set; }

		/// <summary>
		/// Kontakt (odběratele) příjmení
		/// </summary>
		[NotNullOrEmpty]
		public string ContactLastName { get; set; }

		/// <summary>
		/// Kontakt (odběratele) telefon
		/// </summary>
		[NotNullOrEmpty]
		public string ContactPhoneNumber1 { get; set; }

		/// <summary>
		/// Kontakt (odběratele) telefon
		/// </summary>		
		public string ContactPhoneNumber2 { get; set; }

		/// <summary>
		/// Kontakt (odběratele) fax
		/// </summary>		
		public string ContactFaxNumber { get; set; }

		/// <summary>
		/// Kontakt (odběratele) email
		/// </summary>		
		public string ContactEmail { get; set; }

		/// <summary>
		/// položky objednávky (požadované items, nebo kits)
		/// </summary>
		[XmlArrayItem("itemOrKit", typeof(S0Items))]
		[XmlArray("itemsOrKits")]
		public List<S0Items> items { get; set; }
		
		/// <summary>
		/// ctor
		/// </summary>
		public S0Header()
		{
			this.items = new List<S0Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(S0Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<S0Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (S0Items item in items)
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
	/// Položky objednávky závozu/expedice
	/// </summary>
	public class S0Items
	{
		/// <summary>
		/// 0 .. single  1 .. master
		/// (1 .. objednané množství je rovno/násobkem hodnotě ve sloupci cdlItems->Packaging)
		/// </summary>
		[IntMinMax(Min = 0)]
		public int SingleOrMaster { get; set; }

		/// <summary>
		/// [CommunicationMessagesShipmentOrdersSentItems].[ID]
		/// </summary>
		public int? HeliosOrderRecordID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[NotNullOrEmpty]
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
		[NotNullOrEmpty]
		public string ItemOrKitUnitOfMeasure { get; set; }

		/// <summary>
		/// ID kvality item/kitu
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ItemOrKitQualityID { get; set; }

		/// <summary>
		/// popis kvality item/kitu
		/// </summary>
		[NotNullOrEmpty]
		public string ItemOrKitQuality { get; set; }
				
		/// <summary>
		/// priznak, zda polozka je item, nebo kit
		/// 0 .. item	1 .. KIT
		/// </summary>		
		public int ItemVerKit { get; set; }
		
		/// <summary>
		/// ID incoterm
		/// </summary>
		[IntMinMax(Min = 1)]
		public int IncotermID { get; set; }

		/// <summary>
		/// popis incoterm
		/// </summary>
		[NotNullOrEmpty]
		public string IncotermDescription { get; set; }

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(S0Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<S0Items>(data, out errors);

			return errors;
		}
	}
}
