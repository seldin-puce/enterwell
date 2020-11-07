using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Model
{
    public class InvoiceItem : BaseModel<int>
    {
        public string Description { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalUnitRawPrice { get; set; }
    }
}
