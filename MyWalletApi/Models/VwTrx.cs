using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class VwTrx
{
    public int TrxId { get; set; }

    public decimal Amount { get; set; }

    public DateTime TrxDate { get; set; }

    public int PayeeId { get; set; }

    public int AccountId { get; set; }

    public int? CategoryId { get; set; }

    public string? Type { get; set; }

    public string? Memo { get; set; }

    public DateTime? PostDate { get; set; }

    public string? AccountName { get; set; }

    public string? CategoryName { get; set; }

    public int? CategoryParentId { get; set; }

    public string? PayeeName { get; set; }

    public int? PayeeParentId { get; set; }
}
