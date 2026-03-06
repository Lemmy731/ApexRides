using ApexRide.Models;

namespace ApexRide.Repository.Interface
{
    public interface IInquiryRepository
    {
        Task<bool> CreateInquiry(Inquiry inquiry);
        Task<List<InquiryDto>> GetInquiry();
    }
}
