using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class MaintenancePlan
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Machine> Machines { get; set; } = new List<Machine>();

    public virtual ICollection<MaintenanceTask> MaintenanceTasks { get; set; } = new List<MaintenanceTask>();
}
