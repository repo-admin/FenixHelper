using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Třída pro vytvoření XML message pro Kit K1
    ///     (potvrzení kittingu ze strany ND)
    /// </summary>
    [XmlRoot("NewDataSet")]
    public class K1Kit : IXMLMessage
    {
        #region Contructors

        /// <summary>
        ///     ctor
        /// </summary>
        public K1Kit()
        {
            Header = new K1Header();
        }

        #endregion

        #region Properties

        /// <summary>
        /// </summary>
        [XmlElement(ElementName = "CommunicationMessagesKittingConfirmation")]
        public K1Header Header { get; set; }

        #endregion

        /// <summary>
        ///     Vytvoří XML string serializací této třídy
        /// </summary>
        /// <returns></returns>
        public string ToXMLString()
        {
            return XmlCreator.CreateXmlString(this, BC.UrlW3OrgSchema, Encoding.UTF8);
        }

        /// <summary>
        ///     Validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate()
        {
            return Header.Validate(Header);
        }
    }

    /// <summary>
    ///     Hlavička
    /// </summary>
    public class K1Header
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public K1Header()
        {
            ItemSNs = new List<K1ItemSN>();
        }

        /// <summary>
        ///     číslo objednávky z Heliosu
        /// </summary>
        public int? HeliosOrderID { get; set; }

        /// <summary>
        ///     ID kitu
        /// </summary>
        [IntMinMax(Min = 1)]
        public int ID { get; set; }

        /// <summary>
        ///     sériová čísla
        /// </summary>
        [XmlArray("ItemSNs")]
        public List<K1ItemSN> ItemSNs { get; set; }

        /// <summary>
        /// </summary>
        [NotNullOrEmpty]
        public string KitDescription { get; set; }

        /// <summary>
        /// </summary>
        [IntMinMax(Min = 1)]
        public int KitID { get; set; }

        /// <summary>
        /// </summary>
        [IntMinMax(Min = 1)]
        public int KitOrderID { get; set; }

        /// <summary>
        ///     popis kvality kitu
        /// </summary>
        [NotNullOrEmpty]
        public string KitQuality { get; set; }

        /// <summary>
        ///     ID kvality kitu
        /// </summary>
        [IntMinMax(Min = 1)]
        public int KitQualityID { get; set; }

        /// <summary>
        ///     objednané množství
        /// </summary>
        public decimal KitQuantity { get; set; }

        /// <summary>
        ///     měrná jednotka
        /// </summary>
        [NotNullOrEmpty]
        public string KitUnitOfMeasure { get; set; }

        /// <summary>
        ///     ID měrné jednotky
        /// </summary>
        [IntMinMax(Min = 1)]
        public int KitUnitOfMeasureID { get; set; }

        /// <summary>
        ///     datum, kdy byl kittng objednán (datum odeslání K0)
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime MessageDateOfReceipt { get; set; }

        /// <summary>
        ///     unikátní číslo zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageID { get; set; }

        /// <summary>
        ///     popis typu zprávy
        /// </summary>
        [NotNullOrEmpty]
        public string MessageTypeDescription { get; set; }

        /// <summary>
        ///     typ zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageTypeID { get; set; }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate(K1Header data)
        {
            var errors = new List<string>();

            Validation.Validation.ValidateAllProperties(data, out errors);

            return errors;
        }
    }

    /// <summary>
    ///     Sériová čísla items v kitu
    /// </summary>
    [XmlType(TypeName = "ItemSN")]
    public class K1ItemSN
    {
        /// <summary>
        ///     1. sériové číslo
        /// </summary>
        [XmlAttribute("SN1")]
        public string SerialNumber1 { get; set; }

        /// <summary>
        ///     2. sériové číslo
        /// </summary>
        [XmlAttribute("SN2")]
        public string SerialNumber2 { get; set; }
    }
}