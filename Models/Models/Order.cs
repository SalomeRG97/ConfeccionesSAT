using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Order
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public DateOnly OrderDate { get; set; }

    public decimal TotalAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<BillingAccount> BillingAccounts { get; set; } = new List<BillingAccount>();

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
