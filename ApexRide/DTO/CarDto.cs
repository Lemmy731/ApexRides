using System.ComponentModel.DataAnnotations.Schema;

namespace ApexRide.DTO
{
    public class CarDto
    {
        public string Name { get; set; }

        public string Brand { get; set; }
    
        public decimal Price { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

    }
}
