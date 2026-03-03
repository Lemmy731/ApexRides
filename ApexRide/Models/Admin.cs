using System.ComponentModel.DataAnnotations;

namespace ApexRide.Models
{
    public class Admin
    {
        [Key]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
