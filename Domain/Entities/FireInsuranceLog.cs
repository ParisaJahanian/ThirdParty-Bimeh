using Bimeh.Entities;


namespace Bimeh.Entities
{
   
    public class FireInsuranceLog : BaseEntity<string>
    {
        public double TotalArea { get; set; }
        public double AppliancesValue { get; set; }
        public int AreaUnitPriceId { get; set; }
        public int EstateTypeId { get; set; }
        public int StructureTypeId { get; set; }
        public int CoverageIds { get; set; }

    }
}
