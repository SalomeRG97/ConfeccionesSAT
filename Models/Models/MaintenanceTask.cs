using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class MaintenanceTask
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Periodicity { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly NextDate { get; set; }

    public int IdMaintenancePlan { get; set; }

    public virtual MaintenancePlan IdMaintenancePlanNavigation { get; set; } = null!;
}
