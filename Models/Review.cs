namespace RepairAndConstructionService.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int WorkerId { get; set; }
        public Worker Worker { get; set; }

        public string Comment { get; set; }
        public int Rating { get; set; } // 1 to 5 stars
    }
}
