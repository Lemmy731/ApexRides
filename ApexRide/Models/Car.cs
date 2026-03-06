using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRide.Models
{
    public class Car
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();    

        public string Name { get; set; }

        public string Brand { get; set; }
        [Column(TypeName="decimal(18,2)")]
        public decimal Price { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<Inquiry> Inquiries{ get; set; }      
    }
}
