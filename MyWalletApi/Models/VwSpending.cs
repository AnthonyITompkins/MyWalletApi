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

    //public int? CategorySubId { get; set; }

    public int? CategoryParentId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategorySubName { get; set; }

    public string? CategoryFullName { get; set; }

    public string? Account { get; set; }
}
