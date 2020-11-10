using System.Linq;
using AutoMapper;

namespace Invoice.Service.AutoMapperConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Model.Invoice, Data.DTO.Response.Invoice>();
            CreateMap<Data.DTO.Request.Invoice, Data.Model.Invoice>().ReverseMap();

            CreateMap<Data.Model.InvoiceItem, Data.DTO.Request.InvoiceItem>().ReverseMap();
            CreateMap<Data.Model.InvoiceItem, Data.DTO.Response.InvoiceItem>();
        }
    }
}