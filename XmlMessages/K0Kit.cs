using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using Fenix.Validation;
using Fenix.Xml;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Třída pro vytvoření XML message pro Kit K0
    ///     (objednávka kittingu ze strany UPC)
    /// </summary>
    [XmlRoot("NewDataSet")]
    public class K0Kit : IXMLMessage
    {
        #region Contructors

        /// <summary>
        ///     ctor
        /// </summary>
        public K0Kit()
        {
            Header = new K0Header();
        }

        #endregion

        #region Properties

        /// <summary>
        /// </summary>
        [XmlElement(ElementName = "CommunicationMessagesSentKit")]
        public K0Header Header { get; set; }

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
    public class K0Header
    {
        /// <summary>
        ///     číslo objednávky z Heliosu
        /// </summary>
        public int? HeliosOrderID { get; set; }

        /// <summary>
        /// </summary>
        [IntMinMax(Min = 1)]
        public int ID { get; set; }

        /// <summary>
        ///     datum odeslání kittingu
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime MessageDateOfShipment { get; set; }

        /// <summary>
        ///     datum, kdy je požadován kitting
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime KitDateOfDelivery { get; set; }

        /// <summary>
        /// </summary>
        [NotNullOrEmpty]
        public string KitDescription { get; set; }

        /// <summary>
        /// </summary>
        [IntMinMax(Min = 1)]
        public int KitID { get; set; }

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
        ///     ID typu zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageTypeID { get; set; }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate(K0Header data)
        {
            var errors = new List<string>();
            Validation.Validation.ValidateAllProperties(data, out errors);

            return errors;
        }
    }
}