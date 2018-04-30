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

namespace Fenix.XmlMessages
{
	/// <summary>
	/// Třída představující Xml message pro : cdlItem co je KIT	
	/// </summary>
	/// <remarks>
	/// <code>
	/// &lt;?xml version="1.0" encoding="utf-8"?&gt;
	/// &lt;NewDataSet xmlns="http://www.w3.org/2001/XMLSchema"&gt;
	/// &lt;ItemIntegration&gt;
	///     &lt;ID&gt;1&lt;/ID&gt;
	///     &lt;MessageId&gt;6001&lt;/MessageId&gt;
	///     &lt;MessageType&gt;Item&lt;/MessageType&gt;
	///     &lt;MessageDescription&gt;ItemIntegration&lt;/MessageDescription&gt;
	///     &lt;MessageStatus&gt;1&lt;/MessageStatus&gt;
	///     &lt;items&gt;
	///         &lt;item&gt;
	///             &lt;ItemID&gt;60001&lt;/ItemID&gt;
	///             &lt;ItemDescription&gt;Test KIT 60001 - testovací KIT s items 1 a 2&lt;/ItemDescription&gt;
	///             &lt;SupplierID&gt;UPC&lt;/SupplierID&gt;
	///             &lt;SupplierName&gt;UPC&lt;/SupplierName&gt;
	///             &lt;ComponentManagement&gt;1&lt;/ComponentManagement&gt;
	///         &lt;Components&gt;
	///             &lt;Component&gt;
	///             &lt;ComponentItemID&gt;1&lt;/ComponentItemID&gt;
	///             &lt;ComponentQty&gt;10&lt;/ComponentQty&gt;
	///         &lt;/Component&gt;
	///         &lt;Component&gt;
	///             &lt;ComponentItemID&gt;2&lt;/ComponentItemID&gt;
	///             &lt;ComponentQty&gt;10&lt;/ComponentQty&gt;
	///             &lt;/Component&gt;
	///         &lt;/Components&gt;
	///         &lt;QtyBox&gt;10&lt;/QtyBox&gt;
	///         &lt;QtyPallet&gt;20&lt;/QtyPallet&gt;
	///         &lt;/item&gt;
	///     &lt;/items&gt;
	/// &lt;/ItemIntegration&gt;
	/// &lt;/NewDataSet&gt;
	/// </code>
	/// </remarks>
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
