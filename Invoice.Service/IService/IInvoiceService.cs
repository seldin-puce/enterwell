﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Service.IService
{
    public interface IInvoiceService : IBaseService<Model.Request.Invoice, Model.Response.Invoice, int>
    { }
}