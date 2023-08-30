namespace persistence
{
    public sealed class FireInsuranceOptions
    {
        public const string SectionName = "FireInsurance";
        public string BasicDataAddress { get; set; }
        public string CreateAddress { get; set; }
        public string InquiryAddress { get; set; }
        public string InfoAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BusinessToken { get; set; }
        public string UserAddressBaseUrl { get; set; }
        public string ResidentialAddress { get; set; }
        public string LogisticAddress { get; set; }
        public string TokenAddress { get; set; }
        public string PaymentAddress { get; set; }
        public string InsuranceFileAddress { get; set; }
        public string UserAllRequestAddress { get; set; }
    }
}
