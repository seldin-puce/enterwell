using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoice.Plugins.Tax;

namespace Invoice.Service.IService
{
    public interface IInvoiceService : IBaseService<Data.DTO.Request.Invoice, Data.DTO.Response.Invoice, int>
    {
        Task<List<Data.DTO.Response.Invoice>> GetAllByUserId(string userId);
        Task<Data.DTO.Response.Invoice> CreateWithTax(Data.DTO.Request.Invoice entity, ITax taxService);
        Task<Data.DTO.Response.Invoice> UpdateWithTax(int id, Data.DTO.Request.Invoice entity, ITax taxService);
    }
}
