using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using FenixHelper;
using FenixHelper.Validation;

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

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída představující XML message pro : cdlItem co není KIT	
	/// </summary>
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
			return XmlCreator.CreateXmlString(this, BC.URL_W3_ORG_SCHEMA, Encoding.UTF8);
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

	/// <summary>
	/// 
	/// </summary>
	public class CdlItemsItemIntegration
	{
		/// <summary>
		/// 
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public int MessageID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MessageType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string MessageDescription { get; set; }

		/// <summary>
		/// Bude vždy = 1 ???
		/// </summary>
		public int MessageStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[XmlArrayItem("item", typeof(CdlItemsItem))]
		[XmlArray("items")]
		public List<CdlItemsItem> items { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public CdlItemsItemIntegration()
		{
			this.items = new List<CdlItemsItem>();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CdlItemsItem
	{
		/// <summary>
		/// 
		/// </summary>
		public int ItemID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ItemDescription { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		[XmlIgnore]
		public decimal ItemQuantity { get; set; }

		/// <summary>
		/// ??????
		/// </summary>
		public string ItemUnitOfMeasure { get; set; }

		
		/// <summary>
		/// ?????
		/// </summary>
		public string SupplierID  { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public string SupplierName  { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public int ComponentManagement  { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public decimal QtyBox  { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public decimal QtyPallet { get; set; }
		
		/// <summary>
		/// ID typu položky
		/// </summary>
		public int ItemTypeID { get; set; }

		/// <summary>
		/// kód položky	{NW, CPE, ...}
		/// </summary>
        public string ItemTypeCode  { get; set; }

		/// <summary>
		/// název typu položky CS	{Materiál, CPE, ...}
		/// </summary>
		public string ItemTypeDesc1 { get; set; }

		/// <summary>
		/// název typu položky EN	{Network, CPE, ...}
		/// </summary>
		public string ItemTypeDesc2 { get; set; }

		/// <summary>
		/// skupina zboží z Heliosu
		/// </summary>
		public string HeliosGroupGoods { get; set; }

		/// <summary>
		/// kód zboží z Heliosu
		/// </summary>
		public string HeliosCode { get; set; }
	}
}
