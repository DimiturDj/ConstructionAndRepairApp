namespace RepairAndConstructionService.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public double Rating { get; set; }

        // Navigation properties
        public ICollection<JobOffer> JobOffers { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
