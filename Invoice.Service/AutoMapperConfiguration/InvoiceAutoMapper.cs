using AutoMapper;

namespace Invoice.Service.AutoMapperConfiguration
{
    public interface IInvoiceAutoMapper
    {
        IMapper Mapper { get; set; }
    }
    public class InvoiceAutoMapper : IInvoiceAutoMapper
    {
        public IMapper Mapper { get; set; }

        public InvoiceAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });
            Mapper = config.CreateMapper();
        }
    }
}