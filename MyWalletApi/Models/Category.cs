using System;
using System.Collections.Generic;

namespace MyWalletApi.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryParentId { get; set; }

    //public virtual ICollection<TrxSplit> TrxSplits { get; set; } = new List<TrxSplit>();
}
