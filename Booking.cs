namespace RepairAndConstructionService.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int JobOfferId { get; set; }
        public JobOffer JobOffer { get; set; }

        public int? WorkerId { get; set; } // Nullable if a worker is not assigned yet
        public Worker Worker { get; set; }

        public DateTime BookingDate { get; set; } // When the service was booked
        public DateTime? ServiceDate { get; set; } // When the service will take place
        public bool IsCompleted { get; set; } // Indicates if the service is completed
    }
}
