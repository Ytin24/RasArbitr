namespace RasArbitrCore.API
{
    public class PostResult
    {
        public ResultData? Result { get; set; }
        public string? Message { get; set; }
        public bool Success { get; set; }
        public string? ServerDate { get; set; }

        public class ResultData
        {
            public int PagesCount { get; set; }
            public int TotalCount { get; set; }
            public int NumOnPage { get; set; }
            public int Page { get; set; }
            public int ReturnCount { get; set; }
            public List<int>? Years { get; set; }
            public List<ItemData>? Items { get; set; }
        }

        public class ItemData
        {
            public string? Id { get; set; }
            public string? CaseId { get; set; }
            public string? RegistrationDate { get; set; }
            public string? InstanceNumber { get; set; }
            public string? CaseNumber { get; set; }
            public string? FileName { get; set; }
            public int InstanceLevel { get; set; }
            public string? Court { get; set; }
            public string? TypeId { get; set; }
            public string? Type { get; set; }
            public string? ContentTypesString { get; set; }
            public string? DecisionTypeId { get; set; }
            public List<string>? ContentTypes { get; set; }
            public int SphinxId { get; set; }
            public int DocumentCount { get; set; }
            public List<SignatureInfoData>? SignatureInfo { get; set; }
        }

        public class SignatureInfoData
        {
            public string? Id { get; set; }
            public string? Organization { get; set; }
            public int Status { get; set; }
            public string? Owner { get; set; }
            public string? OwnerPost { get; set; }
            public DateTime DateCheck { get; set; }
            public DateTime DateValidUntil { get; set; }
            public DateTime EffectiveDate { get; set; }
            public object? OwnerEmail { get; set; }
            public object? OwnerAddress { get; set; }
            public string? Issuer { get; set; }
            public object? VerifyErrorMessage { get; set; }
            public int SignatureId { get; set; }
            public string? EffectiveDateString { get; set; }
            public string? DateValidUntilString { get; set; }
            public string? DateCheckString { get; set; }
        }
    }
}
