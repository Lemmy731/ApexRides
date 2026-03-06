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
        public async Task<bool> CreateInquiry(Inquiry inquiry)
        {
            Inquiry inquirys = new Inquiry
            {
                Id = Guid.NewGuid().ToString(),    
                CustomerName = inquiry.CustomerName,    
                Email = inquiry.Email,  
                Message = inquiry.Message,  
                CarId = inquiry.CarId
            };
           var response = await _inquiryRepository.CreateInquiry(inquirys); 
            if(response)
            {
                return true;    
            }
            return false;
        }
        public async Task<List<InquiryDto>> GetInquiry()
        {
            
            var response = await _inquiryRepository.GetInquiry();
            if (response!= null)
            {
                return response;
            }
            return response;
        }
    }
}
