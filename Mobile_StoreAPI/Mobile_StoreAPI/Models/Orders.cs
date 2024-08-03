using System;
using System.Collections.Generic;

namespace Mobile_StoreAPI;

public partial class Orders : BaseEntityModel
{

    public int? UserId { get; set; }

    public int? DealId { get; set; }

    public int? BuyerId { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public DateOnly? UpdateOn { get; set; }

    public int? SalerManId { get; set; }

    public DateOnly? OrderDate { get; set; }

    public int? Discount { get; set; }

    public double? DiscountedAmount { get; set; }

    public int? TotalSold { get; set; }

    public int? CreatedBy { get; set; }
    public int? UpdatedBy { get; set; }
    public int? TotalAmount { get; set; }

}
