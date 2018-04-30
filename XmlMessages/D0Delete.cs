using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Třída pro vytvoření XML message pro Delete Order D0
    ///     (požadavek na zrušení odeslané XML message na straně ND)
    /// </summary>
    [XmlRoot("NewDataSet")]
    public class D0Delete : IXMLMessage
    {
        #region Contructors

        /// <summary>
        ///     ctor
        /// </summary>
        public D0Delete()
        {
            Header = new D0Header();
        }

        #endregion

        #region Properties

        /// <summary>
        ///     Hlavička zprávy
        /// </summary>
        [XmlElement(ElementName = "CommunicationMessagesDeleteMessage")]
        public D0Header Header { get; set; }

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
    public class D0Header
    {
        /// <summary>
        ///     message ID (v celé databázi unikátní) zprávy, která má být vymazána
        /// </summary>
        [IntMinMax(Min = 1)]
        public int DeleteMessageID { get; set; }

        /// <summary>
        ///     popis typu zprávy, která má být vymazána
        /// </summary>
        [NotNullOrEmpty]
        public string DeleteMessageTypeDescription { get; set; }

        /// <summary>
        ///     ID typu zprávy, která má být vymazána
        /// </summary>
        [IntMinMax(Min = 1)]
        public int DeleteMessageTypeID { get; set; }

        /// <summary>
        ///     ID této zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int ID { get; set; }

        /// <summary>
        ///     (v celé databázi unikátní) číslo zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageID { get; set; }

        /// <summary>
        ///     popis typu zprávy
        /// </summary>
        [NotNullOrEmpty]
        public string MessageTypeDescription { get; set; }

        /// <summary>
        ///     ID typu XML zprávy
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
        public List<string> Validate(D0Header data)
        {
            List<string> errors;
            Validation.Validation.ValidateAllProperties(data, out errors);

            return errors;
        }
    }
}