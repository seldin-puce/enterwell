using System.ComponentModel.DataAnnotations.Schema;

namespace Invoice.Data.Model
{
    public class InvoiceItem
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Invoice))]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [ForeignKey(nameof(Item))]
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
