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
  <xs:schema xmlns:msdata="urn:schemas-microsoft-com:xml-msdata" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns="" id="NewDataSet">
    <xs:element name="NewDataSet" msdata:UseCurrentLocale="true" msdata:MainDataTable="CommunicationMessagesCrmOrderReturnedEquipmentConfirmation" msdata:IsDataSet="true">
      <xs:complexType>
        <xs:choice maxOccurs="unbounded" minOccurs="1">
          <xs:element name="CommunicationMessagesCrmOrderReturnedEquipmentConfirmation">
            <xs:complexType>
              <xs:sequence>
                <xs:element type="xs:int" name="ID" use="required" />
                <xs:element type="xs:int" name="MessageID" use="required" />
                <xs:element type="xs:int" name="MessageTypeID" use="required" />
                <xs:element type="xs:string" name="MessageTypeDescription" use="required" />
                <xs:element type="xs:date" name="ReleaseDate" use="required" />
                <xs:element type="xs:string" name="X_PARCEL_NUMBER" use="required" />
                <xs:complexType name="ItemOrKits">
                  <xs:sequence>
                    <xs:complexType name="ItemOrKit" minOccurs="1">
                      <xs:sequence>
                        <xs:element type="xs:boolean" name="L_ITEM_VER_KIT" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_ID" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_DESCRIPTION" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_QUALITY" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_QUALITY_ID" use="required" />
                        <xs:element type="xs:decimal" name="L_ITEM_OR_KIT_QUANTITY" use="required" />
                        <xs:element type="xs:int" name="L_ITEM_OR_KIT_MEASURE_ID" use="required" />
                        <xs:element type="xs:string" name="L_ITEM_OR_KIT_MEASURE" use="required" />
                        <xs:complexType name="itemSNs">
                          <xs:sequence>
                             <xs:element type="xs:string" name="SN1" />
                             <xs:element type="xs:string" name="SN2" />
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

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída pro vytvoření XML message pro CmrOrderRetEquipConfirmation VC2	(potvrzení vratky ze strany UPC)
    /// </summary>
    /// <remarks>
    /// <code>
    /// &lt;? xml version=&quot;1.0&quot; encoding=&quot;utf-8&quot;?&gt;
    /// &lt;NewDataSet&gt;
    ///  &lt;xs:schema id = &quot; NewDataSet&quot; xmlns=&quot;&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot;&gt;
    ///    &lt;xs:element name = &quot; NewDataSet&quot; msdata:IsDataSet=&quot;true&quot; msdata:MainDataTable=&quot;CommunicationMessagesCrmOrderReturnedEquipmentConfirmation&quot; msdata:UseCurrentLocale=&quot;true&quot;&gt;
    ///      &lt;xs:complexType&gt;
    ///        &lt;xs:choice use = &quot; required&quot; maxOccurs=&quot;unbounded&quot;&gt;
    ///          &lt;xs:element name = &quot; CommunicationMessagesCrmOrderReturnedEquipmentConfirmation&quot;&gt;
    ///            &lt;xs:complexType&gt;
    ///              &lt;xs:sequence&gt;
    ///                &lt;xs:element name = &quot; ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageTypeID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; MessageTypeDescription&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; ReleaseDate&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element name = &quot; X_PARCEL_NUMBER&quot; type=&quot;xs:dateTime&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:complexType name = &quot; ItemOrKits&quot;&gt;
    ///                  &lt;xs:sequence&gt;
    ///                    &lt;xs:complexType name = &quot; ItemOrKit&quot;&gt;
    ///                      &lt;xs:sequence&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_VER_KIT&quot; type=&quot;xs:boolean&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_DESCRIPTION&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_QUALITY&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_QUALITY_ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_QUANTITY&quot; type=&quot;xs:decimal&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_MEASURE_ID&quot; type=&quot;xs:int&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element name = &quot; L_ITEM_OR_KIT_MEASURE&quot; type=&quot;xs:string&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:complexType name = &quot; ItemOrKitSNs&quot;&gt;
    ///                          &lt;xs:sequence&gt;
    ///                            &lt;ItemSN SN1 = &quot;&quot; SN2=&quot;&quot; type=&quot;xs:string&quot; minOccurs=&quot;0&quot; /&gt;
    ///                          &lt;/xs:sequence&gt;
    ///                        &lt;/xs:complexType&gt;
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
    ///&lt;/NewDataSet&gt;
    /// </code>
    /// </remarks>
    [XmlRoot("NewDataSet")]
	public class RetEquipConfVC2 : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesCrmOrderReturnedEquipmentConfirmation")]
		public VC2Header Header { get; set; }

        #endregion

        #region Contructors

        /// <summary>
        /// ctor
        /// </summary>
        public RetEquipConfVC2()
		{
			this.Header = new VC2Header();
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
	public class VC2Header
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
		[NotNullOrEmpty]
		public string MessageTypeDescription { get; set; }

		/// <summary>
		/// datum odeslání požadavku na naskladneni
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime ReleaseDate { get; set; }


        /// <summary>
        /// ParcelNr - cislo zavozu
        /// </summary>
        [NotNullOrEmpty]
		public string X_PARCEL_NUMBER { get; set; }




		/// <summary>
		/// položky objednávky (požadované items, nebo kits)
		/// </summary>
		[XmlArrayItem("ItemOrKit", typeof(VC2Items))]
		[XmlArray("ItemOrKits")]
		public List<VC2Items> items { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public VC2Header()
		{
			this.items = new List<VC2Items>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(VC2Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<VC2Header>(data, out errors);

			if (items.Count > 0)
			{
				foreach (VC2Items item in items)
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
    /// Položky požadavku na naskladneni
    /// </summary>
    public class VC2Items
	{
		/// <summary>
		/// 0 .. item  1 .. kit
		/// </summary>
		[IntMinMax(Min = 1)]
		public bool L_ITEM_VER_KIT { get; set; }

        /// <summary>
        /// kod item/kit
        /// </summary>
        [IntMinMax(Min = 1)]
        public int L_ITEM_OR_KIT_ID { get; set; }

        /// <summary>
        /// popis item/kitu
        /// </summary>
        [NotNullOrEmpty]
        public string L_ITEM_OR_KIT_DESCRIPTION { get; set; }

        /// <summary>
        /// kvalita item/kitu - popis
        /// </summary>
        [NotNullOrEmpty]
		public string L_ITEM_OR_KIT_QUALITY { get; set; }

		/// <summary>
		///kvalita item/kitu kod
		/// </summary>		
		public int L_ITEM_OR_KIT_QUALITY_ID { get; set; }

		/// <summary>
		/// pocet item/kitu na uvolneni
		/// </summary>
		[IntMinMax(Min = 1)]
		public decimal L_ITEM_OR_KIT_QUANTITY { get; set; }

		/// <summary>
		/// měrná jednotka item/kitu kod
		/// </summary>
		[IntMinMax(Min = 1)]
		public int L_ITEM_OR_KIT_MEASURE_ID { get; set; }

        /// <summary>
        /// ID kvality item/kitu
        /// </summary>
        [NotNullOrEmpty]
        public string L_ITEM_OR_KIT_MEASURE { get; set; }


        /// <summary>
        /// sériová čísla
        /// zde je to pouze vazba 1:1
        /// zmena na zaves sns:
        /// [XmlArrayItem("ItemOrKitSN", typeof(VC2Items))]
        /// [XmlArray("ItemOrKitSNs")]  -- vicenasobny zaznam SN na jeden Item
        /// </summary>
        [XmlArray("ItemOrKitSN")]
		public List<VC2ItemSN> ItemSNs { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public VC2Items()
		{
			this.ItemSNs = new List<VC2ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(VC2Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<VC2Items>(data, out errors);

			return errors;
		}
	}

	/// <summary>
	/// Sériová čísla items v kitu
	/// </summary>	
	[XmlType(TypeName = "itemSNs")]
	public class VC2ItemSN
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
