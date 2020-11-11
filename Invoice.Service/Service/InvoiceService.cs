using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Invoice.Data.Context;
using Invoice.Data.DTO.Request;
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
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var dbEntity = await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
                    dbEntity.DateCreated = entity.DateCreated;
                    dbEntity.DueDate = entity.DueDate;
                    dbEntity.Number = entity.Number;
                    dbEntity.InvoiceRecipient = entity.InvoiceRecipient;
                    await _context.SaveChangesAsync().ConfigureAwait(false);


                    var invoiceItems = await _context.InvoiceItems.Where(x => x.InvoiceId == dbEntity.Id).AsNoTracking().ToListAsync();
                    var invoiceItemsToAdd = entity.InvoiceItems.Where(x => !x.Id.HasValue).Select(x => new Data.Model.InvoiceItem()
                    {
                        Description = x.Description,
                        InvoiceId = dbEntity.Id,
                        Quantity = x.Quantity,
                        TotalUnitRawPrice = x.TotalUnitRawPrice,
                        UnitPrice = x.UnitPrice
                    }).ToList();
                    if (invoiceItemsToAdd.Any())
                    {
                        _context.InvoiceItems.AddRange(invoiceItemsToAdd);
                    }

                    var invoiceItemsToEdit = entity.InvoiceItems.Where(x => invoiceItems.Any(y => y.Id == x.Id) && x.Id.HasValue).ToList();
                    if (invoiceItemsToEdit.Any())
                    {
                        invoiceItemsToEdit.ForEach(invoiceItem =>
                        {
                            var item = new Data.Model.InvoiceItem { Id = invoiceItem.Id.Value };
                            _context.InvoiceItems.Attach(item);
                            item.Description = invoiceItem.Description;
                            item.UnitPrice = invoiceItem.UnitPrice;
                            item.TotalUnitRawPrice = invoiceItem.TotalUnitRawPrice;
                            item.Quantity = invoiceItem.Quantity;
                        });
                    }

                    var invoiceItemsToDelete = invoiceItems.Where(x => entity.InvoiceItems.All(y => y.Id != x.Id)).ToList();
                    if (invoiceItemsToDelete.Any())
                    {
                        invoiceItemsToDelete.ForEach(invoiceItem =>
                        {
                            _context.InvoiceItems.Attach(invoiceItem);
                            _context.InvoiceItems.Remove(invoiceItem);
                        });
                    }

                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    transaction.Commit();

                    return _mapper.Mapper.Map<Data.DTO.Response.Invoice>(dbEntity);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
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
