using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class Trx
{
    public int TrxId { get; set; }

    public DateTime TrxDate { get; set; }

    public int PayeeId { get; set; }

    public int AccountId { get; set; }

    public decimal Amount { get; set; }

    public string? Type { get; set; }

    public DateTime? PostDate { get; set; }

    //public virtual Account Account { get; set; } = null!;

    //public virtual Payee Payee { get; set; } = null!;

    //public virtual ICollection<TrxSplit> TrxSplits { get; set; } = new List<TrxSplit>();
}
