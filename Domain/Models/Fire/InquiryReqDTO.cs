using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public record InquiryReqDTO : PublicLogData
    {
        /// <summary>
        /// شناسه نوع ملک (دریافت شده از سرویس basic-data)
        /// </summary>
        [JsonPropertyName("estateTypeId")]
        public int EstateTypeId { get; set; }

        /// <summary>
        /// شناسه نوع سازه (دریافت شده از سرویس basic-data)
        /// </summary>
        [JsonPropertyName("structureTypeId")]
        public int StructureTypeId { get; set; }

        /// <summary>
        /// متراژ مورد بیمه (مترمربع)
        /// </summary>
        [JsonPropertyName("totalArea")]
        public int TotalArea { get; set; }

        /// <summary>
        /// ارزش لوازم منزل (ریال)
        /// </summary>
        [JsonPropertyName("appliancesValue")]
        public int AppliancesValue { get; set; }

        /// <summary>
        /// شناسه قیمت هر متر مربع (دریافت شده از سرویس basic-data)
        /// </summary>
        [JsonPropertyName("areaUnitPriceId")]
        public int AreaUnitPriceId { get; set; }

        /// <summary>
        /// شناسه پوشش‌های اضافی (دریافت شده از سرویس basic-data)
        /// </summary>
        [JsonPropertyName("coverageIds")]
        public int CoverageIds { get; set; }
    }
}
