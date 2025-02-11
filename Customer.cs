namespace RepairAndConstructionService.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        // Navigation properties
        public ICollection<Booking> Bookings { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
