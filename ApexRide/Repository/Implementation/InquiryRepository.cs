using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.Repository.Implementation
{
    public class InquiryRepository: IInquiryRepository
    {
        private readonly AppDbContext _appDbContext;
        public InquiryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<bool> Create(Inquiry inquiry)
        {
            await _appDbContext.Inquiries.AddAsync(inquiry);
            var response = await _appDbContext.SaveChangesAsync();
            if(response > 0)
            {
                return true;    
            }    
            return false;
        }

    }
}
