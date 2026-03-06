using ApexRide.Models;

namespace ApexRide.BusinessLogic.Interface
{
    public interface IInquiryService
    {
        Task<bool> CreateInquiry(Inquiry inquiry);
        Task<List<InquiryDto>> GetInquiry();
    }
}
