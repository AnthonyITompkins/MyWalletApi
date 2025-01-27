using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class TrxSplit
{
    public int SplitId { get; set; }

    public int TrxId { get; set; }

    public decimal Amount { get; set; }

    public int? CategoryId { get; set; }

    public string? Memo { get; set; }

    //public virtual Category? Category { get; set; }

    //public virtual Trx Trx { get; set; } = null!;
}
