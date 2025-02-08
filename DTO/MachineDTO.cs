namespace DTO
{
    public class MachineDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!;

        public DateTime PurchaseDate { get; set; }

        public string ImageUrl { get; set; } = null!;

        public int IdMaintenancePlan { get; set; }

    }
}
