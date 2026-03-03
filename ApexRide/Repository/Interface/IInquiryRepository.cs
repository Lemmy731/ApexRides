using ApexRide.Models;

namespace ApexRide.Repository.Interface
{
    public interface IInquiryRepository
    {
        Task<bool> Create(Inquiry inquiry);
    }
}
