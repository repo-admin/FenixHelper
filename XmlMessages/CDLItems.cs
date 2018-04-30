using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Xml;

#region XML

/* 
<?xml version="1.0" encoding="utf-8"?>
<NewDataSet xmlns="http://www.w3.org/2001/XMLSchema">
  <ItemIntegration>
  <ID>201408192</ID>
  <MessageId>1201408192</MessageId>
  <MessageType>Item</MessageType>
  <MessageDescription>ItemIntegration</MessageDescription>
  <MessageStatus>1</MessageStatus>
  <items>
    <item>
      <ItemID>201408193</ItemID>
      <ItemDescription>GSF 101 /Blankom/</ItemDescription>
      <QtyBox>1</QtyBox>
      <QtyPallet>10</QtyPallet>
      <ItemTypeID>1</ItemTypeID>
      <ItemTypeCode>NW</ItemTypeCode>
      <ItemTypeDesc1>Materiál</ItemTypeDesc1>
      <ItemTypeDesc2>Network</ItemTypeDesc2>
    </item>
    <item>
      <ItemID>201408194</ItemID>
      <ItemDescription>TC7200 (Technicolor)</ItemDescription>
      <QtyBox>1</QtyBox>
      <QtyPallet>10</QtyPallet>
      <ItemTypeID>2</ItemTypeID>
      <ItemTypeCode>CPE</ItemTypeCode>
      <ItemTypeDesc1>Zařízení</ItemTypeDesc1>
      <ItemTypeDesc2>CPE</ItemTypeDesc2>
    </item>
    <item>  
      <ItemID>201408195</ItemID>
      <ItemDescription>CT1900-Telekabel</ItemDescription>
      <QtyBox>1</QtyBox>
      <QtyPallet>10</QtyPallet>
      <ItemTypeID>3</ItemTypeID>
      <ItemTypeCode>SPP</ItemTypeCode>
      <ItemTypeDesc1>Náhradní díly</ItemTypeDesc1>
      <ItemTypeDesc2>Spare Parts</ItemTypeDesc2>
    </item>
    <item>  
      <ItemID>201408196</ItemID>
      <ItemDescription>Příručka internet a telefon-mini CD</ItemDescription>
      <QtyBox>1</QtyBox>
      <QtyPallet>10</QtyPallet>
      <ItemTypeID>4</ItemTypeID>
      <ItemTypeCode>MKT</ItemTypeCode>
      <ItemTypeDesc1>Marketing</ItemTypeDesc1>
      <ItemTypeDesc2>Marketing</ItemTypeDesc2>
    </item>
  </items>
  </ItemIntegration>
</NewDataSet>
 */

#endregion

namespace Fenix.XmlMessages
{
	/// <summary>
	/// Třída představující Xml message pro : cdlItem co není KIT	
	/// </summary>
	/// <remarks>
	/// &lt;?xml version="1.0" encoding="utf-8"?&gt;
	/// &lt;NewDataSet xmlns="http://www.w3.org/2001/XMLSchema"&gt;
	/// &lt;ItemIntegration&gt;
	/// &lt;ID&gt;201408192&lt;/ID&gt;
	/// &lt;MessageId&gt;1201408192&lt;/MessageId&gt;
	/// &lt;MessageType&gt;Item&lt;/MessageType&gt;
	/// &lt;MessageDescription&gt;ItemIntegration&lt;/MessageDescription&gt;
	/// &lt;MessageStatus&gt;1&lt;/MessageStatus&gt;
	/// &lt;items&gt;
	/// &lt;item&gt;
	/// &lt;ItemID&gt;201408193&lt;/ItemID&gt;
	/// &lt;ItemDescription&gt;GSF 101 /Blankom/&lt;/ItemDescription&gt;
	/// &lt;QtyBox&gt;1&lt;/QtyBox&gt;
	/// &lt;QtyPallet&gt;10&lt;/QtyPallet&gt;
	/// &lt;ItemTypeID&gt;1&lt;/ItemTypeID&gt;
	/// &lt;ItemTypeCode&gt;NW&lt;/ItemTypeCode&gt;
	/// &lt;ItemTypeDesc1&gt;Materiál&lt;/ItemTypeDesc1&gt;
	/// &lt;ItemTypeDesc2&gt;Network&lt;/ItemTypeDesc2&gt;
	/// &lt;/item&gt;
	/// &lt;item&gt;
	/// &lt;ItemID&gt;201408194&lt;/ItemID&gt;
	/// &lt;ItemDescription&gt;TC7200 (Technicolor)&lt;/ItemDescription&gt;
	/// &lt;QtyBox&gt;1&lt;/QtyBox&gt;
	/// &lt;QtyPallet&gt;10&lt;/QtyPallet&gt;
	/// &lt;ItemTypeID&gt;2&lt;/ItemTypeID&gt;
	/// &lt;ItemTypeCode&gt;CPE&lt;/ItemTypeCode&gt;
	/// &lt;ItemTypeDesc1&gt;Zařízení&lt;/ItemTypeDesc1&gt;
	/// &lt;ItemTypeDesc2&gt;CPE&lt;/ItemTypeDesc2&gt;
	/// &lt;/item&gt;
	/// &lt;item&gt;  
	/// &lt;ItemID&gt;201408195&lt;/ItemID&gt;
	/// &lt;ItemDescription&gt;CT1900-Telekabel&lt;/ItemDescription&gt;
	/// &lt;QtyBox&gt;1&lt;/QtyBox&gt;
	/// &lt;QtyPallet&gt;10&lt;/QtyPallet&gt;
	/// &lt;ItemTypeID&gt;3&lt;/ItemTypeID&gt;
	/// &lt;ItemTypeCode&gt;SPP&lt;/ItemTypeCode&gt;
	/// &lt;ItemTypeDesc1&gt;Náhradní díly&lt;/ItemTypeDesc1&gt;
	/// &lt;ItemTypeDesc2&gt;Spare Parts&lt;/ItemTypeDesc2&gt;
	/// &lt;/item&gt;
	/// &lt;item&gt;  
	/// &lt;ItemID&gt;201408196&lt;/ItemID&gt;
	/// &lt;ItemDescription&gt;Příručka internet a telefon-mini CD&lt;/ItemDescription&gt;
	/// &lt;QtyBox&gt;1&lt;/QtyBox&gt;
	/// &lt;QtyPallet&gt;10&lt;/QtyPallet&gt;
	/// &lt;ItemTypeID&gt;4&lt;/ItemTypeID&gt;
	/// &lt;ItemTypeCode&gt;MKT&lt;/ItemTypeCode&gt;
	/// &lt;ItemTypeDesc1&gt;Marketing&lt;/ItemTypeDesc1&gt;
	/// &lt;ItemTypeDesc2&gt;Marketing&lt;/ItemTypeDesc2&gt;
	/// &lt;/item&gt;
	/// &lt;/items&gt;
	/// &lt;/ItemIntegration&gt;
	/// &lt;/NewDataSet&gt;
	/// </remarks>
	[XmlRoot("NewDataSet")]
	public class CDLItems : IXMLMessage
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "ItemIntegration")]
		public CdlItemsItemIntegration ItemIntegration { get; set; }
		
		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLItems()
		{
			this.ItemIntegration = new CdlItemsItemIntegration();
		}

		#endregion

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public string ToXMLString()
		{
			return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<string> Validate()
		{
			throw new NotImplementedException();
		}
	}
}
