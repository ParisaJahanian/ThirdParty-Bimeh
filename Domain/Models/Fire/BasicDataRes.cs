using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{
    public record BasicDataRes
    {
        [JsonPropertyName("areaUnitPrices")]
        public ICollection<AreaUnitPrices>? AreaUnitPrices { get; set; }

        [JsonPropertyName("coverages")]
        public ICollection<Coverages>? Coverages { get; set; }

        [JsonPropertyName("estateTypes")]
        public ICollection<EstateType>? EstateTypes { get; set; }

        [JsonPropertyName("structureTypes")]
        public ICollection<StructureTypes>? StructureTypes { get; set; }

        [JsonPropertyName("ownershipTypes")]
        public ICollection<OwnershipTypes>? OwnershipTypes { get; set; }

        [JsonPropertyName("maximumValueOfAppliance")]
        public double MaximumValueOfAppliance { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("voucherBanner")]
        public string? VoucherBanner { get; set; }

        [JsonPropertyName("genders")]
        public ICollection<Genders> Genders { get; set; }
    }

    public class AreaUnitPrices : BaseModel { }
    public class Coverages : BaseModel { }
    public class StructureTypes : BaseModel { }
    public class OwnershipTypes : BaseModel { }
    public class Genders : BaseModel { }
    public class EstateType : BaseModel
    {
        [JsonPropertyName("multiUnit")]
        public bool MultiUnit { get; set; }
    }
}
