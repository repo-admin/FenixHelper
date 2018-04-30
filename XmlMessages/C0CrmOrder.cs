using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Xml;

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

namespace Fenix.XmlMessages
{
    /// <summary>
    /// Třída pro vytvoření xml message pro CrmOrder C0	(CRM objednávka ze strany UPC)
    /// </summary>
    /// <remarks>
    /// <code>
    /// &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
    /// &lt;NewDataSet&gt;
    ///  &lt;xs:schema xmlns:msdata=&quot;urn:schemas-microsoft-com:xml-msdata&quot; xmlns:xs=&quot;http://www.w3.org/2001/XMLSchema&quot; xmlns=&quot;&quot; id=&quot;NewDataSet&quot;&gt;
    ///    &lt;xs:element name = &quot;NewDataSet&quot; msdata:UseCurrentLocale=&quot;true&quot; msdata:MainDataTable=&quot;CommunicationMessagesCrmOrder&quot; msdata:IsDataSet=&quot;true&quot;&gt;
    ///      &lt;xs:complexType&gt;
    ///        &lt;xs:choice maxOccurs = &quot;unbounded&quot; minOccurs=&quot;1&quot;&gt;
    ///          &lt;xs:element name = &quot;CommunicationMessagesCrmOrder&quot; &gt;
    ///            &lt; xs:complexType&gt;
    ///              &lt;xs:sequence&gt;
    ///                &lt;xs:element type = &quot;xs:int&quot; name=&quot;ID&quot; use=&quot;required&quot;/&gt;
    ///                &lt;xs:element type = &quot;xs:int&quot; name=&quot;MessageID&quot; use=&quot;required&quot;/&gt;
    ///                &lt;xs:element type = &quot;xs:int&quot; name=&quot;MessageTypeID&quot; use=&quot;required&quot;/&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;MessageTypeDescription&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;MessageDateOfShipment&quot; use=&quot;required&quot; /&gt;                
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_PR_NUMBER&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:date&quot; name=&quot;WO_PR_CREATE_DATE&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:date&quot; name=&quot;WO_DELIVERY_DATE_FROM&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:date&quot; name=&quot;WO_DELIVERY_DATE_TO&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:int&quot; name=&quot;WO_CID&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_FIRST_LAST_NAME&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_STREET_NAME&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_HOUSE_NUMBER&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_CITY&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_ZIP&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_PHONE&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_EMAIL_INFO1&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_PR_TYPE&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_FLOOR_FLAT&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_UPC_TEL1&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_UPC_TEL2&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_EMAIL&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_PASSWORD&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_CPE_BACK&quot; minOccurs=&quot;0&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;WO_NOTE&quot; minOccurs=&quot;0&quot; /&gt;                
    ///                &lt;xs:element type = &quot;xs:string&quot; name=&quot;L_TYPE_OF_ORDER&quot; use=&quot;required&quot; /&gt;
    ///                &lt;xs:element type = &quot;xs:date&quot; name=&quot;L_SHIPMENT_EXPECTED&quot; use=&quot;required&quot; /&gt;                
    ///                &lt;xs:complexType name = &quot;itemsOrKits&quot; &gt;
    ///                  &lt; xs:sequence&gt;
    ///                    &lt;xs:complexType name = &quot;itemOrKit&quot; minOccurs=&quot;1&quot;&gt;
    ///                      &lt;xs:sequence&gt;
    ///                        &lt;xs:element type = &quot;xs:boolean&quot; name=&quot;L_ITEM_VER_KIT&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:int&quot; name=&quot;L_ITEM_OR_KIT_ID&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:string&quot; name=&quot;L_ITEM_OR_KIT_DESCRIPTION&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:decimal&quot; name=&quot;L_ITEM_OR_KIT_QUANTITY&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:int&quot; name=&quot;L_ITEM_OR_KIT_QUALITY_ID&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:string&quot; name=&quot;L_ITEM_OR_KIT_QUALITY&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:int&quot; name=&quot;L_ITEM_OR_KIT_MEASURE_ID&quot; use=&quot;required&quot; /&gt;
    ///                        &lt;xs:element type = &quot;xs:string&quot; name=&quot;L_ITEM_OR_KIT_MEASURE&quot; use=&quot;required&quot; /&gt;
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
		/// Vytvoří xml string serializací této třídy
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
}
