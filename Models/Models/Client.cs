using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class Client
{
    public int Id { get; set; }

    public long Nit { get; set; }

    public string Name { get; set; } = null!;

    public long Phone { get; set; }

    public string ContactName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int IdCity { get; set; }

    public virtual ICollection<BillingAccount> BillingAccounts { get; set; } = new List<BillingAccount>();

    public virtual City IdCityNavigation { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
