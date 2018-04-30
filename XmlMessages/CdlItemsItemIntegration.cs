using System.Collections.Generic;
using System.Xml.Serialization;

namespace Fenix.XmlMessages
{
    /// <summary>
    /// </summary>
    public class CdlItemsItemIntegration
    {
        /// <summary>
        /// </summary>
        public CdlItemsItemIntegration()
        {
            items = new List<CdlItemsItem>();
        }

        /// <summary>
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// </summary>
        [XmlArrayItem("item", typeof(CdlItemsItem))]
        [XmlArray("items")]
        public List<CdlItemsItem> items { get; set; }

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