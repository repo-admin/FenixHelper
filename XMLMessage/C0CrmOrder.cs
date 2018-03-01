using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper.Validation;

#region XML schema

/*
<?xml version="1.0" encoding="UTF-8"?>
<NewDataSet>
  <xs:schema xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns="" id="NewDataSet">
    <xs:element name="NewDataSet" msdata:UseCurrentLocale="true" msdata:MainDataTable="CommunicationMessagesCrmOrder" msdata:IsDataSet="true">
      <xs:complexType>
        <xs:choice maxOccurs="unbounded" minOccurs="1">
          <xs:element name="CommunicationMessagesCrmOrder">
            <xs:complexType>
              <xs:sequence>
                <xs:element type="xs:int" name="ID" use="required"/>
                <xs:element type="xs:int" name="MessageID" use="required"/>
                <xs:element type="xs:int" name="MessageTypeID" use="required"/>
                <xs:element type="xs:string" name="MessageTypeDescription" use="required" />
                <xs:element type="xs:string" name="MessageDateOfShipment" use="required" />                
                <xs:element type="xs:string" name="WO_PR_NUMBER" use="required" />
                <xs:element type="xs:date" name="WO_PR_CREATE_DATE" use="required" />
                <xs:element type="xs:date" name="WO_DELIVERY_DATE_FROM" use="required" />
                <xs:element type="xs:date" name="WO_DELIVERY_DATE_TO" use="required" />
                <xs:element type="xs:int" name="WO_CID" use="required" />
                <xs:element type="xs:string" name="WO_FIRST_LAST_NAME" use="required" />
                <xs:element type="xs:string" name="WO_STREET_NAME" use="required" />
                <xs:element type="xs:string" name="WO_HOUSE_NUMBER" use="required" />
                <xs:element type="xs:string" name="WO_CITY" use="required" />
                <xs:element type="xs:string" name="WO_ZIP" use="required" />
                <xs:element type="xs:string" name="WO_PHONE" use="required" />
                <xs:element type="xs:string" name="WO_EMAIL_INFO1" minOccurs="0" />
                <xs:element type="xs:string" name="WO_PR_TYPE" use="required" />
                <xs:element type="xs:string" name="WO_FLOOR_FLAT" minOccurs="0" />
                <xs:element type="xs:string" name="WO_UPC_TEL1" minOccurs="0" />
                <xs:element type="xs:string" name="WO_UPC_TEL2" minOccurs="0" />
                <xs:element type="xs:string" name="WO_EMAIL" minOccurs="0" />
                <xs:element type="xs:string" name="WO_PASSWORD" minOccurs="0" />
                <xs:element type="xs:string" name="WO_CPE_BACK" minOccurs="0" />
                <xs:element type="xs:string" name="WO_NOTE" minOccurs="0" />                
                <xs:element type="xs:string" name="L_TYPE_OF_ORDER" use="required" />
                <xs:element type="xs:date" name="L_SHIPMENT_EXPECTED" use="required" />                
                <xs:complexType name="itemsOrKits">
                  <xs:sequence>
                    <xs:complexType name="itemOrKit" minOccurs="1">
                      <xs:sequence>
                        <xs:element type="xs:boolean" name="L_ITEM_VER_KIT" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_ID" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_DESCRIPTION" use="required" />
                        <xs:element type="xs:decimal" name="L_ITEM_OR_KIT_QUANTITY" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_QUALITY_ID" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_QUALITY" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_MEASURE_ID" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_MEASURE" use="required" />
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
	/// Třída pro vytvoření XML message pro CrmOrder C0	
	/// (CRM objednávka ze strany UPC)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class C0CrmOrder : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesCrmOrder")]
		public C0Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public C0CrmOrder()
		{
			this.Header = new C0Header();
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
	public class C0Header
	{
		/// <summary>
		/// ID objednávky CRM
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
		/// číslo objednávky
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_PR_NUMBER { get; set; }

		/// <summary>
		/// datum kdy byl PR vytvořen
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime WO_PR_CREATE_DATE { get; set; }

		/// <summary>
		/// datum kdy je přislíbeno doručení klientovi
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime WO_DELIVERY_DATE_FROM { get; set; }

		/// <summary>
		/// datum kdy je přislíbeno doručení klientovi (identický údaj)
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime WO_DELIVERY_DATE_TO { get; set; }

		/// <summary>
		/// číslo kl. smlouvy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int WO_CID { get; set; }

		/// <summary>
		/// jmeno a prijmeni v jedne kolonce
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_FIRST_LAST_NAME { get; set; }

		/// <summary>
		/// ulice
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_STREET_NAME { get; set; }

		/// <summary>
		/// cislo popisne / orientacni
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_HOUSE_NUMBER { get; set; }

		/// <summary>
		/// obec
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_CITY { get; set; }

		/// <summary>
		/// PSČ
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_ZIP { get; set; }

		/// <summary>
		/// mobilni cislo nebo pevna linka 
		/// (podminky v CRM => primarne se predava mobil, v pripade pouze pevne linky je predana pevna linka)
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_PHONE { get; set; }

		/// <summary>
		/// informacni email 1 z CRM
		/// </summary>
		public string WO_EMAIL_INFO1 { get; set; }

		///// <summary>
		///// informacni email 2 z CRM
		///// </summary>
		//public string WO_EMAIL_INFO2 { get; set; }

		///// <summary>
		///// číslo občanského průkazu
		///// </summary>
		//[NotNullOrEmptyAttribute]
		//public string WO_NO_IDENTITY_CARD { get; set; }

		/// <summary>
		/// typ objednávky (install option, adwance exchange, etc..)
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string WO_PR_TYPE { get; set; }

		/// <summary>
		/// patro klientovy přípojky
		/// </summary>		
		public string WO_FLOOR_FLAT { get; set; }

		/// <summary>
		/// telefonni cislo UPC linka 1
		/// </summary>		
		public string WO_UPC_TEL1 { get; set; }

		/// <summary>
		/// telefonni cislo UPC linka 2
		/// </summary>		
		public string WO_UPC_TEL2 { get; set; }

		/// <summary>
		/// email upc.mail generovany v pripade ze klient od nas ma HSD
		/// </summary>		
		public string WO_EMAIL { get; set; }

		/// <summary>
		/// heslo k emailu automaticky generovanemu (upc.mail)
		/// </summary>		
		public string WO_PASSWORD { get; set; }
		
		/// <summary>
		/// informace kdy CSR urci zda ma kuryr nevyzvedavat CPE => v pripade nepridani polozky, 
		/// odchazi automaticky k vyzvednuti CPE od klienta a objednani sluzby xxxx od GLS. 
		/// V pripade pridani polozky u GLS neobjednavame sluzbu diky které kuryr vyzvedava CPE od klienta
		/// </summary>		
		public string WO_CPE_BACK { get; set; }

		/// <summary>
		/// poznámka na ZL
		/// </summary>		
		public string WO_NOTE { get; set; }

		/// <summary>
		/// typ objednavky {SINGLE, MULTIPLE}, prozatim jen SINGLE
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string L_TYPE_OF_ORDER { get; set; }

		/// <summary>
		/// datum kdy chceme aby XPO expedovala
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime L_SHIPMENT_EXPECTED { get; set; }

		/// <summary>
		/// položky (požadované items)
		/// </summary>
		[XmlArrayItem("itemOrKit", typeof(C0Items))]
		[XmlArray("itemsOrKits")]
		public List<C0Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public C0Header()
		{
			this.items = new List<C0Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(C0Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<C0Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (C0Items item in items)
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
	public class C0Items
	{
		/// <summary>
		/// ItemVerKit
		/// </summary>
		public bool L_ITEM_VER_KIT { get; set; }

		/// <summary>
		/// ItemKitId
		/// </summary>
		[IntMinMax(Min = 1)]
		public int L_ITEM_OR_KIT_ID { get; set; }

		/// <summary>
		/// ItemKitDescription
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string L_ITEM_OR_KIT_DESCRIPTION { get; set; }

		/// <summary>
		/// ItemKitQuantity
		/// </summary>		
		public decimal L_ITEM_OR_KIT_QUANTITY { get; set; }

		/// <summary>
		/// ItemOrKitQualityID
		/// </summary>
		[IntMinMax(Min = 1)]
		public int L_ITEM_OR_KIT_QUALITY_ID { get; set; }
		
		/// <summary>
		/// ItemKitQuality
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string L_ITEM_OR_KIT_QUALITY { get; set; }

		/// <summary>
		/// ItemOrKitMeasureID
		/// </summary>
		[IntMinMax(Min = 1)]
		public int L_ITEM_OR_KIT_MEASURE_ID { get; set; }

		/// <summary>
		/// ItemOrKitUnitOfMeasure
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string L_ITEM_OR_KIT_MEASURE { get; set; }

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(C0Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<C0Items>(data, out errors);

			return errors;
		}
	}
}
