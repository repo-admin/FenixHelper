using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

#region XML
/*
<?xml version="1.0" encoding="UTF-8"?>
<NewDataSet xmlns="http://www.w3.org/2001/XMLSchema">
  <CommunicationMessagesReceptionConfirmation>
    <ID>4956</ID>
    <MessageID>01000000032</MessageID>
    <MessageTypeID>2</MessageTypeID>
    <MessageTypeDescription>ReceptionConfirmation</MessageTypeDescription>
    <MessageDateOfReceipt>2014-08-08</MessageDateOfReceipt>
    <ReceptionOrderID>1</ReceptionOrderID>
    <HeliosOrderID>135201</HeliosOrderID>
    <ItemSupplierID>10</ItemSupplierID>
    <ItemSupplierDescription>LICA servis s.r.o.</ItemSupplierDescription>
    <items>
      <item>
        <HeliosOrderRecordID>555422</HeliosOrderRecordID>
        <ItemID>3240</ItemID>
        <ItemDescription>kompletace  Kaon KCF-SA700PCO HD-HDD USB READY</ItemDescription>
        <ItemQuantity>5454</ItemQuantity>
        <ItemUnitOfMeasureID>1</ItemUnitOfMeasureID>
        <ItemUnitOfMeasure>KS</ItemUnitOfMeasure>
        <ItemQualityID>1</ItemQualityID>
        <ItemQuality>New</ItemQuality>
        <ItemSNs>
          <ItemSN SN="A71865865"> </ItemSN>
          <ItemSN SN="A71865966"> </ItemSN>
        </ItemSNs>
      </item>
    </items>
  </CommunicationMessagesReceptionConfirmation>
</NewDataSet>
*/
#endregion

namespace Fenix.XmlMessages
{
	/// <summary>
	/// Třída pro vytvoření XML message pro Reception R1	
	/// (potvrzení recepce ze strany ND)
	/// </summary>
	/// <remarks>
	/// <code>
	/// &lt;?xml version=&quot;1.0&quot; encoding=&quot;UTF-8&quot;?&gt;
    /// &lt;NewDataSet xmlns=&quot;http://www.w3.org/2001/XMLSchema&quot;&gt;
    ///  &lt;CommunicationMessagesReceptionConfirmation&gt;
    ///    &lt;ID&gt;4956&lt;/ID&gt;
    ///    &lt;MessageID&gt;01000000032&lt;/MessageID&gt;
    ///    &lt;MessageTypeID&gt;2&lt;/MessageTypeID&gt;
    ///    &lt;MessageTypeDescription&gt;ReceptionConfirmation&lt;/MessageTypeDescription&gt;
    ///    &lt;MessageDateOfReceipt&gt;2014-08-08&lt;/MessageDateOfReceipt&gt;
    ///    &lt;ReceptionOrderID&gt;1&lt;/ReceptionOrderID&gt;
    ///    &lt;HeliosOrderID&gt;135201&lt;/HeliosOrderID&gt;
    ///    &lt;ItemSupplierID&gt;10&lt;/ItemSupplierID&gt;
    ///    &lt;ItemSupplierDescription&gt;LICA servis s.r.o.&lt;/ItemSupplierDescription&gt;
    ///    &lt;items&gt;
    ///      &lt;item&gt;
    ///        &lt;HeliosOrderRecordID&gt;555422&lt;/HeliosOrderRecordID&gt;
    ///        &lt;ItemID&gt;3240&lt;/ItemID&gt;
    ///        &lt;ItemDescription&gt;kompletace  Kaon KCF-SA700PCO HD-HDD USB READY&lt;/ItemDescription&gt;
    ///        &lt;ItemQuantity&gt;5454&lt;/ItemQuantity&gt;
    ///        &lt;ItemUnitOfMeasureID&gt;1&lt;/ItemUnitOfMeasureID&gt;
    ///        &lt;ItemUnitOfMeasure&gt;KS&lt;/ItemUnitOfMeasure&gt;
    ///        &lt;ItemQualityID&gt;1&lt;/ItemQualityID&gt;
    ///        &lt;ItemQuality&gt;New&lt;/ItemQuality&gt;
    ///        &lt;ItemSNs&gt;
    ///          &lt;ItemSN SN=&quot;A71865865&quot;&gt; &lt;/ItemSN&gt;
    ///          &lt;ItemSN SN=&quot;A71865966&quot;&gt; &lt;/ItemSN&gt;
    ///        &lt;/ItemSNs&gt;
    ///      &lt;/item&gt;
    ///    &lt;/items&gt;
    ///  &lt;/CommunicationMessagesReceptionConfirmation&gt;
    /// &lt;/NewDataSet&gt;
	/// </code>
	/// </remarks>
	[XmlRoot("NewDataSet")]
	public class R1Reception : IXMLMessage
	{
		#region Properties		
		
		/// <summary>
		/// 
		/// </summary>		
		[XmlElement(ElementName = "CommunicationMessagesSent")]
		public List<R1Header> Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public R1Reception()
		{
			Header = new List<R1Header>();
		}

		#endregion

		#region Public Methods

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
			List<string> errors = new List<string>();

			foreach (R1Header item in Header)
			{
				errors.AddRange(item.Validate(item));
			}

			return errors;
		}

		#endregion
	}

	/// <summary>
	/// Hlavička
	/// </summary>
	public class R1Header
	{
		/// <summary>
		/// ID (čeho?????????)
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// ID zprávy (ze strany ND)
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageID { get; set; }

		/// <summary>
		/// ID typu zprávy
		/// </summary>
		[IntMinMax(Min = 1)]
		public int MessageType { get; set; }

		/// <summary>
		/// popis typu zprávy
		/// </summary>
		[NotNullOrEmpty]
		public string MessageDescription { get; set; }

		/// <summary>		
		/// datum odeslání R0
		/// </summary>
		[XmlElement(DataType = "date")]
		public DateTime? MessageDateOfReceipt { get; set; }

		/// <summary>
		/// ID objednávky recepce (R0)
		/// </summary>
		public int ReceptionOrderID  { get; set; }
		
		/// <summary>
		/// číslo objednávky z Heliosu
		/// </summary>
		public int HeliosOrderID  { get; set; }
		
		/// <summary>
		/// ID dodavatele
		/// </summary>
		public int ItemSupplierID  { get; set; }

		/// <summary>
		/// popis/název dodavatele
		/// </summary>
		public string ItemSupplierDescription { get; set; }

		/// <summary>
		/// položky (požadované items)
		/// </summary>
		[XmlArrayItem("item", typeof(R1Items))]
		[XmlArray("items")]
		public List<R1Items> items { get; set; }
		
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(R1Header data)
		{
			List<string> errors = new List<string>();

			Validation.Validation.ValidateAllProperties<R1Header>(data, out errors);

			if (this.items.Count > 0)
			{
				foreach (R1Items item in this.items)
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
	public class R1Items
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
		/// sériová čísla
		/// </summary>
		[XmlArray("ItemSNs")]
		public List<R1ItemSN> ItemSNs { get; set; }

		/// <summary>
		/// ctor
		/// </summary>
		public R1Items()
		{
			this.ItemSNs = new List<R1ItemSN>();
		}

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(R1Items data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<R1Items>(data, out errors);

			return errors;
		}
	}

	/// <summary>
	/// Sériové číslo objednané položky (item)
	/// </summary>	
	[XmlType(TypeName = "ItemSN")]
	public class R1ItemSN
	{
		/// <summary>
		/// sériové číslo
		/// </summary>
		[XmlAttribute("SN")]
		public string SerialNumber { get; set; }
	}

}
