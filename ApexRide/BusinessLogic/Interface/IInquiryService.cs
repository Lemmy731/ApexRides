using ApexRide.Models;

namespace ApexRide.BusinessLogic.Interface
{
    public interface IInquiryService
    {
        Task<bool> Create(Inquiry inquiry);
    }
}
