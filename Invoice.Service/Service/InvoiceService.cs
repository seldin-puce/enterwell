using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Invoice.Data.Context;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class InvoiceService : BaseService<Data.Model.Invoice, Model.Request.Invoice, Model.Response.Invoice, int>,
        IInvoiceService
    {
        private Context _context;
        private IInvoiceAutoMapper _mapper;

        public InvoiceService(Context context, IInvoiceAutoMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Model.Response.Invoice> Create(Model.Request.Invoice entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var invoiceModel = _mapper.Mapper.Map<Data.Model.Invoice>(entity);
                    _context.Invoices.Add(invoiceModel);
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                    
                    return _mapper.Mapper.Map<Model.Response.Invoice>(invoiceModel);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public override async Task<Model.Response.Invoice> GetById(int id)
        {
            return _mapper.Mapper.Map<Model.Response.Invoice>(await _context.Invoices.Include("InvoiceItems")
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public override async Task<Model.Request.Invoice> GetRequestTypeById(int id)
        {
            return _mapper.Mapper.Map<Model.Request.Invoice>(await _context.Invoices.Include("InvoiceItems")
                .FirstOrDefaultAsync(x => x.Id == id));
        }
    }
}
