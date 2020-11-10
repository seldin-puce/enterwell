using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Data.Context;
using Invoice.Service.AutoMapperConfiguration;
using Invoice.Service.IService;

namespace Invoice.Service.Service
{
    public class InvoiceService : BaseService<Data.Model.Invoice, Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>,
        IInvoiceService
    {
        private readonly Context _context;
        private readonly IInvoiceAutoMapper _mapper;

        public InvoiceService(Context context, IInvoiceAutoMapper mapper) : base(context, mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public override async Task<Data.DTO.Response.Invoice> Create(Data.DTO.Request.Invoice entity)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var invoiceModel = _mapper.Mapper.Map<Data.Model.Invoice>(entity);
                    _context.Invoices.Add(invoiceModel);
                    await _context.SaveChangesAsync();
                    transaction.Commit();

                    return _mapper.Mapper.Map<Data.DTO.Response.Invoice>(invoiceModel);
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public override async Task<Data.DTO.Response.Invoice> Update(Data.DTO.Request.Invoice entity, int id)
        {
            using (var dbEntity = await _context.Invoices.Include("InvoiceItems").Where(x => x.Id == id)
                .SingleOrDefaultAsync())
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        var entityEntry = _context.Entry(dbEntity);
                        entityEntry.CurrentValues.SetValues(entity);
                        foreach (var item in entity.InvoiceItems)
                        {
                            var originalItem = dbEntity.InvoiceItems.SingleOrDefault(x => x.Id == item.Id && id != 0);
                            if (originalItem != null)
                            {
                                var childEntry = _context.Entry(originalItem);
                                childEntry.CurrentValues.SetValues(item);
                            }
                            else
                            {
                                dbEntity.InvoiceItems.Add(_mapper.Mapper.Map<Data.Model.InvoiceItem>(item));
                            }
                        }
                        foreach (var item in dbEntity.InvoiceItems.Where(c => c.Id != 0).ToList())
                        {
                            if (entity.InvoiceItems.All(x => x.Id != item.Id))
                            {
                                _context.InvoiceItems.Remove(item);
                            }
                        }
                        await _context.SaveChangesAsync();
                        transaction.Commit();
                        return _mapper.Mapper.Map<Data.DTO.Response.Invoice>(dbEntity);
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public override async Task<Data.DTO.Response.Invoice> GetById(int id)
        {
            return _mapper.Mapper.Map<Data.DTO.Response.Invoice>(await _context.Invoices.Include("InvoiceItems")
                .FirstOrDefaultAsync(x => x.Id == id));
        }

        public override async Task<Data.DTO.Request.Invoice> GetRequestTypeById(int id)
        {
            var invoice = await _context.Invoices.Include("InvoiceItems")
                .FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Mapper.Map<Data.DTO.Request.Invoice>(invoice);
        }
    }
}
