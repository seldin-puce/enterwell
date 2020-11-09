using AutoMapper;

namespace Invoice.Service.AutoMapperConfiguration
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Data.Model.Invoice, Model.Response.Invoice>();
            CreateMap<Model.Request.Invoice, Data.Model.Invoice>().ReverseMap();
            CreateMap<Model.Response.Invoice, Model.Request.Invoice>();

            CreateMap<Model.Request.InvoiceItem, Data.Model.InvoiceItem>().ReverseMap();
            CreateMap<Data.Model.InvoiceItem, Model.Response.InvoiceItem>();
        }
    }
}