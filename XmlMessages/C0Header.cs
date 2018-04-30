using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fenix.Validation;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Hlavička
    /// </summary>
    public class C0Header
    {
        /// <summary>
        ///     ctor
        /// </summary>
        public C0Header()
        {
            items = new List<C0Items>();
        }

        /// <summary>
        ///     ID objednávky CRM
        /// </summary>
        [IntMinMax(Min = 1)]
        public int ID { get; set; }

        /// <summary>
        ///     položky (požadované items)
        /// </summary>
        [XmlArrayItem("itemOrKit", typeof(C0Items))]
        [XmlArray("itemsOrKits")]
        public List<C0Items> items { get; set; }

        /// <summary>
        ///     Datum, kdy je přislíbeno doručení klientovi
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime WO_DELIVERY_DATE_FROM { get; set; }

        /// <summary>
        ///     datum kdy je přislíbeno doručení klientovi (identický údaj)
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime WO_DELIVERY_DATE_TO { get; set; }

        /// <summary>
        ///     datum kdy chceme aby XPO expedovala
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime L_SHIPMENT_EXPECTED { get; set; }

        /// <summary>
        ///     typ objednavky {SINGLE, MULTIPLE}, prozatim jen SINGLE
        /// </summary>
        [NotNullOrEmpty]
        public string L_TYPE_OF_ORDER { get; set; }

        /// <summary>
        ///     datum odeslání zprávy
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime MessageDateOfShipment { get; set; }

        /// <summary>
        ///     unikátní číslo zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageID { get; set; }

        /// <summary>
        ///     Popis typu zprávy
        /// </summary>
        [NotNullOrEmpty]
        public string MessageTypeDescription { get; set; }

        /// <summary>
        ///     ID typu zprávy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int MessageTypeID { get; set; }

        /// <summary>
        ///     číslo kl. smlouvy
        /// </summary>
        [IntMinMax(Min = 1)]
        public int WO_CID { get; set; }

        /// <summary>
        ///     obec
        /// </summary>
        [NotNullOrEmpty]
        public string WO_CITY { get; set; }

        /// <summary>
        ///     informace kdy CSR urci zda ma kuryr nevyzvedavat CPE => v pripade nepridani polozky,
        ///     odchazi automaticky k vyzvednuti CPE od klienta a objednani sluzby xxxx od GLS.
        ///     V pripade pridani polozky u GLS neobjednavame sluzbu diky které kuryr vyzvedava CPE od klienta
        /// </summary>
        public string WO_CPE_BACK { get; set; }

        /// <summary>
        ///     Datum, kdy byl PR vytvořen
        /// </summary>
        [XmlElement(DataType = "date")]
        public DateTime WO_PR_CREATE_DATE { get; set; }


        /// <summary>
        ///     email upc.mail generovany v pripade ze klient od nas ma HSD
        /// </summary>
        public string WO_EMAIL { get; set; }

        /// <summary>
        ///     informacni email 1 z CRM
        /// </summary>
        public string WO_EMAIL_INFO1 { get; set; }

        /// <summary>
        ///     jmeno a prijmeni v jedne kolonce
        /// </summary>
        [NotNullOrEmpty]
        public string WO_FIRST_LAST_NAME { get; set; }

        /// <summary>
        ///     patro klientovy přípojky
        /// </summary>
        public string WO_FLOOR_FLAT { get; set; }

        /// <summary>
        ///     cislo popisne / orientacni
        /// </summary>
        [NotNullOrEmpty]
        public string WO_HOUSE_NUMBER { get; set; }

        /// <summary>
        ///     poznámka na ZL
        /// </summary>
        public string WO_NOTE { get; set; }

        /// <summary>
        ///     heslo k emailu automaticky generovanemu (upc.mail)
        /// </summary>
        public string WO_PASSWORD { get; set; }

        /// <summary>
        ///     mobilni cislo nebo pevna linka
        ///     (podminky v CRM => primarne se predava mobil, v pripade pouze pevne linky je predana pevna linka)
        /// </summary>
        [NotNullOrEmpty]
        public string WO_PHONE { get; set; }


        /// <summary>
        ///     Číslo objednávky
        /// </summary>
        [NotNullOrEmpty]
        public string WO_PR_NUMBER { get; set; }

        ///// <summary>
        ///// informacni email 2 z CRM
        ///// </summary>
        //public string WO_EMAIL_INFO2 { get; set; }

        ///// <summary>
        ///// číslo občanského průkazu
        ///// </summary>
        //[NotNullOrEmptyAttribute]
        //public string WO_NO_IDENTITY_CARD { get; set; }

        /// <summary>
        ///     Typ objednávky (install option, adwance exchange, etc..)
        /// </summary>
        [NotNullOrEmpty]
        public string WO_PR_TYPE { get; set; }

        /// <summary>
        ///     ulice
        /// </summary>
        [NotNullOrEmpty]
        public string WO_STREET_NAME { get; set; }

        /// <summary>
        ///     telefonni cislo UPC linka 1
        /// </summary>
        public string WO_UPC_TEL1 { get; set; }

        /// <summary>
        ///     telefonni cislo UPC linka 2
        /// </summary>
        public string WO_UPC_TEL2 { get; set; }

        /// <summary>
        ///     PSČ
        /// </summary>
        [NotNullOrEmpty]
        public string WO_ZIP { get; set; }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate(C0Header data)
        {
            var errors = new List<string>();

            Validation.Validation.ValidateAllProperties(data, out errors);

            if (items.Count > 0)
                foreach (var item in items)
                    errors.AddRange(item.Validate(item));
            else
                errors.Add("Item Count = [0]");

            return errors;
        }
    }
}