using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class Payee
{
    public int PayeeId { get; set; }

    public string Name { get; set; } = null!;

    public int? PayeeParentId { get; set; }

    //public virtual ICollection<Trx> Trxes { get; set; } = new List<Trx>();
}
