using System;
using System.Collections.Generic;

namespace Mobile_StoreAPI;

public partial class Deals : BaseEntityModel
{
    public DateOnly? DealDate { get; set; }

    public int? Discount { get; set; }

    public double? BasePrice { get; set; }

    public double? ShowPrice { get; set; }

    public double? DiscountedAmount { get; set; }
    public string? DealName { get; set; }
}
