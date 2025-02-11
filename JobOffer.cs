namespace RepairAndConstructionService.Models
{
    public class JobOffer
    {
        public int Id { get; set; }
        public string Title { get; set; } // Name of the service (e.g., "Electrical Repair")
        public string Description { get; set; } // Detailed description
        public decimal Price { get; set; } // Base price for the service
    }
}
