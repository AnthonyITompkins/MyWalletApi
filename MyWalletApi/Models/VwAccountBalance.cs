using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class VwAccountBalance
{
    public int AccountId { get; set; }

    public string? AccountName { get; set; }

    public decimal? Balance { get; set; }
}
