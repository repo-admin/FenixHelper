using System.Xml.Serialization;

namespace Fenix.XmlMessages
{
    /// <summary>
    /// </summary>
    public class CdlItemsItem
    {
        /// <summary>
        ///     ?????
        /// </summary>
        public int ComponentManagement { get; set; }

        /// <summary>
        ///     kód zboží z Heliosu
        /// </summary>
        public string HeliosCode { get; set; }

        /// <summary>
        ///     skupina zboží z Heliosu
        /// </summary>
        public string HeliosGroupGoods { get; set; }

        /// <summary>
        /// </summary>
        public string ItemDescription { get; set; }

        /// <summary>
        /// </summary>
        public int ItemID { get; set; }

        /// <summary>
        ///     ?????
        /// </summary>
        [XmlIgnore]
        public decimal ItemQuantity { get; set; }

        /// <summary>
        ///     kód položky	{NW, CPE, ...}
        /// </summary>
        public string ItemTypeCode { get; set; }

        /// <summary>
        ///     název typu položky CS	{Materiál, CPE, ...}
        /// </summary>
        public string ItemTypeDesc1 { get; set; }

        /// <summary>
        ///     název typu položky EN	{Network, CPE, ...}
        /// </summary>
        public string ItemTypeDesc2 { get; set; }

        /// <summary>
        ///     ID typu položky
        /// </summary>
        public int ItemTypeID { get; set; }

        /// <summary>
        ///     ??????
        /// </summary>
        public string ItemUnitOfMeasure { get; set; }

        /// <summary>
        ///     ?????
        /// </summary>
        public decimal QtyBox { get; set; }

        /// <summary>
        ///     ?????
        /// </summary>
        public decimal QtyPallet { get; set; }


        /// <summary>
        ///     ?????
        /// </summary>
        public string SupplierID { get; set; }

        /// <summary>
        ///     ?????
        /// </summary>
        public string SupplierName { get; set; }
    }
}