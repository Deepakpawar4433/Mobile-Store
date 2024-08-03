
using System;
using System.Collections.Generic;

namespace Mobile_StoreAPI;

public partial class Brand : BaseEntityModel
{
    public string? BrandName { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }
}
