using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fenix.XmlMessages
{
    /// <summary>
    /// </summary>
    public class CdlItemsForKitItemIntegration
    {
        /// <summary>
        /// </summary>
        public CdlItemsForKitItemIntegration()
        {
            items = new List<CdlItemsForKitItem>();
        }

        /// <summary>
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// </summary>
        [XmlArrayItem("item", typeof(CdlItemsForKitItem))]
        [XmlArray("items")]
        public List<CdlItemsForKitItem> items { get; set; }

        /// <summary>
        /// </summary>
        public string MessageDescription { get; set; }

        /// <summary>
        /// </summary>
        public int MessageID { get; set; }

        /// <summary>
        ///     Bude vždy = 1 ???
        /// </summary>
        public int MessageStatus { get; set; }

        /// <summary>
        /// </summary>
        public string MessageType { get; set; }
    }
}