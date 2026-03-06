using ApexRide.Data;
using ApexRide.Models;
using ApexRide.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApexRide.Repository.Implementation
{
    public class InquiryRepository: IInquiryRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public InquiryRepository(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }
        public async Task<bool> CreateInquiry(Inquiry inquiry)
        {
            await _appDbContext.Inquiries.AddAsync(inquiry);
            var response = await _appDbContext.SaveChangesAsync();
            if(response > 0)
            {
                return true;    
            }    
            return false;
        }
        public async Task<List<InquiryDto>> GetInquiry()
        {
           var inquiries = await _appDbContext.Inquiries.ToListAsync();
           var map = _mapper.Map<List<InquiryDto>>(inquiries);
           return map; 
        }

    }
}
