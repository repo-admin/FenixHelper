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
    <ID>1</ID>
    <MessageId>6001</MessageId>
    <MessageType>Item</MessageType>
    <MessageDescription>ItemIntegration</MessageDescription>
    <MessageStatus>1</MessageStatus>
    <items>
      <item>
        <ItemID>60001</ItemID>
        <ItemDescription>Test KIT 60001 - testovací KIT s items 1 a 2</ItemDescription>
        <SupplierID>UPC</SupplierID>
        <SupplierName>UPC</SupplierName>
        <ComponentManagement>1</ComponentManagement>
        <Components>
          <Component>
          <ComponentItemID>1</ComponentItemID>
          <ComponentQty>10</ComponentQty>
          </Component>
          <Component>
          <ComponentItemID>2</ComponentItemID>
          <ComponentQty>10</ComponentQty>
          </Component>
        </Components>
        <QtyBox>10</QtyBox>
        <QtyPallet>20</QtyPallet>
      </item>
    </items>
  </ItemIntegration>
</NewDataSet>
  
 */

#endregion

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída představující XML message pro : cdlItem co je KIT	
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class CDLItemsForKit
	{
		#region Properties
		/// <summary>
		/// 
		/// </summary>
		[XmlElement(ElementName = "ItemIntegration")]
		public CdlItemsForKitItemIntegration ItemIntegration { get; set; }
		
		#endregion

		#region Contructors

		/// <summary>
		/// 
		/// </summary>
		public CDLItemsForKit()
		{
			this.ItemIntegration = new CdlItemsForKitItemIntegration();
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
	public class CdlItemsForKitItemIntegration
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
		[XmlArrayItem("item", typeof(CdlItemsForKitItem))]
		[XmlArray("items")]
		public List<CdlItemsForKitItem> items { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public CdlItemsForKitItemIntegration()
		{
			this.items = new List<CdlItemsForKitItem>();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class CdlItemsForKitItem
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
		public string SupplierID { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public string SupplierName { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public int ComponentManagement { get; set; }
		
		/// <summary>
		/// 
		/// </summary>		
		[XmlArrayItem("Components", typeof(R1ComponentItem))]
		[XmlArray("Component")]
		public List<R1ComponentItem> components { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public decimal QtyBox { get; set; }

		/// <summary>
		/// ?????
		/// </summary>
		public decimal QtyPallet { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public CdlItemsForKitItem()
		{
			this.components = new List<R1ComponentItem>();
		}
	}

	/// <summary>
	/// 
	/// </summary>
	public class R1ComponentItem
	{
		/// <summary>
		/// 
		/// </summary>
        public int ComponentItemID { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public decimal ComponentQty { get; set; }
	}
}
