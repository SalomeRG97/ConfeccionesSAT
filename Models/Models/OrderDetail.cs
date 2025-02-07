using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int IdOrder { get; set; }

    public int IdProduct { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal? Total { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual Product IdProductNavigation { get; set; } = null!;
}
