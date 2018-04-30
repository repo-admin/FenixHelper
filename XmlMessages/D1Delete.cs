using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Třída pro příjem XML message pro Delete Order Confirmation D1
    ///     (potvrzení požadaveku na zrušení odeslané XML message na straně ND)
    /// </summary>
    [XmlRoot("NewDataSet")]
    public class D1Delete : IXMLMessage
    {
        #region Contructors

        /// <summary>
        ///     ctor
        /// </summary>
        public D1Delete()
        {
            Header = new D1Header();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Hlavička zprávy
        /// </summary>
        [XmlElement(ElementName = "CommunicationMessagesDeleteMessageOrderConfirmation")]
        public D1Header Header { get; set; }

        #endregion

        /// <summary>
        ///     vytvoří XML string serializací této třídy
        /// </summary>
        /// <returns></returns>
        public string ToXMLString()
        {
            return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
        }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate()
        {
            return Header.Validate(Header);
        }
    }

    /// <summary>
    ///     Hlavička zprávy
    /// </summary>
    public class D1Header
    {
        /// <summary>
        ///     ID zprávy, která byla vymazána
        /// </summary>
        [IntMinMax(Min = 1)]
        public int DeleteID { get; set; }

        /// <summary>
        ///     message ID (v celé databázi unikátní) zprávy, která byla vymazána
        /// </summary>
        [IntMinMax(Min = 1)]
        public int DeleteMessageID { get; set; }

        /// <summary>
        ///     popis typu zprávy, která byla vymazána
        /// </summary>
        [NotNullOrEmpty]
        public string DeleteMessageTypeDescription { get; set; }

        /// <summary>
        ///     ID typu zprávy, která byla vymazána
        /// </summary>
        [IntMinMax(Min = 1)]
        public int DeleteMessageTypeID { get; set; }

        /// <summary>
        ///     ID zprávy (vyplňuje ND)
        /// </summary>
        [IntMinMax(Min = 1)]
        public int ID { get; set; }

        /// <summary>
        ///     číslo zprávy (vyplňuje ND)
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageID { get; set; }

        /// <summary>
        ///     popis typu zprávy
        /// </summary>
        [NotNullOrEmpty]
        public string MessageTypeDescription { get; set; }

        /// <summary>
        ///     ID typu zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageTypeID { get; set; }

        /// <summary>
        ///     datum odeslání zprávy
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime SentDate { get; set; }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate(D1Header data)
        {
            List<string> errors;
            Validation.Validation.ValidateAllProperties(data, out errors);

            return errors;
        }
    }
}