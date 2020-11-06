using AutoMapper;
using Invoice.Data.Context;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class InvoiceService : BaseService<Data.Model.Invoice, Model.Request.Invoice, Model.Response.Invoice, int>, IInvoiceService
    {
        public InvoiceService(Context context, IInvoiceAutoMapper mapper) : base(context, mapper)
        {
        }
    }
}
