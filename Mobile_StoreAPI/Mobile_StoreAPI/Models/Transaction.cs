using System;
using System.Collections.Generic;

namespace Mobile_StoreAPI.Models;

public partial class Transaction : BaseEntityModel
{

    public string? TransactionType { get; set; }

    public double? TransactionAmount { get; set; }

    public DateOnly? TransactionDate { get; set; }
}
