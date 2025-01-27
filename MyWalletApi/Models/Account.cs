using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Name { get; set; } = null!;

    public string? ImportFilePath { get; set; }

    //public virtual ICollection<Trx> Trxes { get; set; } = new List<Trx>();
}
