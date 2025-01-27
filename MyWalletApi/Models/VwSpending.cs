using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class VwSpending
{
    public int TrxId { get; set; }

    public int SplitId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime TrxDate { get; set; }

    public int? PayeeId { get; set; }

    public string? Payee { get; set; }

    public string? Memo { get; set; }

    public int AccountId { get; set; }

    public int CategoryId { get; set; }

    public int? CategorySubId { get; set; }

    public string Category { get; set; } = null!;

    public string? CategorySub { get; set; }

    public string? Account { get; set; }
}
