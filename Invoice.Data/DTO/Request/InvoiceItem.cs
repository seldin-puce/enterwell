using System.ComponentModel.DataAnnotations;

namespace Invoice.Data.DTO.Request
{
    public class InvoiceItem
    {
        public int? Id { get; set; }

        public int InvoiceId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public double UnitPrice { get; set; }

        public double TotalUnitRawPrice { get; set; }

    }
}