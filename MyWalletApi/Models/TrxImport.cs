namespace MyWalletApi.Models
{
    public class TrxImport
    {
        public int TrxImportId { get; set; }

        public DateTime TrxDate { get; set; }

        public int PayeeId { get; set; }

        public int AccountId { get; set; }

        public decimal Amount { get; set; }

        public string? Type { get; set; }

        public DateTime? PostDate { get; set; }

        public DateTime? RecordDate { get; set; }

        public DateTime? ProcessedDate { get; set; }

        public bool Imported { get; set; }  
    }
}
