namespace RasArbitrCore.API
{
    public class PostRequest
    {
        public bool GroupByCase { get; set; } = false;      // Default: false
        public int Count { get; set; } = 25;                // Default: 25
        public int Page { get; set; } = 1;                  // Default: 1
        public List<string>? DisputeTypes { get; set; }
        public string? StatDisputeCategory { get; set; }
        public List<string>? Courts { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<Side>? Sides { get; set; }
        public List<string>? Judges { get; set; }
        public List<string>? Cases { get; set; }
        public string? Text { get; set; }

        public class Side
        {
            public string? Name { get; set; }
            public int Type { get; set; } = -1;             // Default: -1
            public bool ExactMatch { get; set; } = false;   // Default: false
        }
    }



}
