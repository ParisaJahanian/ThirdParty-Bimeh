using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Fire
{

    using System.Text.Json.Serialization;

    namespace BimehApi.Models.SportsInsurance
    {
        public sealed class InquiryRes
        {
            [JsonPropertyName("inquiries")]
            public List<Inquiry> Inquiries { get; set; }

            [JsonPropertyName("companies")]
            public List<Company> Companies { get; set; }

            [JsonPropertyName("moreDetails")]
            public List<MoreDetailType> MoreDetails { get; set; }

            [JsonPropertyName("message")]
            public string? Message { get; set; }

            [JsonPropertyName("messages")]
            public List<Message> Messages { get; set; }

            [JsonPropertyName("durations")]
            public List<Durations> Durations { get; set; }
        }
        public sealed class Durations
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }
            [JsonPropertyName("title")]
            public string Title { get; set; }
        }
        public sealed class Company
        {
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string Title { get; set; }

            [JsonPropertyName("logoURL")]
            public string LogoURL { get; set; }

            [JsonPropertyName("privateConditions")]
            public string PrivateConditions { get; set; }

            [JsonPropertyName("financialStrength")]
            public int FinancialStrength { get; set; }

            [JsonPropertyName("hasOnlineIssue")]
            public bool HasOnlineIssue { get; set; }

            [JsonPropertyName("financialDetails")]
            public string FinancialDetails { get; set; }

            [JsonPropertyName("compensationBranchCount")]
            public int CompensationBranchCount { get; set; }

            [JsonPropertyName("corporateLogoURL")]
            public string CorporateLogoURL { get; set; }

            [JsonPropertyName("corporateName")]
            public string CorporateName { get; set; }

            [JsonPropertyName("fastDelivery")]
            public string FastDelivery { get; set; }

            [JsonPropertyName("tag")]
            public string Tag { get; set; }

            [JsonPropertyName("notice")]
            public string Notice { get; set; }

            [JsonPropertyName("companyResponseTime")]
            public string CompanyResponseTime { get; set; }

            [JsonPropertyName("companySatisfiedRating")]
            public int CompanySatisfiedRating { get; set; }

            [JsonPropertyName("mobileCompensation")]
            public string? MobileCompensation { get; set; }

            [JsonPropertyName("pinned")]
            public string? Pinned { get; set; }

        }

        public sealed class Inquiry
        {
            [JsonPropertyName("uniqueId")]
            public string UniqueId { get; set; }

            [JsonPropertyName("planId")]
            public int? PlanId { get; set; }

            [JsonPropertyName("details")]
            public CoverageDetail Details { get; set; }

            [JsonPropertyName("franchisePercent")]
            public double? FranchisePercent { get; set; }

            [JsonPropertyName("moreDetails")]
            public List<MoreDetail> MoreDetails { get; set; }

            [JsonPropertyName("hasInstallments")]
            public bool HasInstallments { get; set; }

            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonPropertyName("subTitle")]
            public string? SubTitle { get; set; }

            [JsonPropertyName("duration")]
            public int? Duration { get; set; }

            [JsonPropertyName("durationId")]
            public int? DurationId { get; set; }

            [JsonPropertyName("pinned")]
            public bool Pinned { get; set; }

            [JsonPropertyName("offer")]
            public bool Offer { get; set; }

            [JsonPropertyName("saleRank")]
            public int SaleRank { get; set; }

            [JsonPropertyName("isLocked")]
            public bool IsLocked { get; set; }

            [JsonPropertyName("companyId")]
            public int CompanyId { get; set; }

            [JsonPropertyName("hint")]
            public string? Hint { get; set; }

            [JsonPropertyName("cashPrice")]
            public CashPrice CashPrice { get; set; }

        }
        public sealed class CashPrice
        {
            [JsonPropertyName("firstAmount")]
            public float FirstAmount { get; set; }

            [JsonPropertyName("finalAmount")]
            public float FinalAmount { get; set; }

            [JsonPropertyName("hint")]
            public string? Hint { get; set; }

        }

        public sealed class CoverageDetail
        {
            [JsonPropertyName("coverageDetails")]
            public string? CoverageDetailItem { get; set; }
        }
        public sealed class MoreDetailType
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("title")]
            public string? Title { get; set; }

            [JsonPropertyName("description")]
            public string? Description { get; set; }
        }
        public sealed class MoreDetail
        {
            [JsonPropertyName("id")]
            public int Id { get; set; }

            [JsonPropertyName("value")]
            public string? Value { get; set; }


        }
        public sealed class Message
        {
            [JsonPropertyName("text")]
            public string? Text { get; set; }

            [JsonPropertyName("type")]
            public string? Type { get; set; }

            [JsonPropertyName("source")]
            public string? Source { get; set; }
        }
    }

}
