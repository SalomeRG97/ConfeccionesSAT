using System;
using System.Collections.Generic;

namespace Models.Models;

public partial class BillingAccount
{
    public int Id { get; set; }

    public int IdClient { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly IssueDate { get; set; }

    public DateOnly DueDate { get; set; }

    public decimal Amount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public int IdOrder { get; set; }

    public virtual Client IdClientNavigation { get; set; } = null!;

    public virtual Order IdOrderNavigation { get; set; } = null!;
}
