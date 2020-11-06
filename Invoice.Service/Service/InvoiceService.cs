using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Data.Context;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class InvoiceService : BaseService<Data.Model.Invoice, Model.Request.Invoice, Model.Response.Invoice, int>, IInvoiceService
    {
        protected InvoiceService(Context context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
