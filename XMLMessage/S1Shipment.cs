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
          <xs:element name="CommunicationMessagesShipmentConfirmation">
            <xs:complexType>
              <xs:sequence>
                <xs:element name="ID" type="xs:int" use="required" />
                <xs:element name="MessageID" type="xs:int" use="required" />
                <xs:element name="MessageTypeID" type="xs:int" use="required" />
                <xs:element name="MessageTypeDescription" type="xs:string" use="required" />
                <xs:element name="MessageDateOfShipment" type="xs:dateTime" use="required" />
                <xs:element name="RequiredDateOfReceipt" type="xs:dateTime" use="required" />
                <xs:element name="ShipmentOrderID" type="xs:int" use="required" />
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
                        <xs:element name="RealDateOfDelivery" type="xs:dateTime" use="required" />
                        <xs:element name="RealItemOrKitQuantity" type="xs:decimal" use="required" />
                        <xs:element name="RealItemOrKitQualityID" type="xs:int" use="required" />
                        <xs:element name="RealItemOrKitQuality" type="xs:string" use="required" />
                        <xs:element name="Status" type="xs:int" use="required" />
                        <xs:complexType name="ItemOrKitSNs">
                          <xs:sequence>
                            <ItemSN SN1="" SN2="" type="xs:string" minOccurs="0" />
                          </xs:sequence>
                        </xs:complexType>
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
	/// Třída pro vytvoření XML message pro ShipmentConfirmation S1	
	/// (potvrzení expedice/závozu ze strany ND)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class S1Shipment : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesShipmentConfirmation")]
		public S1Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public S1Shipment()
		{
			this.Header = new S1Header();
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
	public class S1Header
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
		/// číslo objednávky závozu/expedice
		/// </summary>
		public int ShipmentOrderID { get; set; }
		
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
		public string CustomerAddress2 { get; set; }

		/// <summary>
		/// Odběratel rezerva adresy
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
		[XmlArrayItem("itemOrKit", typeof(S1Items))]
		[XmlArray("itemsOrKits")]
		public List<S1Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public S1Header()
		{
			this.items = new List<S1Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(S1Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<S1Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (S1Items item in items)
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
	public class S1Items
	{
		/// <summary>
		/// 0 .. single  1 .. master
		/// (1 .. objednané množství je rovno/přesným násobkem hodnotě/hodnoty ve sloupci cdlItems->Packaging	0 .. to ostatní)
		/// </summary>
		[IntMinMax(Min = 0)]
		public int SingleOrMaster { get; set; }

		/// <summary>
		/// 
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
		/// skutečné datum závozu/expedice
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime RealDateOfDelivery { get; set; }
		
		/// <summary>
		/// skutečné množství item/kitu
		/// </summary>		
		public decimal RealItemOrKitQuantity { get; set; }

		/// <summary>
		/// ID skutečné kvality item/kit
		/// </summary>
		[IntMinMax(Min = 1)]
		public int RealItemOrKitQualityID { get; set; }

		/// <summary>
		/// popis skutečné kvality item/kit
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string RealItemOrKitQuality { get; set; }
		
		/// <summary>
		/// status - nastavuje ND
		/// (0 .. Canceled  1 .. Shipped)
		/// </summary>
		[IntMinMax(Min = 1)]
		public int Status { get; set; }
		
		/// <summary>
		/// sériová čísla
		/// </summary>
		[XmlArray("ItemOrKitSNs")]
		public List<S1ItemSN> ItemSNs { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public S1Items()
		{
			this.ItemSNs = new List<S1ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(S1Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<S1Items>(data, out errors);

			return errors;
		}
	}

	/// <summary>
	/// Sériová čísla items v kitu
	/// </summary>	
	[XmlType(TypeName = "ItemSN")]
	public class S1ItemSN
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
