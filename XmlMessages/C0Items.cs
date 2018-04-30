using System.Collections.Generic;
using Fenix.Validation;

namespace Fenix.XmlMessages
{
    /// <summary>
    ///     Položky
    /// </summary>
    public class C0Items
    {
        /// <summary>
        ///     ItemKitDescription
        /// </summary>
        [NotNullOrEmpty]
        public string L_ITEM_OR_KIT_DESCRIPTION { get; set; }

        /// <summary>
        ///     ItemKitId
        /// </summary>
        [IntMinMax(Min = 1)]
        public int L_ITEM_OR_KIT_ID { get; set; }

        /// <summary>
        ///     ItemOrKitUnitOfMeasure
        /// </summary>
        [NotNullOrEmpty]
        public string L_ITEM_OR_KIT_MEASURE { get; set; }

        /// <summary>
        ///     ItemOrKitMeasureID
        /// </summary>
        [IntMinMax(Min = 1)]
        public int L_ITEM_OR_KIT_MEASURE_ID { get; set; }

        /// <summary>
        ///     ItemKitQuality
        /// </summary>
        [NotNullOrEmpty]
        public string L_ITEM_OR_KIT_QUALITY { get; set; }

        /// <summary>
        ///     ItemOrKitQualityID
        /// </summary>
        [IntMinMax(Min = 1)]
        public int L_ITEM_OR_KIT_QUALITY_ID { get; set; }

        /// <summary>
        ///     ItemKitQuantity
        /// </summary>
        public decimal L_ITEM_OR_KIT_QUANTITY { get; set; }

        /// <summary>
        ///     ItemVerKit
        /// </summary>
        public bool L_ITEM_VER_KIT { get; set; }

        /// <summary>
        ///     validace
        /// </summary>
        /// <returns></returns>
        public List<string> Validate(C0Items data)
        {
            List<string> errors;
            Validation.Validation.ValidateAllProperties(data, out errors);

            return errors;
        }
    }
}