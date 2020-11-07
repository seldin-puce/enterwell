using System;
using System.Collections.Generic;
using System.Text;

namespace Invoice.Model.Response
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalUnitRawPrice { get; set; }
    }
}
