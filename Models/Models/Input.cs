namespace Models.Models;

public partial class Input
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public long Lot { get; set; }

    public string Type { get; set; } = null!;

    public DateTime PurchaseDate { get; set; }

    public string ImageUrl { get; set; } = null!;
}
