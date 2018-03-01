using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using FenixHelper.Validation;

namespace FenixHelper.XMLMessage
{
	/// <summary>
	/// Třída pro příjem XML message pro Delete Order Confirmation D1
	/// (potvrzení požadaveku na zrušení odeslané XML message na straně ND)
	/// </summary>
	[XmlRoot("NewDataSet")]
	public class D1Delete : IXMLMessage
	{
		#region Properties

		/// <summary>
		/// Hlavička zprávy
		/// </summary>
		[XmlElement(ElementName = "CommunicationMessagesDeleteMessageOrderConfirmation")]
		public D1Header Header { get; set; }

		#endregion

		#region Contructors

		/// <summary>
		/// ctor
		/// </summary>
		public D1Delete()
		{
			this.Header = new D1Header();
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
	/// Hlavička zprávy
	/// </summary>
	public class D1Header
	{
		/// <summary>
		/// ID zprávy (vyplňuje ND)
		/// </summary>
		[IntMinMax(Min = 1)]
		public int ID { get; set; }

		/// <summary>
		/// číslo zprávy (vyplňuje ND)
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
		public DateTime SentDate { get; set; }

		/// <summary>
		/// ID zprávy, která byla vymazána
		/// </summary>
		[IntMinMax(Min = 1)]
		public int DeleteID { get; set; }

		/// <summary>
		/// message ID (v celé databázi unikátní) zprávy, která byla vymazána
		/// </summary>
		[IntMinMax(Min = 1)]
		public int DeleteMessageID { get; set; }

		/// <summary>
		/// ID typu zprávy, která byla vymazána
		/// </summary>
		[IntMinMax(Min = 1)]
		public int DeleteMessageTypeID { get; set; }

		/// <summary>
		/// popis typu zprávy, která byla vymazána
		/// </summary>
		[NotNullOrEmptyAttribute]
		public string DeleteMessageTypeDescription { get; set; }

		/// <summary>
		/// validace
		/// </summary>
		/// <returns></returns>
		public List<string> Validate(D1Header data)
		{
			List<string> errors;
			Validation.Validation.ValidateAllProperties<D1Header>(data, out errors);

			return errors;
		}
	}
}
