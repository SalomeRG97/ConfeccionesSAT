using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
