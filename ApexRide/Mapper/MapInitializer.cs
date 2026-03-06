using ApexRide.Models;
using AutoMapper;

namespace ApexRide.Mapper
{
    public  class MapInitializer: Profile
    {
        public MapInitializer()
        {
            CreateMap<Inquiry, InquiryDto>().ReverseMap();  
        }
    }
}
