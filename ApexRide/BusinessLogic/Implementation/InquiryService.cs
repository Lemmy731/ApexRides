using ApexRide.BusinessLogic.Interface;
using ApexRide.Models;
using ApexRide.Repository.Interface;

namespace ApexRide.BusinessLogic.Implementation
{
    public class InquiryService: IInquiryService
    {
        private readonly IInquiryRepository _inquiryRepository;
        public InquiryService(IInquiryRepository inquiryRepository)
        {
            _inquiryRepository = inquiryRepository;
        }
        public async Task<bool> Create(Inquiry inquiry)
        {
            Inquiry inquirys = new Inquiry
            {
                Id = Guid.NewGuid().ToString(),    
                CustomerName = inquiry.CustomerName,    
                Email = inquiry.Email,  
                Message = inquiry.Message,  
                CarId = inquiry.CarId
            };
           var response = await _inquiryRepository.Create(inquirys); 
            if(response)
            {
                return true;    
            }
            return false;
        }
    }
}
