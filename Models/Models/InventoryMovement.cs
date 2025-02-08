using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class InventoryMovement
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public int IdInput { get; set; }

    public int Lot { get; set; }

    public DateTime Date { get; set; }

    public string User { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual Input IdInputNavigation { get; set; } = null!;
}
