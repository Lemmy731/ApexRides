using System.ComponentModel.DataAnnotations;

namespace ApexRide.Models
{
    public class Inquiry
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }

        public string CarId { get; set; }

        public Car Car { get; set; }
    }
}
