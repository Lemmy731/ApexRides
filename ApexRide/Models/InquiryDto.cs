using System.ComponentModel.DataAnnotations;

namespace ApexRide.Models
{
    public class InquiryDto
    {
        public string CustomerName { get; set; }

        public string Email { get; set; }

        public string Message { get; set; }
    }
}
