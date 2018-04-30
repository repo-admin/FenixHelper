using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fenix.XmlMessages
{
    /// <summary>
    /// </summary>
    public class CdlItemsForKitItem
    {
        /// <summary>
        /// </summary>
        public CdlItemsForKitItem()
        {
            components = new List<R1ComponentItem>();
        }

        /// <summary>
        ///     ?????
        /// </summary>
        public int ComponentManagement { get; set; }

        /// <summary>
        /// </summary>
        [XmlArrayItem("Components", typeof(R1ComponentItem))]
        [XmlArray("Component")]
        public List<R1ComponentItem> components { get; set; }

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