using System;
using System.Collections.Generic;

namespace Mobile_StoreAPI;

public partial class Product : BaseEntityModel
{

    public string? Product_Type { get; set; }

    public int? BrandId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDetails { get; set; }

    public int? ProductPricing { get; set; }

    public DateOnly? ProductCreation { get; set; }

    public DateOnly? ProductModification { get; set; }
}
