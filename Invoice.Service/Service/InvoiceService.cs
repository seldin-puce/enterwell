﻿using System;
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
    public class InvoiceService : BaseService<Data.Model.Invoice, Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>,
        IInvoiceService
    {
        private Context _context;
        private IInvoiceAutoMapper _mapper;

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
                catch (Exception e)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public override async Task<Data.DTO.Response.Invoice> Update(Data.DTO.Request.Invoice entity, int id)
        {
            var dbEntity = await _context.Invoices.Include("InvoiceItems").Where(x => x.Id == id).SingleOrDefaultAsync();
            _context.Invoices.Attach(dbEntity);
            var a = _mapper.Mapper.Map<Data.Model.Invoice>(dbEntity);
            foreach (var item in dbEntity.InvoiceItems)
            {
                item.Description = "PELPSARA";
            }
            var a = dbEntity;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return _mapper.Mapper.Map<Data.DTO.Response.Invoice>(dbEntity);
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
