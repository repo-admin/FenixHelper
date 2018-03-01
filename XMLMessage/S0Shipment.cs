using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper.Validation;

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

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída pro vytvoření XML message pro ShipmentOrder S0	
	/// (objednávka expedice/závozu ze strany UPC)
	/// </summary>
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
		[NotNullOrEmptyAttribute]
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
		[NotNullOrEmptyAttribute]
		public string CustomerName { get; set; }

		/// <summary>
		/// Odběratel ulice 
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string CustomerAddress1 { get; set; }

		/// <summary>
		/// Odběratel ČP + ČO
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string CustomerAddress2 { get; set; }

		/// <summary>
		/// Odběratel rezerva
		/// </summary>		
		public string CustomerAddress3 { get; set; }

		/// <summary>
		/// Odběratel město
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string CustomerCity { get; set; }

		/// <summary>
		/// Odběratel PSČ
		/// </summary>		
		public string CustomerZipCode { get; set; }

		/// <summary>
		/// Odběratel Country ISO
		/// (3 písmenná zkratka státu dle ISO 3166-1 alpha-3)
		/// </summary>
		[NotNullOrEmptyAttribute]
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
		[NotNullOrEmptyAttribute]
		public string ContactTitle { get; set; }

		/// <summary>
		/// Kontakt (odběratele) jméno
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ContactFirstName { get; set; }

		/// <summary>
		/// Kontakt (odběratele) příjmení
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string ContactLastName { get; set; }

		/// <summary>
		/// Kontakt (odběratele) telefon
		/// </summary>
		[NotNullOrEmptyAttribute]
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
		[NotNullOrEmptyAttribute]
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
